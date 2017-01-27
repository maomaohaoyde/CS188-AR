using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class refugeeController : MonoBehaviour {
	private GameObject DoorRef;
	private spawn DoorControllerRef;
	enum SceneState{running, climbing,climbingToTop, stand};
	private SceneState currentState;

	//Number over the head of the attacker
	private int life;

	//Get control of spawnController
	private GameObject spawnRef;
	private spawn spawnControllerRef;


	private GameObject can;
	private Transform liferotation;
	private Vector3 canLocation;
	private float running_speed=8.0f;
	private float climbing_speed=3.0f;
	private float landing_speed=2.0f;
	private GameObject top_target;
	private bool saved=false;



	public Vector3 offset;

	//	public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;

	// This allows use to set how powerful the swipe will be
	//public float ForceMultiplier = 1.0f;

	private Animator mAnimator;
	// Use this for initialization
	void Start () {
		top_target = GameObject.FindGameObjectWithTag ("Target");
		//Get control of spawnController
		spawnRef = GameObject.Find("spawnController");
		spawnControllerRef = spawnRef.GetComponent<spawn>();

		mAnimator = GetComponent<Animator> ();
		can = GameObject.FindGameObjectWithTag ("can");	
		//Rotate towards the can
		Vector3 relativePos = can.transform.position - transform.position;
		relativePos.y = 0;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		transform.rotation = rotation;

		//Position of the can

		canLocation = can.transform.position;
		canLocation.y = (float)0.5;


		currentState = SceneState.running;

		DoorRef = GameObject.Find("spawnController");
		DoorControllerRef = DoorRef.GetComponent<spawn>();

	}

	// Update is called once per frame
	void Update () {
		
		//check if the attacker is dead
		if (saved) {
			DoorControllerRef.updateText ();
			saved = false;
			Destroy (gameObject, 4);
			spawnControllerRef.DecreaseRefugee();

		}

		switch (currentState) {
		case SceneState.running:
			MoveTo (canLocation, running_speed);
			break;
		case SceneState.climbing:
			MoveTo (transform.position + offset, climbing_speed);
			break;
		case SceneState.climbingToTop:
			MoveTo (top_target.transform.position, landing_speed);
			break;

		case SceneState.stand:

			break;
		}
		// move the attacker to the can


	}

	void MoveTo(Vector3 targetPos, float speed)
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

	}
	public void arriveAtBottom()
	{
		mAnimator.SetBool ("arriveAtBottom",true);
		currentState = SceneState.climbing;
	}
	public void arriveAtTop()
	{
		mAnimator.SetBool ("arriveAtBottom", false);
		mAnimator.SetBool ("arriveAtTop", true);
		saved = true;
		currentState = SceneState.climbingToTop;
	}

	public void standUp()
	{
		mAnimator.SetBool ("arriveAtTop", false);
		mAnimator.SetBool ("standUp", true);
		currentState = SceneState.stand;
	}

	public void change()
	{
		spawnControllerRef.DecreaseRefugee ();
		spawnControllerRef.addEnemy (gameObject);
		Destroy (gameObject);
	}


}
