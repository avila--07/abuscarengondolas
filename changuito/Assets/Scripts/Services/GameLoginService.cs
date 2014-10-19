using System;

public class GameLoginService
{
		
	public static void Call (User user, Action<User, Exception> originalCallback)
	{
		ServiceManager.Instance.NewService ("login").
				WithSecondsTimeout (30).
				WithMaxRetries (3).
				Call (user, originalCallback);
	}
}

