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

		public void AddToList<T> (string key, T value)
		where T: SharedObject
		{
				Set (key + (GetList<T> (key).Count + 1), value);
		}

		public List<T> GetSharedObjectList<T> (string key)
		where T: SharedObject
		{
				return GetList<T> (key, (string childKey) => GetSharedObject<T> (childKey));
		}
	
		public List<T> GetList<T> (string key)
		{
				return GetList<T> (key, (string childKey) => (T)GetValueOrNull (childKey));
		}

		public bool GetBool (string key)
		{
				return Convert.ToBoolean (GetValueOrNull (key));
		}

		public double GetDouble (string key)
		{
				return Convert.ToDouble (GetValueOrNull (key));
		}

		public int GetInt (string key)
		{
				return Convert.ToInt32 (GetValueOrNull (key));
		}

		public long GetLong (string key)
		{
				return Convert.ToInt64 (GetValueOrNull (key));
		}
	
		public T GetSharedObject<T> (string key)
		where T: SharedObject
		{
				SharedObject sharedObject = GetSharedObject (key);
				T sharedObjectAsT = sharedObject as T;
				if (sharedObject != null && sharedObjectAsT == null) {
						sharedObjectAsT = (T)Activator.CreateInstance (typeof(T));
						sharedObjectAsT.MergeWith (sharedObject);
						Set (key, sharedObjectAsT);
				}
				return sharedObjectAsT;
		}

		public SharedObject GetSharedObject (string key)
		{
				object value = GetValueOrNull (key);
		
				SharedObject valueAsSharedObject = value as SharedObject;
				if (value != null && valueAsSharedObject == null) {
						// Preferible dejar el objeto ya deserializado, en vez de deserializarlo siempre
						valueAsSharedObject = SharedObject.Deserialize ((string)value);
						Set (key, valueAsSharedObject);
				}
				return valueAsSharedObject;
		}
	
		public string GetString (string key)
		{
				return Convert.ToString (GetValueOrNull (key));
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

		private object GetValueOrNull (string key)
		{
				object value = null;
				_data.TryGetValue (key, out value);
				return value;
		}
	
		private List<T> GetList<T> (string key, Func<string, T> getItemDelegate)
		{
				List<T> items = new List<T> (15);
		
				int i = 1;
				T item = default(T);
				while ((item = getItemDelegate(key + i)) != null) {
						i++;
						items.Add (item);
				}
				return items;
		}
}
