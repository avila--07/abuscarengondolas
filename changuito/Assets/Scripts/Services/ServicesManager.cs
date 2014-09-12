using UnityEngine;
using System.Collections;

public class ServiceLocator /*: MonoBehaviour*/
{
	public static readonly ServiceLocator Instance = new ServiceLocator ();
	private GameObject _services;

	private ServiceLocator ()
	{
		_services = new GameObject ();
	}

	public Service NewService (string serviceId)
	{
		Service service = _services.AddComponent<Service> ();
		service.transform.parent = _services.transform;
		service.name = service.RequestId + "_" + serviceId;
		return service.WithURL (ChanguitoConfiguration.ServerURL + '/' + serviceId);
	}	
}
