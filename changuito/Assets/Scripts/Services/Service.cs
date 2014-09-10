using UnityEngine;
using System.Collections;
using System;

public class Service : MonoBehaviour
{
	private const int MAX_DEFAULT_RETRIES = 3;
	private string _URL;
	//private int _timeout;
	private int _retryIntent;
	private int _maxRetries = MAX_DEFAULT_RETRIES;
	private SharedObject _inputData;
	private WWW _WWW;

	internal Service ()
	{
		DontDestroyOnLoad (this);
	}

	internal Service WithURL (string URL)
	{
		_URL = URL;
		return this;
	}

	public Service WithTimeout (int timeout)
	{
		//_timeout = timeout;
		return this;
	}
	
	public Service WithMaxRetries (int maxRetries)
	{
		_maxRetries = maxRetries;
		return this;
	}

	public Service WithInputData (SharedObject inputData)
	{
		_inputData = inputData;
		return this;
	}

	public void Call (Action<SharedObject, Exception> action)
	{
		StartCoroutine ("CallImpl", action);
	}

	private IEnumerator CallImpl (Action<SharedObject, Exception> action)
	{
		if (_inputData == null)
			_WWW = new WWW (_URL);
		else
			_WWW = new WWW (_URL, _inputData.Serialize ());
		yield return _WWW;

		bool remove = true;
		if (_WWW.error != null) {
			remove = ThreatError ("Service with URL [" + _URL + "] failed with reason [" + _WWW.error + "]", action);
		} else if (!_WWW.isDone) {
			remove = ThreatError ("Service with URL [" + _URL + "] failed with unknown reason", action);
		} else {
			action (SharedObject.Deserialize (_WWW.bytes), null);
		}

		if (remove) {
			_WWW.Dispose ();
			_WWW = null;
			Destroy (this);
		}
	}

	private bool ThreatError (string message, Action<SharedObject, Exception> action)
	{
		if (_maxRetries > _retryIntent++) {
			Debug.LogWarning ("Retrying service with URL [" + _URL + "]. Intent [" + _retryIntent + "] of [" + _maxRetries + "]");
			Call (action);
			return false;
		} else {
			action (null, new Exception (message));
			return true;
		}
	}
}
