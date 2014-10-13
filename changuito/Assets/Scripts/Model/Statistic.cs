using System;

public class Statistic : SharedObject
{
	public long Id {
		get { return GetLong ("id"); }
		set { Set ("id", value); }
	}

	public int PointX {
		get { return GetInt ("x"); }
		set { Set ("x", value); }
	}

	public Statistic ()
	{
	}
}

