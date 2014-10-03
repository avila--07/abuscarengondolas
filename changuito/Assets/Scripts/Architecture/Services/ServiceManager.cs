using UnityEngine;
using System.Collections;

public class ServiceManager
{
	public static readonly ServiceManager Instance = new ServiceManager ();
	private GameObject _services;

	private ServiceManager ()
	{
		_services = new GameObject ();
	}

	public Service NewService (string serviceId)
	{
		Service service = _services.AddComponent<Service> ();
		service.transform.parent = _services.transform;
		service.name = service.RequestId + "_" + serviceId;
		return service.WithURL (ChanguitoConfiguration.ServerURL + "/ChanguitoServices/" + serviceId);
	}	
}
