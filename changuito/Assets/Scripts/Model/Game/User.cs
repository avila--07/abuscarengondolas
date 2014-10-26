using System;

public class User : SharedObject
{
	private const string USER_FILE = "user.data";
	private static User _current = null;

	public static User Current {
		get {
			if (_current == null) {
				_current = LocalDatabase.LoadFile<User> (USER_FILE);
			}
			return _current;
		}
	}

	public void SaveAsCurrent ()
	{
		_current = this;
		LocalDatabase.SaveFile (USER_FILE, this);
	}

	public Configuration Configuration {

		get { return GetSharedObject<Configuration> ("conf"); }
		set { Set ("conf", value); }
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

