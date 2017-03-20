using UnityEngine;
using System.Collections;

public class AvatarMapper : MonoBehaviour{

	private Animator animator;
	private Transform wrist, lowerArm, upperArm;
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
  private Vector3 currWristPos;
  public Vector3 HandVelocity;
	private Quaternion wrist_initialRotation, lowerArm_initialRotation, upperArm_initialRotation;
	private struct Finger
	{
		public Transform prox;
		public Transform inte;
		public Transform dist;
	};

	private Finger thumb, index, middle, ring, pinky;
	private static Vector3 fullFlexProx_angle = new Vector3(0,0,-90);
  private static Vector3 fullFlexInte_angle = new Vector3(0,0,-65);
  private static Vector3 fullFlexDist_angle = new Vector3(0,0,-15);
	private static Vector3 noFlex_angle = new Vector3(0,0,0);
  private static Vector3 thumbFullFlex_angle = new Vector3(-40,60,-46);
	private const int fullFlex_steps = 12;


	void Awake () { //init
		animator = gameObject.GetComponent<Animator>();
		if(!animator)
		{
			Debug.LogError("Needs Avatar");
		}
		else if(!animator.isHuman)
			Debug.LogError("Needs to be humanoid");

		wrist = animator.GetBoneTransform(HumanBodyBones.RightHand);
		lowerArm = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
		upperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);


		//Vector3 initUpperArmEulerAngles = upperArm.eulerAngles;
// 		//Quaternion initAdjUpperArmQuaternion = Quaternion.Euler(-initUpperArmEulerAngles.x, initUpperArmEulerAngles.y, initUpperArmEulerAngles.z);
 

		wrist_initialRotation = wrist.rotation;
		lowerArm_initialRotation = lowerArm.rotation;
		upperArm_initialRotation = upperArm.rotation;


		//upperArm_initialRotation = initAdjUpperArmQuaternion;

