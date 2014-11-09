using UnityEngine;
using System.Collections;

public class TicketClick : MonoBehaviour
{
    public string TicketValue
    {
        get;
        set;
    }
    
    private void OnClick()
    {
        GameManager.Instance.GetCurrentStep<PurchasePaymentStep>().AddTicketValue(TicketValue);
    }
}