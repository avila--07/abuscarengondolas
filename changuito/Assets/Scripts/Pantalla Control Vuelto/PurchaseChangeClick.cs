using UnityEngine;
using System.Collections;

public class PurchaseChangeClick : MonoBehaviour
{    
    public int PurchaseChange
    {
        get;
        set;
    }
    
    private void OnClick()
    {
        GameManager.Instance.GetCurrentStep<PurchaseChangeStep>().SetPurchaseChangeSelected(PurchaseChange);
    }
}
