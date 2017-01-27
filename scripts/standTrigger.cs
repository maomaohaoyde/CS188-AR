using UnityEngine;
using System.Collections;

public class standTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Enemy")
			col.gameObject.GetComponent<attackerController>().standUp();
	}
}
