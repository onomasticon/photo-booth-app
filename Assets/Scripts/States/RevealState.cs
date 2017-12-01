using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealState : State
{
	[SerializeField]
	private Image pictureFrame;

	protected override void Start()
	{
		pictureFrame.gameObject.SetActive(true);
	}
}