using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class SharedObject
{
	private Dictionary<string, string> _data;
	
	private SharedObject ()
	{
		_data = new Dictionary<string, string> (20);
	}

	private SharedObject (Dictionary<string, string> data)
	{
		_data = data;
	}

	public string GetString (string key)
	{
		return _data [key];
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
		return new SharedObject ((Dictionary<string,string>)MiniJSON.Json.Deserialize (Encoding.UTF8.GetString (bytes)));
	}
}
