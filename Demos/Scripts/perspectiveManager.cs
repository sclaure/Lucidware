using UnityEngine;
using System.Collections;
using System;

public class perspectiveManager : MonoBehaviour {

	public OVRCameraRig ovrCameraRig;

	void Update() {
		if (Input.GetKeyDown(KeyCode.P)) {
			print("p key was released");
			ovrCameraRig.firstperson = !ovrCameraRig.firstperson;
		}
	}
}