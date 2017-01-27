using UnityEngine;
using System.Collections;

public class topTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider col)
	{
		
		if (col.gameObject.tag == "Enemy")
			col.gameObject.GetComponent<attackerController> ().arriveAtTop ();
		else if (col.gameObject.tag == "Refugee") 
			col.gameObject.GetComponent<refugeeController> ().arriveAtTop ();

	}
}
