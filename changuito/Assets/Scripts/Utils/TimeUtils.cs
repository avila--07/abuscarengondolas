using System;

public static class TimeUtils
{
	public static long NowTicks {
		get { return DateTime.Now.Ticks; }
	}
		
	public static long NowInMillis {
		get { return (long)TimeSpan.FromTicks (NowTicks).TotalMilliseconds; }
	}

	public static TimeSpan GetDifference (long ticks, long otherTicks)
	{
		return TimeSpan.FromTicks (ticks - otherTicks);
	}
	
	public static TimeSpan TimePassed (long olderNowTicks)
	{
		return GetDifference (NowTicks, olderNowTicks);
	}
}
