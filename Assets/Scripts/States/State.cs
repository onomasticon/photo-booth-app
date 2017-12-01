using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State : MonoBehaviour
{
	public UnityEvent Started;

	[SerializeField]
	protected State next;

	[SerializeField]
	protected State error;

	protected virtual void Start()
	{
		Started.Invoke();
	}

	public void Proceed()
	{
		gameObject.SetActive(false);
		next.gameObject.SetActive(true);
	}

	public void Error()
	{
		gameObject.SetActive(false);
		error.gameObject.SetActive(true);
	}
}