		thumb.prox = animator.GetBoneTransform(HumanBodyBones.RightThumbProximal);
		thumb.inte = animator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate);
		thumb.dist = animator.GetBoneTransform(HumanBodyBones.RightThumbDistal);

		index.prox = animator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
		index.inte = animator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate);
		index.dist = animator.GetBoneTransform(HumanBodyBones.RightIndexDistal);

		middle.prox = animator.GetBoneTransform(HumanBodyBones.RightMiddleProximal);
		middle.inte = animator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate);
		middle.dist = animator.GetBoneTransform(HumanBodyBones.RightMiddleDistal);

		ring.prox = animator.GetBoneTransform(HumanBodyBones.RightRingProximal);
		ring.inte = animator.GetBoneTransform(HumanBodyBones.RightRingIntermediate);
		ring.dist = animator.GetBoneTransform(HumanBodyBones.RightRingDistal);

		pinky.prox = animator.GetBoneTransform(HumanBodyBones.RightLittleProximal);
		pinky.inte = animator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate);
		pinky.dist = animator.GetBoneTransform(HumanBodyBones.RightLittleDistal);
	}

	// Thumb - d4 -> e1
	// Pointer - ce -> dd
	// Middle - cc -> dc
	// Ring - ce -> da
	// Pinky - d8 -> eb

	public void UpdateRightHand(int thumb_flex_up, int thumb_flex_down, int index_flex_up, int index_flex_down, int middle_flex_up, int middle_flex_down, int ring_flex_up, int ring_flex_down, int pinky_flex_up, int pinky_flex_down)
	{
		UpdateThumb(thumb, thumb_flex_up, thumb_flex_down, 0x5e, 0xc9, 0x86, 0xd2);
		UpdateFinger(index, index_flex_up, index_flex_up, 0x7a, 0xc2, 0x7a, 0xc2);
		UpdateFinger(middle, middle_flex_up, middle_flex_down, 0x97, 0xf5, 0x88, 0xc1);
		UpdateFinger(ring, ring_flex_up, ring_flex_down, 0x95, 0xe4, 0x7c, 0xc1);
		UpdateFinger(pinky, pinky_flex_up, pinky_flex_down, 0x4c, 0xf7, 0x8d, 0xf2);
	}

	private void UpdateFinger(Finger finger, float flex_up, float flex_down, float min_up, float max_up, float min_down, float max_down)
	{
		finger.prox.localRotation = Quaternion.Euler(Vector3.Lerp(noFlex_angle, fullFlexProx_angle, ((flex_down-min_down)/(max_down-min_down))));
		finger.inte.localRotation = Quaternion.Euler(Vector3.Lerp(noFlex_angle, fullFlexInte_angle, ((flex_up-min_up)/(max_up-min_up))));
		finger.dist.localRotation = Quaternion.Euler(Vector3.Lerp(noFlex_angle, fullFlexDist_angle, ((flex_up-min_up)/(max_up-min_up))));
	}

  private void UpdateThumb(Finger finger, float flex_up, float flex_down, float min_up, float max_up, float min_down, float max_down) {
    finger.prox.localRotation = Quaternion.Euler(Vector3.Lerp(noFlex_angle, thumbFullFlex_angle, ((flex_down-min_down)/(max_down-min_down))));
    finger.inte.localRotation = Quaternion.Euler(Vector3.Lerp(noFlex_angle, fullFlexInte_angle, ((flex_up-min_up)/(max_up-min_up))));
    finger.dist.localRotation = Quaternion.Euler(Vector3.Lerp(noFlex_angle, fullFlexInte_angle, ((flex_up-min_up)/(max_up-min_up))));    
  }
	
  //This is where you need to add the calibration angle should go
	public void UpdateRightArmRotations(Quaternion new_wrist, Quaternion new_lowerArm, Quaternion new_upperArm) {
    //Debug.Log("wrist:" + new_wrist);
    //Debug.Log("lower:" + new_lowerArm);
    //Debug.Log("upper:" + new_upperArm);

    //Debug.Log("wrist dif:" + Quaternion.RotateTowards(wrist_initialRotation, new_wrist, 360.0f));
    //Debug.Log("lower dif:" + Quaternion.RotateTowards(lowerArm_initialRotation, new_lowerArm, 360.0f));
    //Debug.Log("upper dif:" + Quaternion.RotateTowards(upperArm_initialRotation, new_upperArm, 360.0f));


 	
    Quaternion adjUpperArmQuaternion = new Quaternion(-new_upperArm.y, new_upperArm.x, -new_upperArm.z, -new_upperArm.w);
    Quaternion adjLowerArmQuaternion = new Quaternion(-new_lowerArm.y, new_lowerArm.x, -new_lowerArm.z, -new_lowerArm.w);
    Quaternion adjWristQuaternion = new Quaternion(new_wrist.y, new_wrist.z, new_wrist.x, new_wrist.w);


    wrist.rotation    = animator.transform.localRotation * wrist_initialRotation * adjWristQuaternion;// ;
    lowerArm.rotation = animator.transform.localRotation * lowerArm_initialRotation * adjLowerArmQuaternion;//  ; //takes shit in from server
    upperArm.rotation = animator.transform.localRotation * upperArm_initialRotation * adjUpperArmQuaternion;// ;//upperArm_initialRotation * 
	
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
		oldWristPos0 = currWristPos;
		currWristPos = GameObject.Find("Bip01 R Finger2").transform.position;
    HandVelocity = currWristPos - oldWristPos17;
		//Debug.Log(currWristPos);
		//Debug.Log(HandVelocity);
	}

	public void UpdateRightArmPositions(Vector3 new_wrist, Vector3 new_lowerArm, Vector3 new_upperArm)
	{
		wrist.position = new_wrist;
		lowerArm.position = new_lowerArm;
		upperArm.position = new_upperArm;
	}
}
