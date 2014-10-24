using UnityEngine;
using System.Collections;
using System;

public class VueltoAction : MonoBehaviour {

    public Boolean soyElCorrecto;

    void OnClick()
    {
        if (soyElCorrecto)
        {
            callFinCV();
            NGUISomosUtils.showTextInScreen("CVMessageStatus","¡Muy Bien! es el vuelto Correcto!");
            ListadoSingleton.Instance.clean();
            Application.LoadLevel("PantallaFinal");
        }
        else
        {
            ServicioControlVuelto.failedVueltos++;
            NGUISomosUtils.showTextInScreen("CVMessageStatus","Segui intentando!");
        }
    }

    private void callFinCV()
    {
        ControlVueltoStatistic request = new ControlVueltoStatistic(ServicioControlVuelto.cvStart, ServicioControlVuelto.failedVueltos);
        UploadStatisticsService.Call(request, ServiceResult);
    }

    private void ServiceResult(SharedObject result, Exception exception)
    {
        // Debug.Log("Resultado servicio: " + ((result == null) ? "Fallo con [" + exception + "]" : result.ToString()));
    }
}
