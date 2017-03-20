using UnityEngine;
using System.Collections;

public class pinControl : MonoBehaviour {

	private Vector3 pinPosition;
	private Quaternion pinRotation;
	private Rigidbody pinRidgidBody;

	// Use this for initialization
	void Start () {
		pinPosition = transform.position;
		pinRotation = transform.rotation;
		pinRidgidBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void OnGUI () {
		Event e = Event.current;
		if (e.isKey)
		{
			if(e.keyCode == KeyCode.Space)
			{
				transform.position = pinPosition;
				transform.rotation = pinRotation;
				pinRidgidBody.angularVelocity = Vector3.zero;
				pinRidgidBody.velocity = Vector3.zero;
			}
		}
	}
}
