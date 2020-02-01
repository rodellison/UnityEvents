using System.Collections;
using UnityEngine;
using ScriptableObjects;

public class MainScript : MonoBehaviour
{

	public GameEvent MyGameEvent;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(PeriodicEventFire());
	}


	IEnumerator PeriodicEventFire()
	{
		while (true)
		{
			yield return new WaitForSeconds(2.0f);
			MyGameEvent.Raise();
		}
	}
}
