using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject optionsMenu;
	public Button startGameButton;

	void OnEnable()
	{
		startGameButton.Select ();	
	}

	public void StartGame()
	{
		SceneManager.LoadScene (1);
	}

	public void Options()
	{
		gameObject.SetActive (false);
		optionsMenu.SetActive (true);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
