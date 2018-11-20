using System.Collections;
using UnityEngine;

public class HandleMove : MonoBehaviour
{
	public void MoveTheCube()
	{
		StartCoroutine(MoveTheCubeCoroutine());
	}

	IEnumerator MoveTheCubeCoroutine()
	{
		float startTime = Time.time;
		float duration = 2.0f;
		float t = 0.0f;
		Vector3 currentPosition = transform.position;
		float zVal = currentPosition.z;
		float xVal = currentPosition.x;

		while (t <= duration)
		{
			// This test looks at the cubes current location, and performs the SmoothStep move from point A to point B
			if ((xVal > 0 && zVal < 0) || (xVal < 0 && zVal > 0))
			{
				//Need to adjust Z
				t = (Time.time - startTime) / duration;
				transform.position = new Vector3(xVal,
					currentPosition.y,
					Mathf.SmoothStep(zVal, -zVal, t));
				yield return null;
			}
			else if ((xVal > 0 && zVal > 0) || (xVal < 0 && zVal < 0))
			{
				//Need to adjust X
				t = (Time.time - startTime) / duration;
				transform.position = new Vector3(Mathf.SmoothStep(xVal, -xVal, t),
					currentPosition.y,
					zVal);
				yield return null;
			}
		}
	}
}
