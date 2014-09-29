using UnityEngine;
using System.Collections;

public class ServiceLocator
{
	public static readonly ServiceLocator Instance = new ServiceLocator ();
	private GameObject _services;

	private ServiceLocator ()
	{
		_services = new GameObject ();
	}

	public Service<T> NewService<T> (string serviceId)
		where T: SharedObject
	{
		Service<T> service = _services.AddComponent<Service<T>> ();
		service.transform.parent = _services.transform;
		service.name = service.RequestId + "_" + serviceId;
		return service.WithURL (ChanguitoConfiguration.ServerURL + "/ChanguitoServices/" + serviceId);
	}	
}
