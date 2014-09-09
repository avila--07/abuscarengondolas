using UnityEngine;
using System.Collections;

public class ModuloPagoCVCheckValidator : MonoBehaviour
{

    void OnClick()
    {
        //Si destilda el Pago, se obliga a destildar el Control de vuelto
        GameObject checkVuelto = GameObject.Find("ModuloControlVueltoCheckbox");
        GameObject checkPago = GameObject.Find("ModuloPagoCheckbox");

        if (!checkPago.GetComponent<UIToggle>().value)
        {
            checkVuelto.GetComponent<UIToggle>().value = false;
        }

    }
}
