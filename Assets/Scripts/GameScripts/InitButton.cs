using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InitButton : MonoBehaviour {

		GameObject lastselect;
		//public Button startButton;
		void Start()
		{
			lastselect = new GameObject();
		EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
		}

		void Update () {
			if (EventSystem.current.currentSelectedGameObject == null)
			{
				EventSystem.current.SetSelectedGameObject(lastselect);
			}
			else
			{
				lastselect = EventSystem.current.currentSelectedGameObject;
			}
		}
}
