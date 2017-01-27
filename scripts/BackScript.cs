using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour {
	public Button backButton;
	// Use this for initialization
	void Start () {
		backButton = backButton.GetComponent<Button> ();
		backButton.enabled = true;
	}

	// Update is called once per frame
	void Update () {


	}
	public void goback (){
		SceneManager.LoadScene(0);

	}



}