using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour {

	void Start()
	{
		SetColor (gameObject.GetComponent<MeshRenderer> ());
	}

	void SetColor(MeshRenderer renderer)
	{
		renderer.material.color = ColorPallet.instance.GetRandomColor ();
	}
}
