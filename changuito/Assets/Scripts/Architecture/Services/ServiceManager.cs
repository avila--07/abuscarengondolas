using UnityEngine;
using System.Collections;

public class ServiceManager : MonoBehaviour
{
	public static readonly ServiceManager Instance = ServiceManager.Build ();

	private ServiceManager ()
	{
		DontDestroyOnLoad (this);
	}

	private static ServiceManager Build ()
	{
		GameObject gameObject = new GameObject ();
		gameObject.name = "ServiceManager";
		ServiceManager serviceManager = gameObject.AddComponent<ServiceManager> ();
		serviceManager.transform.parent = gameObject.transform;
		return serviceManager;
	}

	public Service NewService (string serviceId)
	{
		GameObject gameObject = new GameObject ();
		Service service = gameObject.AddComponent<Service> ();
		service.transform.parent = transform;
		service.name = serviceId + "_" + service.RequestId;
		return service.WithURL (ChanguitoConfiguration.ServerURL + "/" + serviceId);
	}	
}
