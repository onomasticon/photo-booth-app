using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureState : State
{
	[SerializeField]
	private Image pictureFrame;

	[SerializeField]
	private Blinds blinds;

	private bool isError;

	public void Capture()
	{
		isError = false;

		CameraServer.TakePicture((response) =>
		{
			if (response != null && response.code == 0)
			{
				CameraServer.DownloadPicture(response.data, (texture) => {

					var rect = new Rect(0,0, texture.width, texture.height);
					var sprite = Sprite.Create(texture, rect, Vector2.one / 2f);

					pictureFrame.sprite = sprite;
				});
			}
			else
			{
				isError = true;
			}

			StartCoroutine(proceed());
		});
	}

	public void CustomProceed()
	{
		if (isError)
		{
			Error();
		}
		else
		{
			Proceed();
		}
	}

	private IEnumerator proceed()
	{
		yield return new WaitForSeconds(2f);
		blinds.Close();
	}
}