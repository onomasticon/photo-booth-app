using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraServer : MonoBehaviour
{
	public class Response
	{
		public int code;
		public string data;
	}

	public string Address
	{
		get { return string.Format("{0}:{1}", ip, port); }
	}

	private static CameraServer instance;

	[SerializeField]
	private string ip;

	[SerializeField]
	private int port;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.Log("CameraServer: destroying duplicate: " + name);
			Destroy(gameObject);
		}
	}

	private IEnumerator requestTakePicture(Action<Response> callback)
	{
		var www = new WWW(Address + "/capture");

		yield return www;

		Debug.Log("Received: " + www.text);

		Response result = null;

		if (string.IsNullOrEmpty(www.error))
		{
			result = JsonUtility.FromJson<Response>(www.text);
		}
		else
		{
			Debug.LogError("CameraServer: error capturing");
		}

		callback(result);
	}
	
	private IEnumerator requestDownloadPicture(string filename, Action<Texture2D> callback)
	{
		var www = new WWW(Address + "/" + filename);

		yield return www;

		Texture2D result = null;

		if (string.IsNullOrEmpty(www.error))
		{
			result = www.texture;
		}
		else
		{
			Debug.LogError("CameraServer: error capturing");
		}

		callback(result);
	}

	private void takePicture(Action<Response> callback)
	{
		StartCoroutine(requestTakePicture(callback));
	}

	private void downloadPicture(string filename, Action<Texture2D> callback)
	{
		StartCoroutine(requestDownloadPicture(filename, callback));
	}

	public static void TakePicture(Action<Response> callback)
	{
		instance.takePicture(callback);
	}

	public static void DownloadPicture(string filename, Action<Texture2D> callback)
	{
		instance.downloadPicture(filename, callback);
	}
}