using UnityEngine;
using System.Collections;

public class Billete : MonoBehaviour
{

    public int valor;

    public void OnClick()
    {
        changeMontoIfPossible();
    }

    private void changeMontoIfPossible()
    {
        // mayor a 2 dado que es el objeto de menor valor, todavia podria seguir eligiendo
        int nuevoResto = NGUISomosUtils.getIntFromGameObject("Resto") - this.valor;

        if (nuevoResto > 2)
        {
            NGUISomosUtils.showTextInScreen("Sustraendo", "-" + this.valor.ToString());
            NGUISomosUtils.showTextInScreen("Resto", nuevoResto.ToString());
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Segui pagando tus productos!");
        }
        else if (nuevoResto < 2 && nuevoResto >= 0)
        {
            NGUISomosUtils.showTextInScreen("Resto", "0");
            PagoStatus.pago = PagoStatus.monto - nuevoResto;
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Muy bien! ¡Has pagado tus productos!");
            System.Threading.Thread.Sleep(250);
            Application.LoadLevel("PantallaControlVuelto");
        }
        if (nuevoResto < 0)
        {
            NGUISomosUtils.showTextInScreen("Resto", PagoStatus.monto.ToString());
            NGUISomosUtils.showTextInScreen("Sustraendo", "-");
            NGUISomosUtils.showTextInScreen("Minuendo", PagoStatus.monto.ToString());
            PagoStatus.pago = 0;
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Pagaste de mas! ¡Volve a intentarlo!");
        }
    }
}