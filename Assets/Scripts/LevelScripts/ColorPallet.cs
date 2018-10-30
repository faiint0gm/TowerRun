using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPallet : MonoBehaviour {

	public Color[] stepColors;
	public static ColorPallet instance = null;

	public void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}
	public Color GetRandomColor()
	{
		Color randomColor;
		if (stepColors.Length == 0)
			randomColor = new Color(0,0,0,1);
		else
			randomColor = stepColors[Random.Range (0, stepColors.Length - 1)];
		return randomColor;
	}
}
