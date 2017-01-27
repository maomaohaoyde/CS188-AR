using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class winController : MonoBehaviour {
	public AudioClip punchSound;
	private AudioSource mPunchSource;

	// Use this for initialization
	void Start () {
		mPunchSource = gameObject.AddComponent<AudioSource> ();
		mPunchSource.clip = punchSound;
		mPunchSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!mPunchSource.isPlaying && Application.loadedLevel == 2)
			SceneManager.LoadScene (3);
		else if (!mPunchSource.isPlaying && Application.loadedLevel == 4)
			SceneManager.LoadScene (0);
		else if (!mPunchSource.isPlaying && Application.loadedLevel == 5)
			SceneManager.LoadScene (0);
	}

}
