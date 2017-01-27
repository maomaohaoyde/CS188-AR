using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PauseController : MonoBehaviour {
	public bool paused;
	public Button Pause;
	// Use this for initialization
	void Start () {
		paused = false;
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void pause(){
		paused = !paused;
		if (paused)
			Time.timeScale = 0;
		else if (!paused)
			Time.timeScale = 1;
	}
}
