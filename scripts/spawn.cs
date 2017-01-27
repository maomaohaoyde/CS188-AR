using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class spawn: MonoBehaviour {
	
	private GameObject[] list;
	public GameObject[] enemies;
	public GameObject refugee;
	private int amount=0;
	private int refugee_amount = 0;
	public int max;
	private Vector3 spawnPoint;
	public int SPX_MIN;
	public int SPX_MAX;
	public float SPY;
	public int SPZ_MIN;
	public int SPZ_MAX;
	public int spawn_frequency;
	public int refugee_frequency;
	private List<GameObject> clones;
	private List<GameObject> refugee_clones;
	public GameObject terrain;
	private GameObject can;
	public AudioClip PlaySound;
	private AudioSource mPlaySource;
	public AudioClip vicSound;
	private AudioSource vicSource;
	private int savecounter = 0;
	public Text refugeeText;
	private Renderer rend;
	void Start (){
		can = GameObject.FindGameObjectWithTag ("can");	
		clones = new List<GameObject>();
		refugee_clones = new List<GameObject>();
		mPlaySource = gameObject.AddComponent<AudioSource> ();
		mPlaySource.clip = PlaySound;
		mPlaySource.Play ();
		vicSource = gameObject.AddComponent<AudioSource> ();
		vicSource.clip = vicSound;
	}



	// Update is called once per frame
	void Update () {

		if (amount < max) {
			if (Application.loadedLevel == 1)
				InvokeRepeating ("spawnEnemy", spawn_frequency, 2000F);
			else
				InvokeRepeating ("spawnEnemy", 2*spawn_frequency, 2000F);
		}

		if (refugee_amount < 5) {
			InvokeRepeating ("spawnRefugee", refugee_frequency, 2000F);
		}
		list = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (var attacker in list) {
			if (attacker.transform.position.z > can.transform.position.z) {
				rend = attacker.GetComponent<Renderer> ();
				rend.enabled = false;
			}
		}

	}



	void spawnEnemy ()
	{	GameObject clone;
		int lifeNum = Random.Range (2,5);
		attackerController aController;
		do {
			spawnPoint.x = Random.Range (SPX_MIN, SPX_MAX);
			spawnPoint.y = SPY;
			spawnPoint.z = Random.Range (SPZ_MIN, SPZ_MAX);
		} while(Physics.CheckSphere (spawnPoint, 0.2f));
		int index = Random.Range (0, 3);
		clone=(GameObject)Instantiate(enemies[index], spawnPoint, Quaternion.identity);
		clone.transform.parent = terrain.transform;
		//clone.transform.LookAt (can.transform);
		CancelInvoke("spawnEnemy");
		aController = clone.gameObject.GetComponent<attackerController>();
		aController.setLife (lifeNum);
		amount++;
		clones.Add(clone);
	}

	public void addEnemy (GameObject touched_refugee)
	{	GameObject clone;
		int lifeNum = Random.Range (2,10);
		attackerController aController;
		spawnPoint = touched_refugee.transform.position;
		int index = Random.Range (0, 3);
		clone=(GameObject)Instantiate(enemies[index], spawnPoint, Quaternion.identity);
		clone.transform.parent = terrain.transform;
		//clone.transform.LookAt (can.transform);
		aController = clone.gameObject.GetComponent<attackerController>();
		aController.setLife (lifeNum);
		amount++;
		clones.Add(clone);
	}

	void spawnRefugee ()
	{	GameObject clone;
		do {
			spawnPoint.x = Random.Range (SPX_MIN, SPX_MAX);
			spawnPoint.y = SPY;
			spawnPoint.z = Random.Range (SPZ_MIN, SPZ_MAX);
		} while(Physics.CheckSphere (spawnPoint, 0.02f));
		clone=(GameObject)Instantiate(refugee, spawnPoint, Quaternion.identity);
		clone.transform.parent = terrain.transform;
		//clone.transform.LookAt (can.transform);
		refugee_amount++;
		refugee_clones.Add(clone);
		CancelInvoke("spawnRefugee");
	}

	public void DecreaseAmount(){
		amount--;
	}

	public void DecreaseRefugee(){
		refugee_amount--;
	}

	public void updateText()
	{
		savecounter++;
		refugeeText.text = savecounter.ToString ();
		if (savecounter >= 6 && Application.loadedLevel == 1) {
			SceneManager.LoadScene (2);	

		} else if (savecounter >= 6 && Application.loadedLevel == 3) {
			SceneManager.LoadScene (4);
		
		}
	}
}
