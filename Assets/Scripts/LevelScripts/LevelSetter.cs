using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour {

	[Header("Steps configuration")]
	public GameObject [] stepPrefabs;
    public int stepCount;
    public GameObject floor;
    public GameObject center;
    public GameObject walls;

	[Space(2)]
	[Header("Step distances")]
    public float ySpace = 4.0f;

	private int randomPrefabIndex;
	private Vector3 lastStepPosition;

    [Space(2)]
    [Header("Rotation around")]
    public float angle = 0f;
    Vector3 aroundPoint = new Vector3(0, 0, 0);
    Vector3 axis = Vector3.down;
    float r, R;
    float lastStepXScale;
    float scaleY;

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
		lastStepPosition = new Vector3 (3, 1, 0);
        r = center.transform.localScale.x / 2;
        R = floor.transform.localScale.x / 2;

        SetTower();
        SetWalls();
        RandomStepSet();
    }

	void RandomStepSet()
	{
		for (int i = 0; i < stepCount; i++) {
			randomPrefabIndex = Random.Range (0, stepPrefabs.Length);
            lastStepXScale = stepPrefabs[randomPrefabIndex].transform.localScale.x;

            GameObject stepClone;
            stepClone = Instantiate(stepPrefabs[randomPrefabIndex],
                                    new Vector3(Random.Range(r+ (lastStepXScale),R-(lastStepXScale)), 
                                                lastStepPosition.y + ySpace,
                                                0),
                                    Quaternion.Euler(0,0,0)) as GameObject;

            aroundPoint = new Vector3(0, stepClone.transform.position.y, 0);
            stepClone.transform.RotateAround(aroundPoint, axis, angle);
            angle += 45;
			stepClone.transform.parent = transform;
			lastStepPosition = new Vector3 (stepClone.transform.position.x, stepClone.transform.position.y, stepClone.transform.position.z);

		}
	}

    void SetTower()
    {

        float scaleX = center.transform.localScale.x;
        scaleY = stepCount * ySpace / 2;
        float scaleZ = center.transform.localScale.z;

        center.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        center.transform.position = new Vector3(0, scaleY, 0);
    }

    void SetWalls()
    {
        for (int i = 0; i <= (int)scaleY*2; i+=6)
        {
            GameObject wallClone;
            wallClone = Instantiate(walls, new Vector3(0, i+3, 0), Quaternion.identity) as GameObject;
            wallClone.transform.parent = transform;
        }
    }
}
