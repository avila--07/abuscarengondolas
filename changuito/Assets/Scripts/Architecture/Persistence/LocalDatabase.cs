using System;
using UnityEngine;
using System.IO;

public static class LocalDatabase
{
	public static T LoadFile<T> (string name)
		where T : SharedObject, new()
	{
		if (!ExistsFile (name)) {
			return null;
		}

		SharedObject sharedObject;
		using (BufferedStream inputStream = new BufferedStream(File.Open(GetRootPath() + name, FileMode.Open, FileAccess.Read, FileShare.None), 1024)) {
			byte[] bytes = new byte[inputStream.Length];
			int index = 0;
			int readByte;
			while ((readByte = inputStream.ReadByte()) != -1) {
				bytes [index++] = (byte)readByte;
			}
			inputStream.Close ();

			sharedObject = SharedObject.Deserialize (bytes);
		}
		T instance = new T ();
		instance.MergeWith (sharedObject);
		return instance;
	}

	public static void SaveFile<T> (string name, T sharedObject)
		where T : SharedObject
	{
		using (FileStream fileStream = File.Open(GetRootPath() + name, FileMode.OpenOrCreate, FileAccess.ReadWrite,		                           FileShare.None)) {
			byte[] bytes = sharedObject.Serialize ();
			int index = 0;
			while (index < bytes.Length) {
				fileStream.WriteByte (bytes [index++]);
			}
			fileStream.Flush ();
			fileStream.Close ();
		}
	}

	public static bool ExistsFile (string name)
	{
		return File.Exists (GetRootPath () + name);
	}
		
	public static void DeleteFile (string name)
	{
		if (ExistsFile (name)) {
			File.Delete (GetRootPath () + name);
		}
	}
	
	private static string GetRootPath ()
	{
		if (Application.platform == RuntimePlatform.Android || 
			Application.platform == RuntimePlatform.WindowsPlayer) {
			return Application.persistentDataPath;
		}
		if (Application.platform == RuntimePlatform.WindowsEditor) {
			return "./";
		}
		
		throw new NotImplementedException ("No Root Path for this platform");
	}
}

