using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;

public class SocketScript : MonoBehaviour {
  
  //variables
  private TCPConnection myTCP;
  private string serverMsg;
  public Quaternion HandRot = Quaternion.identity;
  public Quaternion UpArmRot = Quaternion.identity;
  public Quaternion LowArmRot = Quaternion.identity;
  public Vector3 HandLoc;
  public Vector3 LowArmLoc;
  public Vector3 UpArmLoc;
  public int ThumbU = 0;
  public int PointFingU = 0;
  public int MidFingU = 0;
  public int RingFingU = 0;
  public int PinkFingU = 0;
  public int ThumbB = 0;
  public int PointFingB = 0;
  public int MidFingB = 0;
  public int RingFingB = 0;
  public int PinkFingB = 0;
  public bool written = false;

  private StreamReader fileStream;
  private string filename = @"SampleQuaternionOutput.txt";
  private char[] delims = new char[] {' '};
  private string handshake_constant = "$";
  private string goodbye_constant = "#";

  void Awake() {
    //add a copy of TCPConnection to this game object
    myTCP = gameObject.AddComponent<TCPConnection>();
    //fileStream = new StreamReader(filename);
  }

  void Start () {
    Debug.Log("Attempting to connect..");
    myTCP.setupSocket();
  }

  void LateUpdate ()
  {
    if(myTCP.socketReady) {
      myTCP.maintainConnection();
      UpdateFromSocket();
    }
    //else
      //UpdateFromTextfile();
  }

  void UpdateFromTextfile()
  {
    if(fileStream.EndOfStream) {
      return;
    }

    string currentline = fileStream.ReadLine();
    float[] floats_wrist = new float[4];
    float[] floats_lower = new float[4];
    float[] floats_upper = new float[4];
    currentline = currentline.Substring(2);
    int space;

    for(int i = 0; i < 3; i++)
    {
      space = currentline.IndexOf(' ');
      floats_wrist[i] = float.Parse(currentline.Substring(0, space - 1));
      currentline = currentline.Substring(space + 1);
    }
    floats_wrist[3] = float.Parse(currentline.Substring(0, currentline.IndexOf(']') - 1));

    currentline = currentline.Substring(currentline.IndexOf('[')+1);

    Debug.Log(floats_wrist);

    for(int i = 0; i < 3; i++)
    {
      space = currentline.IndexOf(' ');
      floats_lower[i] = float.Parse(currentline.Substring(0, space - 1));
      currentline = currentline.Substring(space + 1);
    }
    floats_lower[3] = float.Parse(currentline.Substring(0, currentline.IndexOf(']') - 1));

    currentline = currentline.Substring(currentline.IndexOf('[')+1);

    for(int i = 0; i < 3; i++)
    {
      space = currentline.IndexOf(' ');
      floats_upper[i] = float.Parse(currentline.Substring(0, space - 1));
      currentline = currentline.Substring(space + 1);
    }
    floats_upper[3] = float.Parse(currentline.Substring(0, currentline.IndexOf(']') - 1));

    HandRot = new Quaternion(
      //floats_wrist[0],
      //floats_wrist[2],
      //floats_wrist[3],
      //floats_wrist[1]);
      floats_wrist[1], //x
      floats_wrist[2], //y
      floats_wrist[3], //z
      floats_wrist[0]); //w
    LowArmRot = new Quaternion(
      floats_lower[1],
      floats_lower[2],
      floats_lower[3],
      floats_lower[0]);
    UpArmRot = new Quaternion(
      floats_upper[1],
      floats_upper[2],
      floats_upper[3],
      floats_upper[0]);
  }

