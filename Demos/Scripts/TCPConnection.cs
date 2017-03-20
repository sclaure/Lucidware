using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;

public class TCPConnection : MonoBehaviour {

  //the name of the connection, not required but better for overview if you have more than 1 connections running
  public string conName = "ReachCon";
  
  //ip/address of the server, 127.0.0.1 is for your own computer
  public string conHost = "CLAWPI.WV.CC.CMU.EDU";
  
  //port for the server, make sure to unblock this in your router firewall if you want to allow external connections
  public int conPort = 51717;
  
  //a true/false variable for connection status
  public bool socketReady = false;
  
  TcpClient mySocket;
  NetworkStream theStream;
  StreamReader theReader;
  
  //try to initiate connection
  public void setupSocket() {
    try {
      mySocket = new TcpClient(conHost, conPort);
      theStream = mySocket.GetStream();
      theReader = new StreamReader(theStream);
      socketReady = true;
    }
    catch (Exception e) {
      Debug.Log("Socket error:" + e);
      if(!(conHost == "10.0.0.200")) {
        conHost = "10.0.0.200";
        setupSocket();
      }
    }
  }
  
  //send message to server
  public void writeSocket(string theLine) {
    if (!socketReady)
      return;
    try {
      string tmpString = theLine + "\r\n";
      byte[] bytes = new byte[tmpString.Length * sizeof(char)];
      System.Buffer.BlockCopy(tmpString.ToCharArray(), 0, bytes, 0, bytes.Length);
      theStream.Write(bytes, 0, tmpString.Length);
    }
    catch (Exception e) {
      socketReady = false;
      theReader.Close();
      mySocket.Close();
      setupSocket();
    }
  }

  //read message from server
  public string readSocket() {
    if (!socketReady)
      return "";
    try {
      if (theStream.DataAvailable) {
        return theReader.ReadLine();
      }
    }
    catch (Exception e) {
      socketReady = false;
      theReader.Close();
      mySocket.Close();
      setupSocket();
    }
    return "";
  }
  
  //disconnect from the socket
  public void closeSocket() {
    if (!socketReady)
      return;
    theReader.Close();
    mySocket.Close();
    socketReady = false;
  }

  public void clearSocket() {
    while (theStream.DataAvailable) 
      theReader.ReadLine();
  }
  
  //keep connection alive, reconnect if connection lost
  public void maintainConnection(){
    if(!theStream.CanRead || !theStream.CanWrite) {
      socketReady = false;
      theReader.Close();
      mySocket.Close();
      setupSocket();
    }
  }
}