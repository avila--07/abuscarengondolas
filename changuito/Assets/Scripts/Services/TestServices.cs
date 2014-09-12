using UnityEngine;
using System.Collections;
using System;

public class TestServices : MonoBehaviour
{

	void Start ()
	{
		TestServiceCall ();
		TestServiceInvalidCall ();
		TestSerialization ();
	}

	void TestServiceCall ()
	{
		ServiceLocator.Instance.NewService ("").Call (ServiceResult);
	}

	void TestServiceInvalidCall ()
	{
		ServiceLocator.Instance.NewService ("").WithURL ("Aasdadsasd//").Call (ServiceResult);
	}

	void ServiceResult (SharedObject result, Exception exception)
	{
		Debug.Log ("El servicio me devolvio " + ((result == null) ? "[fail]" : result.SerializeInString ()) + " ..... " + exception);

		Debug.Log ("El parametro one es igual a " + ((result == null) ? "[fail]" : result.Get<string> ("one")));
	}

	void TestSerialization ()
	{
		var parent = new SharedObject ();
		parent.Set ("parent", 1);

		var child = new SharedObject ();
		child.Set ("child", 2);
		parent.Set ("child", child);

		Debug.Log (SharedObject.Deserialize (parent.Serialize ()).SerializeInString ());
	}
}
