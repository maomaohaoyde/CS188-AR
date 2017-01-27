using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public Button tutorialText;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void tPress()
	{ 	quitMenu.enabled = true;
	 	startText.enabled = false;
		exitText.enabled = false;
		tutorialText.enabled = false;
		gameObject.GetComponent<Canvas>().enabled = false;
	}

	public void tnoPress()
	{ 	
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		tutorialText.enabled = true;
		gameObject.GetComponent<Canvas>().enabled = true;
	}

	public void StartLevel()
	{
		SceneManager.LoadScene(1);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
