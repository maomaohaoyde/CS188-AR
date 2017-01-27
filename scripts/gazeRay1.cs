using UnityEngine;
using System.Collections;

public class gazeRay1 : MonoBehaviour {
	private RaycastHit hit;
	private Ray ray;
	private GameObject holyblast;
	//private spawn SpawnFunc;
	//private GameObject SpawnController;

	// Use this for initialization
	void Start () {
		//SpawnController = GameObject.Find ("spawnController");
		//SpawnFunc = SpawnController.GetComponent<spawn> ();

	}
	
	// Update is called once per frame
	void Update () {
		 GameObject[] attackerList; 
		attackerList = GameObject.FindGameObjectsWithTag("Enemy");
		ray= Camera.main.ScreenPointToRay (new Vector3(Screen.width*0.5f,Screen.height*0.5f,0));
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			foreach (var attacker in attackerList)
		{

//				if (hit.collider.gameObject == attacker.gameObject) {
////					Destroy (attacker.gameObject);
//					holyblast = attacker.Find("Holy Blast");
//					holyblast.GetComponent<ParticleSystem>().enableEmission = true;
//
//				}
			
				}
	}
}
