using UnityEngine;
using System.Collections;
using System;

public class Salir : MonoBehaviour {

    void Start()
    {
		#if !UNITY_WEBPLAYER
        JuegoStatistic result = new JuegoStatistic(DateTime.Now);
        UploadStatisticsService.TryToCall(result);
        #endif

    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
           Application.Quit();
        }
	}
}