  void UpdateFromSocket () {
    if (!written) {
      written = true;
      myTCP.writeSocket("7");
      string handshake = myTCP.readSocket();
      if(!(handshake.Equals(handshake_constant)))
      { 
        //Debug.Log("Missing handshake, start" + handshake);
        //myTCP.clearSocket();
        myTCP.maintainConnection();
        written = false;
        return;
      } else {
        //Debug.Log("Successful handshake");
      }
      string quatHand =   myTCP.readSocket();
      string quatLowArm = myTCP.readSocket();
      string quatUpArm =  myTCP.readSocket();
      string sLocHand =   myTCP.readSocket();
      string sLocLowArm = myTCP.readSocket();
      string sLocUpArm =  myTCP.readSocket();
      string Fingers =    myTCP.readSocket();
      string goodbye =    myTCP.readSocket();

      if(!(goodbye.Equals(goodbye_constant)))
      { 
        Debug.Log("Missing Data, goodbye was " + goodbye);
        //myTCP.clearSocket();
        myTCP.maintainConnection();
        written = false;
        return;
      } else {
        //Debug.Log("Successful read");
      }

      if(!(quatHand.Length   > 0 &&
           quatLowArm.Length > 0 &&
           quatUpArm.Length  > 0 && 
           sLocHand.Length   > 0 &&
           sLocLowArm.Length > 0 &&
           sLocUpArm.Length  > 0 &&
           Fingers.Length    > 0))
        return;
      /*
      if(quatHand.Length > 0)
      {
        Debug.Log(quatHand);
        Debug.Log("0 : " + quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries)[0]);
        Debug.Log("1 : " + quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries)[1]);
        Debug.Log("2 : " + quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries)[2]);
        Debug.Log("3 : " + quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries)[3]);
      }
      */

      /*
      if(quatLowArm.Length > 0)
      {
        Debug.Log(quatLowArm);
        Debug.Log("0 : " + quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[0]);
        Debug.Log("1 : " + quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[1]);
        Debug.Log("2 : " + quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[2]);
        Debug.Log("3 : " + quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[3]);
      }
      */

      /*
      if(quatUpArm.Length > 0)
      {
        Debug.Log(quatUpArm);
        Debug.Log("0 : " + quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[0]);
        Debug.Log("1 : " + quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[1]);
        Debug.Log("2 : " + quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[2]);
        Debug.Log("3 : " + quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[3]);
      }
      */


      if(quatHand.Length > 0 && quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries).Length == 4)
      HandRot = new Quaternion(
        float.Parse(quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries)[1]),
        float.Parse(quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries)[2]),
        float.Parse(quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries)[3]),
        float.Parse(quatHand.Split(delims, StringSplitOptions.RemoveEmptyEntries)[0]));
      if(quatLowArm.Length > 0 && quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries).Length == 4)
      LowArmRot = new Quaternion(
        float.Parse(quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[1]),
        float.Parse(quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[2]),
        float.Parse(quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[3]),
        float.Parse(quatLowArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[0]));
      if(quatUpArm.Length > 0 && quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries).Length == 4)
      UpArmRot = new Quaternion(
        float.Parse(quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[1]),
        float.Parse(quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[2]),
        float.Parse(quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[3]),
        float.Parse(quatUpArm.Split(delims, StringSplitOptions.RemoveEmptyEntries)[0]));
			string[] fingers_parsed = Fingers.Split(delims, StringSplitOptions.RemoveEmptyEntries);
			ThumbU =     byte.Parse(fingers_parsed[0], System.Globalization.NumberStyles.HexNumber);
			ThumbB =     byte.Parse(fingers_parsed[1], System.Globalization.NumberStyles.HexNumber);
			PointFingU = byte.Parse(fingers_parsed[2], System.Globalization.NumberStyles.HexNumber);
			PointFingB = byte.Parse(fingers_parsed[3], System.Globalization.NumberStyles.HexNumber);
			MidFingU =   byte.Parse(fingers_parsed[4], System.Globalization.NumberStyles.HexNumber);
			MidFingB =   byte.Parse(fingers_parsed[5], System.Globalization.NumberStyles.HexNumber);
			RingFingU =  byte.Parse(fingers_parsed[6], System.Globalization.NumberStyles.HexNumber);
			RingFingB =  byte.Parse(fingers_parsed[7], System.Globalization.NumberStyles.HexNumber);
			PinkFingU =  byte.Parse(fingers_parsed[8], System.Globalization.NumberStyles.HexNumber);
			PinkFingB =  byte.Parse(fingers_parsed[9], System.Globalization.NumberStyles.HexNumber);
      written = false;
    }
  }
}