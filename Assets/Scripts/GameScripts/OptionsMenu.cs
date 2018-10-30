using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public GameObject mainMenu;
	public Slider volumeSlider;
	public Button backButton;

	public float volume;

	void OnEnable()
	{
		volumeSlider.Select ();
	}

	public void Back()
	{
		gameObject.SetActive (false);
		mainMenu.SetActive (true);
	}

	public void VolumeChange()
	{
		volume = volumeSlider.value;
	}
}
