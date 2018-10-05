using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepMovement : MonoBehaviour {

	float xSpeedLocal = 0.1f;
	float ySpeedLocal = 0.1f;

	float xMinDistanceLocal = 0.1f;
	float yMinDistanceLocal = 0.1f;
	float xMaxDistanceLocal = 0.1f;
	float yMaxDistanceLocal = 0.1f;

	bool xMovementLocal = false;
	bool yMovementLocal = false;

	[SerializeField]
	bool xIncreasing;
	[SerializeField]
	bool yIncreasing;

	float newX;
	float newY;

	Vector3 pos;
	Vector3 startPos;
	AnimationCurve xAnimCurveLocal;
	AnimationCurve yAnimCurveLocal;
	public void Init()
	{

		xMinDistanceLocal = LevelSetter.instance.xMinDistance;
		yMinDistanceLocal = LevelSetter.instance.yMinDistance;
		xMaxDistanceLocal = LevelSetter.instance.xMaxDistance;
		yMaxDistanceLocal = LevelSetter.instance.yMaxDistance;

		xMovementLocal = (Random.Range (0, 2) == 0);
		if (!xMovementLocal)
			yMovementLocal = (Random.Range (0, 2) == 0);

		xSpeedLocal = Random.Range (LevelSetter.instance.xSpeedMin,LevelSetter.instance.xSpeedMax);
		ySpeedLocal = Random.Range (LevelSetter.instance.ySpeedMin, LevelSetter.instance.ySpeedMax);

		pos = transform.localPosition;
		startPos = transform.localPosition;

		newX = pos.x;
		newY = pos.y;

		xIncreasing = true;
		yIncreasing = true;
	}

	void Awake ()
	{
		Init ();
	}

	void Update()
	{
		MoveX (xMovementLocal);
	}

	void MoveX(bool canMove)
	{
		if (canMove) {
			pos = transform.localPosition;

			if(newX < xMaxDistanceLocal && xIncreasing)
				newX += 0.1f * xSpeedLocal;
			else if (newX >= xMaxDistanceLocal && xIncreasing)
				{
					newX = xMaxDistanceLocal;
					xIncreasing = false;
				}

			if (newX > xMinDistanceLocal && !xIncreasing)
				newX -= 0.1f * xSpeedLocal;
			else if (newX <= xMinDistanceLocal && !xIncreasing) {
				newX = xMinDistanceLocal;
				xIncreasing = true;
			}

			transform.localPosition = new Vector3 (newX, pos.y, pos.z);
		}
	}

	void MoveY(bool canMove)
	{
		if(canMove) {
			pos = transform.localPosition;

			if(newY < yMaxDistanceLocal && yIncreasing)
				newY += 0.1f * ySpeedLocal;
			else if (newY >= yMaxDistanceLocal && yIncreasing)
			{
				newY = yMaxDistanceLocal;
				yIncreasing = false;
			}

			if (newY > yMinDistanceLocal && !yIncreasing)
				newY -= 0.1f * ySpeedLocal;
			else if (newY <= yMinDistanceLocal && !yIncreasing) {
				newY = yMinDistanceLocal;
				yIncreasing = true;
			}

			transform.localPosition = new Vector3 (pos.x, newY, pos.z);
		}
	}
}
