using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

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
	
	public T GetSharedObject<T> (string key)
		where T: SharedObject
	{
		return _data [key] as T;
	}

	public T Get<T> (string key)
		where T : class
	{
		return _data [key] as T;
	}

	public void Set (string key, SharedObject value)
	{
		if (value != null) {
			_data [key] = value.SerializeInString ();
		}
	}

	public void Set<T> (string key, T value)
	{
		if (value != null) {
			_data [key] = value.ToString ();
		}
	}
			
	public byte[] Serialize ()
	{
		return Encoding.UTF8.GetBytes (SerializeInString ());
	}
	
	public string SerializeInString ()
	{
		return MiniJSON.Json.Serialize (_data);
	}

	public static SharedObject Deserialize (byte[] bytes)
	{
		return new SharedObject ((Dictionary<string,object>)MiniJSON.Json.Deserialize (Encoding.UTF8.GetString (bytes)));
	}
}
