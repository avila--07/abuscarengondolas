using UnityEngine;
using System.Collections;

public class ModuloPagoCVCheckValidator : MonoBehaviour
{

    void OnClick()
    {
        GameObject checkVuelto = GameObject.Find("ModuloControlVueltoCheckbox");
        GameObject checkPago = GameObject.Find("ModuloPagoCheckbox");

        if (!checkPago.GetComponent<UIToggle>().value)
        {
            if (checkVuelto.GetComponent<UIToggle>().value)
                checkPago.GetComponent<UIToggle>().value = true;
        }

    }
}
