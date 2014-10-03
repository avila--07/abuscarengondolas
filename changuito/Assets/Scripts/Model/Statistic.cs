using System;

public class Statistic : SharedObject
{
	public string Id {
		get { return GetString ("id"); }
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

