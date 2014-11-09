using UnityEngine;
using System.Collections;

public class ProductClick : MonoBehaviour
{
    public Product Product
    {
        get;
        set;
    }

    private void OnClick()
    {
        GameManager.Instance.GetCurrentStep<ProductSelectionStep>().SetCurrentSelectedProduct(Product);
    }
}
