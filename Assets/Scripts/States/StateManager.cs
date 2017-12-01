using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
	public State First;

	private State[] states;

	void Awake()
	{
		states = GetComponentsInChildren<State>();

		Debug.Log("StateManager: # states found: " + states.Length);

		foreach (var state in states)
		{
			state.gameObject.SetActive(false);
		}

		First.gameObject.SetActive(true);
	}
}