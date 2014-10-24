using UnityEngine;
using System.Collections;
using System;

public class Salir : MonoBehaviour {

    void Start()
    {
        JuegoStatistic result = new JuegoStatistic(ChanguitoConfiguration.gameStartDate);
		UploadStatisticsService.Call(result, ServiceResult);
    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
           Application.Quit();
        }
	}

    private void ServiceResult(SharedObject result, Exception exception)
    {
        // Debug.Log("Resultado servicio: " + ((result == null) ? "Fallo con [" + exception + "]" : result.ToString()));
    }
}
