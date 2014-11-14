using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System;

public class SharedObject
{
    private Dictionary<string, object> _data;
    
    public SharedObject()
    {
        _data = new Dictionary<string, object>(20);
    }
    
    private SharedObject(Dictionary<string, object> data)
    {
        _data = data;
    }

    public static SharedObject Deserialize(byte[] bytes)
    {
        return Deserialize(Encoding.UTF8.GetString(bytes));
    }

    public static SharedObject Deserialize(string json)
    {
        return new SharedObject((Dictionary<string,object>)MiniJSON.Json.Deserialize(json));
    }
    
    public static T CastSharedObject<T>(SharedObject parent, string key, SharedObject child)
        where T: SharedObject
    {
        T childAsT = child as T;
        if (child != null && childAsT == null)
        {
            childAsT = (T)Activator.CreateInstance(typeof(T));
            childAsT.MergeWith(child);
            parent.Set(key, childAsT);
        }
        return childAsT;
    }

    public override string ToString()
    {
        return MiniJSON.Json.Serialize(_data);
    }

    public void AddToList<T>(string key, List<T> list)
    {
        list.ForEach(element => AddToList(key, element));
    }
    
    public void AddToList<T>(string key, T value)
    {
        Set(key + (GetList<T>(key).Count + 1), value);
    }

    public List<T> GetSharedObjectList<T>(string key, Func<string, SharedObject, T> converter)
        where T: SharedObject
    {
        return GetList<T>(key, delegate(string childKey)
        {
            SharedObject sharedObject = GetSharedObject(childKey);
            if (sharedObject == null)
                return  null;
            return converter(childKey, sharedObject);
        });
    }

    public List<T> GetSharedObjectList<T>(string key)
        where T: SharedObject
    {
        return GetList<T>(key, (string childKey) => GetSharedObject<T>(childKey));
    }
    
    public List<T> GetList<T>(string key)
    {
        return GetList<T>(key, (string childKey) => GetValueOrDefault<T>(childKey));
    }

    public bool GetBool(string key)
    {
        return GetValueOrDefault<bool>(key);
    }

    public double GetDouble(string key)
    {
        return GetValueOrDefault<double>(key);
    }

    public int GetInt(string key)
    {
        return GetValueOrDefault<int>(key);
    }

    public long GetLong(string key)
    {
        return GetValueOrDefault<long>(key);
    }
    
    public T GetSharedObject<T>(string key)
        where T: SharedObject
    {
        return CastSharedObject<T>(this, key, GetSharedObject(key));
    }
    
    public SharedObject GetSharedObject(string key)
    {
        object value = GetValueOrDefault<object>(key);
        
        SharedObject valueAsSharedObject = value as SharedObject;
        if (value != null && valueAsSharedObject == null)
        {
            // Preferible dejar el objeto ya deserializado, en vez de deserializarlo siempre
            valueAsSharedObject = SharedObject.Deserialize((string)value);
            Set(key, valueAsSharedObject);
        }
        return valueAsSharedObject;
    }
    
    public string GetString(string key)
    {
        return GetValueOrDefault<string>(key);
    }
    
    public void MergeWith(SharedObject sharedObject)
    { 
        foreach (var entry in sharedObject._data)
        {
            string key = entry.Key;
            object value = entry.Value;
            
            SharedObject valueAsSharedObject = value as SharedObject;
            if (valueAsSharedObject != null)
            {
                SharedObject oldValue = GetSharedObject(key);
                
                if (oldValue != null)
                {
                    oldValue.MergeWith(valueAsSharedObject);
                } else
                {
                    Set(key, valueAsSharedObject);
                }
            } else
            {
                Set(key, value);
            }
        }
    }
        
    public byte[] Serialize()
    {
        return Encoding.UTF8.GetBytes(ToString());
    }

    public void Set<T>(string key, T value)
    {
        _data [key] = value;
    }

    private bool ExistsKey(string key)
    {
        object value;
        return _data.TryGetValue(key, out value);
    }

    private T GetValueOrDefault<T>(string key)
    {
        object value = null;
        if (!_data.TryGetValue(key, out value))
            return default(T);
        if (value is T)
            return (T)value;
        return (T) Convert.ChangeType(value, typeof(T));
    }
    
    private List<T> GetList<T>(string key, Func<string, T> getItemDelegate)
    {
        List<T> items = new List<T>(15);
        
        int i = 1;
        T item = default(T);
        while (ExistsKey(key + i))
        {
            items.Add(getItemDelegate(key + i));
            i++;
        }
        return items;
    }
}
