using UnityEngine;
using System.Collections;

public class Billete : MonoBehaviour {

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
            NGUISomosUtils.showTextInScreen("Sustraendo",  "-" + this.valor.ToString());
            NGUISomosUtils.showTextInScreen("Resto", nuevoResto.ToString());
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Segui pagando tus productos!");
        }
        else
        {
            NGUISomosUtils.showTextInScreen("Resto", "0");
            PagoStatus.pago = nuevoResto*-1;
            NGUISomosUtils.showTextInScreen("GameMessageLabel", "¡Muy bien! ¡Has pagado tus productos!");
            System.Threading.Thread.Sleep(250);
            Application.LoadLevel("PantallaControlVuelto");
        }
     }
         
}
