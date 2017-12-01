using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Blinds : MonoBehaviour
{
	public UnityEvent BlindsOpened;
	public UnityEvent BlindsClosed;

	[SerializeField]
	private Animator animator;

	public void OnOpenAnimationComplete()
	{
		BlindsOpened.Invoke();
	}

	public void OnCloseAnimationComplete()
	{
		BlindsClosed.Invoke();
	}

	public void Open()
	{
		animator.Play("blinds-open");
	}

	public void Close()
	{
		animator.Play("blinds-close");
	}
}