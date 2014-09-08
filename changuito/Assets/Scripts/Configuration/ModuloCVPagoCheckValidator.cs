using UnityEngine;
using System.Collections;
/// <summary>
/// Si el check del control del vuelto esta activo, el pago no puede estar desactivado.
/// </summary>
public class ModuloCVPagoCheckValidator : MonoBehaviour {

    void OnClick()
    {
        GameObject checkVuelto = GameObject.Find("ModuloControlVueltoCheckbox");
        GameObject checkPago = GameObject.Find("ModuloPagoCheckbox");


        if (checkVuelto.GetComponent<UIToggle>().value)
        {
            if (!checkPago.GetComponent<UIToggle>().value)
                checkPago.GetComponent<UIToggle>().value = true;
        }

    }
}
