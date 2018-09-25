using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour {

	[Header("Steps configuration")]
	public GameObject [] stepPrefabs;
	public int stepCount;
	[Space(2)]
	[Header("Step distances")]
	public float xmin = 0.1f;
	public float xmax = 0.1f;
	public float ymin = 0.1f;
	public float ymax = 0.1f;
	public float zmin = 0.1f;
	public float zmax = 0.1f;
	[Space(5)]
	[Header("Movement speed")]
	public float xSpeedMin = 0.1f;
	public float xSpeedMax = 1f;
	public float ySpeedMin = 0.1f;
	public float ySpeedMax = 1f;
	public float zSpeedMin = 0.1f;
	public float zSpeedMax = 1f;

	[Space(2)]
	[Header("Movement distance")]
	public float xMinDistance = -1f;
	public float xMaxDistance = 1f;
	public float yMinDistance = -1f;
	public float yMaxDistance = 1f;

	private float xRange, yRange, zRange;
	private int randomPrefabIndex;
	private Vector3 lastStepPosition;

	public static LevelSetter instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	void Start()
	{
		lastStepPosition = new Vector3 (0, 0, 0);
		RandomStepSet ();
	}

	void RandomStepSet()
	{
		for (int i = 0; i < stepCount; i++) {
			randomPrefabIndex = Random.Range (0, stepPrefabs.Length);

			if (i == 0)
				xRange = yRange = zRange = 0;
			
			GameObject stepClone;
			stepClone = Instantiate (stepPrefabs [randomPrefabIndex], 
				new Vector3(lastStepPosition.x + xRange,lastStepPosition.y + yRange, lastStepPosition.z +zRange),
				Quaternion.identity) as GameObject;
			stepClone.transform.parent = transform;
			lastStepPosition = new Vector3 (stepClone.transform.position.x, stepClone.transform.position.y, stepClone.transform.position.z);

			xRange = Random.Range (xmin, xmax);
			yRange = Random.Range (ymin, ymax) + stepClone.transform.localScale.y;
			zRange = Random.Range (zmin, zmax) + stepClone.transform.localScale.z;
		}
	}
}
