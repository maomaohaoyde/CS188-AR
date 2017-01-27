using UnityEngine;
using System.Collections;

public class refugeeTouch : MonoBehaviour {
	

	private refugeeController Controller;
	private GameObject refugee;
	public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;



	protected virtual void OnEnable()
	{

		Lean.LeanTouch.OnFingerTap += OnFingerTap;
	}

	protected virtual void OnDisable()
	{

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
				Debug.Log ("You touched");
				refugee = this.gameObject;
				Controller = refugee.GetComponent<refugeeController> ();
				Controller.change ();
			}
		}
	}
}










