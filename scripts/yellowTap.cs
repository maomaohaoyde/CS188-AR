using UnityEngine;
using System.Collections;

public class yellowTap : MonoBehaviour {
//	public AudioClip punchSound;
//	private AudioSource mPunchSource;
	private attackerController Controller;
	private GameObject attacker;
	public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;


	void Start()
	{
//		mPunchSource = gameObject.AddComponent<AudioSource> ();
//		mPunchSource.clip = punchSound;
	}

	protected virtual void OnEnable()
	{
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerTap += OnFingerTap;
	}

	protected virtual void OnDisable()
	{
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerTap -= OnFingerTap;

	}

	public void OnFingerTap(Lean.LeanFinger finger)
	{
		
		// Raycast information
		var ray = finger.GetStartRay ();
		var hit = default(RaycastHit);

		// Was this finger pressed down on a collider?
		if (Physics.Raycast (ray, out hit, float.PositiveInfinity, LayerMask) == true) {
			// Was that collider this one?
			if (hit.collider.gameObject == gameObject) {
				Debug.Log ("You tapped");
//				mPunchSource.Play ();
				attacker = this.gameObject;
				Controller = attacker.GetComponent<attackerController> ();
				Controller.hurt ();
			}
		}
	}



}
