using System.Collections;
using System;

public static class GetGameRoundService
{
	public static void TryToCall (GameRound gameRound, Action<GameRound, Exception> gameRoundResult)
	{
		ServiceManager.Instance.NewService ("ggss").
				WithSecondsTimeout (30).
					WithMaxRetries (3).
				Call (gameRound, gameRoundResult);
	}
}