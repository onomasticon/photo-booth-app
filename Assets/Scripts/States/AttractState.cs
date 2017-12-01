using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttractState : State
{
	[SerializeField]
	private Image pictureFrame;

	void Start()
	{
		pictureFrame.gameObject.SetActive(false);
	}
}
