using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardTrigger : MonoBehaviour
{
	public UnityEvent Triggered;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Triggered.Invoke();
		}
	}
}