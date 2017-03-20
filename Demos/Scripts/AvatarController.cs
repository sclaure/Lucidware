using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {

	public AvatarMapper avatarMapper;
	public SocketScript socketScript;
	private int thumb, index, middle, ring, pinky;

	// Use this for initialization
	void Start () {
		avatarMapper = gameObject.GetComponent<AvatarMapper>();
		if(!avatarMapper)
		{
			avatarMapper = gameObject.AddComponent<AvatarMapper>();
		}
		socketScript = gameObject.GetComponent<SocketScript>();
		if(!socketScript)
		{
			socketScript = gameObject.AddComponent<SocketScript>();
		}
		//Application.LoadLevel("Demo");
		//Application.LoadLevel (0);
	}
	
	// Update is called once per frame
	void Update () {
		//print (Application.loadedLevel);
		avatarMapper.UpdateRightHand(socketScript.ThumbU, socketScript.ThumbB, socketScript.PointFingU, socketScript.PointFingB, socketScript.MidFingU, socketScript.MidFingB, socketScript.RingFingU, socketScript.RingFingB, socketScript.PinkFingU, socketScript.PinkFingB);
		avatarMapper.UpdateRightArmRotations(socketScript.HandRot, socketScript.LowArmRot, Quaternion.Euler(0,0,180f)*socketScript.UpArmRot*Quaternion.Euler(0,0,180f));
	}
}
