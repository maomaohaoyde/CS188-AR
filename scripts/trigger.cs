using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		// Close the door only if the intended GameObject entered this trigger
		if (col.gameObject.tag == "Enemy")
			col.gameObject.GetComponent<attackerController>().arriveAtBottom();
		else if (col.gameObject.tag == "Refugee")
			col.gameObject.GetComponent<refugeeController>().arriveAtBottom();
	}

	// Called when any GameObject leaves this trigger's collider


}
