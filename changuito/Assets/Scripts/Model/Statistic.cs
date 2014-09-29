using System;

public class Statistic : SharedObject
{
	public string id {
		get { return GetString ("id"); }
		set { Set ("id", value); }
	}

	public Statistic ()
	{
	}
}

