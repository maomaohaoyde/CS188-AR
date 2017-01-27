using UnityEngine;
using System.Collections;

public class attackerController : MonoBehaviour {
	//Different state
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

	public AudioClip FallSound;
	private AudioSource mFallSource;
	public AudioClip punchSound;
	private AudioSource mPunchSource;


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

		mFallSource = gameObject.AddComponent<AudioSource> ();
		mFallSource.clip = FallSound;
		mPunchSource = gameObject.AddComponent<AudioSource> ();
		mPunchSource.clip = punchSound;
	}
	
	// Update is called once per frame
	void Update () {
		//rotate the text towards the camera
		Vector3 relativePos = -(Camera.main.transform.position - transform.FindChild ("life").position) ;
		Quaternion rotation = Quaternion.LookRotation(relativePos);
		transform.FindChild("life").rotation = rotation;

		//Update the number of lives
		GetComponentInChildren<TextMesh> ().text = "" + life;

		//check if the attacker is dead
		if (life <= 0) {
			MeshRenderer text;
			text = transform.FindChild ("life").GetComponent<MeshRenderer>();
			text.enabled = false;
			Rigidbody rigidbody = gameObject.GetComponent<Rigidbody> ();
			rigidbody.isKinematic = false;
			Animator animator = gameObject.GetComponent<Animator> ();
			animator.enabled = false;
			Destroy(gameObject, 3.0f);
			spawnControllerRef.DecreaseAmount();
		
		
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



	}
	public void setLife(int lifeValue)
	{
		life = lifeValue;
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
		currentState = SceneState.climbingToTop;
	}

	public void standUp()
	{
		mAnimator.SetBool ("arriveAtTop", false);
		mAnimator.SetBool ("standUp", true);
		currentState = SceneState.stand;
	}
		
	public void hurt()
	{
		if (life > 0) {
			if (life == 1)
				mFallSource.Play ();
			else if (life > 1)
				mPunchSource.Play ();
			life--;
		}
	}
}
