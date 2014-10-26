using UnityEngine;
using System.Collections;
using System;

public class BilleteAction : MonoBehaviour
{

    public int valor;

    public void OnClick()
    {
        changeMontoIfPossible();
    }

    private void changeMontoIfPossible()
    {
        // mayor a 2 dado que es el objeto de menor valor, todavia podria seguir eligiendo
        PagoStatus.pago = this.valor + PagoStatus.pago;
        int nuevoResto = PagoStatus.monto - PagoStatus.pago;

        if (nuevoResto > 2)
        {
            NGUISomosUtils.showTextInScreen("Sustraendo", "-" + PagoStatus.pago.ToString());
            NGUISomosUtils.showTextInScreen("Resto", nuevoResto.ToString());
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Segui pagando tus productos!");

            this.callPagoBillete();
        }
        else
        {
            NGUISomosUtils.showTextInScreen("Resto", "0");
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Muy bien! ¡Has pagado tus productos!");
            
            System.Threading.Thread.Sleep(250);
            
            this.callPagoBillete();
            this.callFinPago();        
            
            if (Configuration.Current.ChangeControlModule)
                Application.LoadLevel("PantallaControlVuelto");
            else
            {
                ListadoSingleton.Instance.clean();
                Application.LoadLevel("PantallaFinal");
            }
        }
    }

    private void callFinPago()
    {
        PagoStatistic request = new PagoStatistic(ServicioPago.pagoStart);
		UploadStatisticsService.TryToCall(request);
    }

    private void callPagoBillete(){
        PagoStatistic requestBillete = new PagoStatistic(ServicioPago.pagoStart, valor);
		UploadStatisticsService.TryToCall(requestBillete);
    }
}