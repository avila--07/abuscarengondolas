using UnityEngine;
using System.Collections;
using System;

public class Service : MonoBehaviour
{
	private string _URL;
	//private int _timeout;
	private int _retries;
	private SharedObject _inputData;
	private WWW _WWW;

	internal Service ()
	{
		// nothing to do
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
	
	public Service WithRetries (int retries)
	{
		_retries = retries;
		return this;
	}

	public Service WithInputData (SharedObject inputData)
	{
		_inputData = inputData;
		return this;
	}

	public IEnumerable Call (Action<SharedObject, Exception> action)
	{
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
		if (_retries-- > 0) {
			Call (action);
			return false;
		} else {
			action (null, new Exception (message));
			return true;
		}
	}
}
