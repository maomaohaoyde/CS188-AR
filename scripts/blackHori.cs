using UnityEngine;
using System.Collections;


public class blackHori : MonoBehaviour {
//	public AudioClip punchSound;
//	private AudioSource mPunchSource;

	// Use this for initialization

	private attackerController Controller;
	private GameObject attacker;
	public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;

	// This allows use to set how powerful the swipe will be
	void Start()
	{
//		mPunchSource = gameObject.AddComponent<AudioSource> ();
//		mPunchSource.clip = punchSound;
	}

	protected virtual void OnEnable()
	{
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
	}

	protected virtual void OnDisable()
	{
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;

	}

	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		// Raycast information
		var ray = finger.GetStartRay();
		var hit = default(RaycastHit);

		// Was this finger pressed down on a collider?
		if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
		{
			// Was that collider this one?
			if (hit.collider.gameObject == gameObject)
			{
				var swipe = finger.SwipeDelta;

				if (swipe.x < -Mathf.Abs(swipe.y)|| swipe.x > Mathf.Abs(swipe.y))
				{
					Debug.Log("You swiped");
//					mPunchSource.Play ();
					attacker = this.gameObject;
					Controller = attacker.GetComponent<attackerController>();
					Controller.hurt ();
				}
			}

	}
}

}