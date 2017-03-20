using UnityEngine;
using System.Collections;

public class grabBall : MonoBehaviour {

	public AvatarMapper avatarMapper;

	public SocketScript socketScript;

	private Vector3 oldWristPos0;
	private Vector3 oldWristPos1;
	private Vector3 oldWristPos2;
	private Vector3 oldWristPos3;
	private Vector3 oldWristPos4;
	private Vector3 oldWristPos5;
	private Vector3 oldWristPos6;
	private Vector3 oldWristPos7;
	private Vector3 oldWristPos8;
	private Vector3 oldWristPos9;
	private Vector3 oldWristPos10;
	private Vector3 oldWristPos11;
	private Vector3 oldWristPos12;
	private Vector3 oldWristPos13;
	private Vector3 oldWristPos14;
	private Vector3 oldWristPos15;
	private Vector3 oldWristPos16;
	private Vector3 oldWristPos17;
	
	private bool grab;

	private Vector3 ballPosition;
	private Quaternion ballRotation;
	private Rigidbody ballRidgidBody;

	// Update is called once per frame
	void OnGUI () {
		Event e = Event.current;
		if (e.isKey && !grab)
		{
			if(e.keyCode == KeyCode.Space)
			{
				transform.position = ballPosition;
				transform.rotation = ballRotation;
				ballRidgidBody.angularVelocity = Vector3.zero;
				ballRidgidBody.velocity = Vector3.zero;
			}
		}
	}


	// Use this for initialization
	void Start () {
		ballPosition = transform.position;
		ballRotation = transform.rotation;
		ballRidgidBody = gameObject.GetComponent<Rigidbody>();
		socketScript = gameObject.GetComponent<SocketScript>();

		if(!socketScript)
		{
			socketScript = gameObject.AddComponent<SocketScript>();
		}

		avatarMapper = gameObject.GetComponent<AvatarMapper>();
		if(!avatarMapper)
		{
			avatarMapper = gameObject.AddComponent<AvatarMapper>();
		}

		grab = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = GameObject.Find("Bip01 R Finger2").transform.position;
		oldWristPos17 = oldWristPos16;
		oldWristPos16 = oldWristPos15;
		oldWristPos15 = oldWristPos14;
		oldWristPos14 = oldWristPos13;
		oldWristPos13 = oldWristPos12;
		oldWristPos12 = oldWristPos11;
		oldWristPos11 = oldWristPos10;
		oldWristPos10 = oldWristPos9;
		oldWristPos9 = oldWristPos8;
		oldWristPos8 = oldWristPos7;
		oldWristPos7 = oldWristPos6;
		oldWristPos6 = oldWristPos5;
		oldWristPos5 = oldWristPos4;
		oldWristPos4 = oldWristPos3;
		oldWristPos3 = oldWristPos2;
		oldWristPos2 = oldWristPos1;
		oldWristPos1 = oldWristPos0;
		oldWristPos0 = newPos;
		Vector3 vel = newPos - oldWristPos17;
		if ((socketScript.ThumbU >= 0xa0) && (socketScript.MidFingU >= 0xa0) && (socketScript.RingFingU >= 0xa0)){
			transform.position = newPos;
			grab = true;
		}
		else{
			if (grab == true){
				Debug.Log(vel);
				GetComponent<Rigidbody>().velocity = 30*vel;
				grab = false;
			}
		}

	}

	//(socketScript.Thumb >= 0xda) && (socketScript.MidFing >= 0xd3) && 
	//(socketScript.RingFing >= 0xd5)
}
