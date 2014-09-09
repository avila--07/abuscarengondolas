using UnityEngine;
using System.Collections;

public class ServiceLocator : MonoBehaviour
{
	public static readonly ServiceLocator instance = new ServiceLocator ();
	private GameObject _services;

	private ServiceLocator ()
	{
		_services = new GameObject ();
	}

	public Service NewService (string serviceId)
	{
		Service service = _services.AddComponent<Service> ();
		DontDestroyOnLoad (service);
		service.name = RandomUtils.RandomAlphaNumericString (10) + "_" + serviceId;
		return service.WithURL (ChanguitoConfiguration.ServerURL + '\\' + serviceId);
	}	
}
