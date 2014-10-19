using System;

public class User : SharedObject
{
	private const string USER_FILE = "user.data";
	private static User _current = null;

	public static User Current ()
	{
		if (_current == null) {
			_current = LocalDatabase.LoadFile<User> (USER_FILE);
		}
		return _current;
	}

	public static void SaveCurrent (User user)
	{
		_current = user;
		LocalDatabase.SaveFile (USER_FILE, user);
	}

	public string Id {
		get { return GetString ("uid");	}
	}

	public string Token {
		get { return GetString ("tkn");	}
	}

	public string Email {
		get { return GetString ("email");	}
		set { Set ("email", value); }
	}
		
	public string Password {
		get { return GetString ("pwd");	}
		set { Set ("pwd", value); }
	}

	public bool AlreadyExists {
		get{ return GetBool ("adyext");}
	}
}

