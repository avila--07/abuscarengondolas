using UnityEngine;
using System.Collections;
using System;

public class Service : MonoBehaviour
{
	private const int MAX_DEFAULT_RETRIES = 3;
	private const int DEFAULT_TIMEOUT_SECONDS = 10;
	private string _URL;
	private string _requestId;
	private int _secondsTimeout = DEFAULT_TIMEOUT_SECONDS;
	private int _retryIntent;
	private int _maxRetries = MAX_DEFAULT_RETRIES;
	private Action<SharedObject, Exception> _action;
	private SharedObject _inputData;
	private WWW _WWW;
	private long _startTime;

	public string RequestId {
		get { return _requestId; }
	}

	internal Service ()
	{
		_requestId = RandomUtils.RandomAlphaNumericString (5);
		DontDestroyOnLoad (this);
	}

	internal Service WithURL (string URL)
	{
		_URL = URL;
		return this;
	}

	public Service WithSecondsTimeout (int secondsTimeout)
	{
		_secondsTimeout = secondsTimeout;
		return this;
	}
	
	public Service WithMaxRetries (int maxRetries)
	{
		_maxRetries = maxRetries;
		return this;
	}
	
	public void Call<T> (Action<T, Exception> action)
		where T: SharedObject
	{
		Call (null, action);
	}

	public void Call<T> (SharedObject inputData, Action<T, Exception> action)
		where T: SharedObject
	{
		if (inputData != null && User.Current != null) {
			inputData.Set ("uid", User.Current.Id);
			inputData.Set ("tkn", User.Current.Token);
		}

		_inputData = inputData;
		_startTime = TimeUtils.NowTicks;
		_action = delegate(SharedObject sharedObject, Exception exception) {
	
			T result = sharedObject as T;
			if (result == null && exception == null) {
				result = (T)Activator.CreateInstance (typeof(T));
				result.MergeWith (sharedObject);
			}
			action (result, exception);
		};
		StartCoroutine (CallImpl ());
	}

	// For timeout!
	private void Update ()
	{
		if (_startTime > 0) {
			if (TimeUtils.TimePassed (_startTime).Seconds >= _secondsTimeout) {
				_WWW.Dispose ();
				_WWW = null;
				_startTime = 0;
				ThreatError ("Service with URL [" + _URL + "] failed with reason timeouted ([" + _secondsTimeout + "] seconds)");
			}
		}
	}

	private IEnumerator CallImpl ()
	{
		if (_inputData == null)
			_WWW = new WWW (_URL);
		else
			_WWW = new WWW (_URL, _inputData.Serialize ());
		yield return _WWW;

		if (_WWW == null || !_WWW.isDone) {
			yield break;
		}

		bool remove = true; 	
		if (_WWW.error != null) {
			remove = !ThreatError ("Service with URL [" + _URL + "] failed with reason [" + _WWW.error + "]");
		} else {
			_action (SharedObject.Deserialize (_WWW.bytes), null);
		}

		if (remove) {
			_WWW.Dispose ();
			_WWW = null;
			Destroy (gameObject);
			Destroy (this);
		}
	}

	private bool ThreatError (string message)
	{
		Debug.LogWarning (message);
		if (_maxRetries > _retryIntent++) {
			Debug.LogWarning ("Retrying service with URL [" + _URL + "]. Intent [" + _retryIntent + "] of [" + _maxRetries + "]");
			Call (_action);
			return true;
		} 

		_action (null, new Exception (message));
		return false;
	}
}
