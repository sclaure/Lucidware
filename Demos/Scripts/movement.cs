
using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("a")){
			transform.position = transform.position + new Vector3((float)0.2,(float)0.0,(float)0.0);
		}
		if (Input.GetKey("d")){
			transform.position = transform.position + new Vector3((float)-0.2,(float)0.0,(float)0.0);
		}
		if (Input.GetKey("w")){
			transform.position = transform.position + new Vector3((float)0.0,(float)0.0,(float)-0.2);
		}
		if (Input.GetKey("s")){
			transform.position = transform.position + new Vector3((float)0.0,(float)0.0,(float)0.2);
		}
	}
}
