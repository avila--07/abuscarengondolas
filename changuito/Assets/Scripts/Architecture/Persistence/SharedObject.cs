using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System;

public class SharedObject
{
	private Dictionary<string, object> _data;
	
	public SharedObject ()
	{
		_data = new Dictionary<string, object> (20);
	}
	
	private SharedObject (Dictionary<string, object> data)
	{
		_data = data;
	}

	public static SharedObject Deserialize (byte[] bytes)
	{
		return Deserialize (Encoding.UTF8.GetString (bytes));
	}

	private static SharedObject Deserialize (string json)
	{
		return new SharedObject ((Dictionary<string,object>)MiniJSON.Json.Deserialize (json));
	}

	public override string ToString ()
	{
		return MiniJSON.Json.Serialize (_data);
	}
	
	public double GetDouble (string key)
	{
		return (double)_data [key];
	}

	public int GetInt (string key)
	{
		return (int)_data [key];
	}

	public long GetLong (string key)
	{
		return (long)_data [key];
	}
	
	public T GetSharedObject<T> (string key)
		where T: SharedObject
	{
		T result = (T)Activator.CreateInstance (typeof(T));
		result.MergeWith (GetSharedObject (key));
		return result;
	}
	
	public SharedObject GetSharedObject (string key)
	{
		object value = _data [key];
		
		SharedObject valueAsSharedObject = value as SharedObject;
		if (valueAsSharedObject == null) {
			// Preferible dejar el objeto ya deserializado, en vez de deserializarlo siempre
			valueAsSharedObject = SharedObject.Deserialize ((string)value);
			Set (key, valueAsSharedObject);
		}
		return valueAsSharedObject;
	}
	
	public string GetString (string key)
	{
		return (string)_data [key];
	}
	
	public void MergeWith (SharedObject sharedObject)
	{ 
		foreach (var entry in sharedObject._data) {
			
			string key = entry.Key;
			object value = entry.Value;
			
			SharedObject valueAsSharedObject = value as SharedObject;
			if (valueAsSharedObject != null) {
				SharedObject oldValue = GetSharedObject (key);
				
				if (oldValue != null) {
					oldValue.MergeWith (valueAsSharedObject);
				} else {
					Set (key, valueAsSharedObject);
				}
			} else {
				Set (key, value);
			}
		}
	}
		
	public byte[] Serialize ()
	{
		return Encoding.UTF8.GetBytes (ToString ());
	}

	public void Set<T> (string key, T value)
	{
		_data [key] = value;
	}
}
