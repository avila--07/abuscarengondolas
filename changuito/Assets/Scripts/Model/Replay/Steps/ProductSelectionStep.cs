using UnityEngine;
using System.Collections;

public class ProductSelectionStep : Step<ProductSelectionModule>
{
    protected override bool IsReady
    {
        get { return SelectedProduct != null; }
    }

    public Product SelectedProduct
    {
        get { return GetSharedObject<Product>("product"); }
        private set { Set("product", value); }
    }

    protected override IEnumerator DoAction(bool automatically)
    {
        GondolaSelectionModule gondolaSelectionModule = GameManager.Instance.GetModule<GondolaSelectionModule>();
        Product productToBuy = gondolaSelectionModule.CurrentProductToBuy;

        Debug.LogError("Estas comprando " + productToBuy.Name + " y diste a  " + SelectedProduct.Name);

        Color color;

        if (productToBuy.Name == SelectedProduct.Name)
        {
            color = Color.green;
            NGUISomosUtils.showTextInScreen("GameMessage", "¡Muy Bien!");

            if (!automatically)
            {
                callProductStadistic();
                if (gondolaSelectionModule.NextProductToBuy != null)
                    GameManager.Instance.AddNewStep(new GondolaSelectionStep());
                else if (GameManager.Instance.GameRound.Configuration.PurchaseModule)
                    GameManager.Instance.AddNewStep(new PurchasePaymentStep());
                else
                    GameManager.Instance.AddNewStep(new EndGameRoundStep());
            }
        } else
        {
            color = Color.red;
            NGUISomosUtils.showTextInScreen("GameMessage", "¡Sigue intentando!");
            
            if (!automatically)
                ProductSelectionModule.faileds++;
                GameManager.Instance.AddNewStep(new ProductSelectionStep());
        }

        if (automatically)
        {
            UI2DSprite productGameObject = Module.GetSelectedProductWidget(SelectedProduct);
            productGameObject.color = color;

            yield return new WaitForSeconds(1f);

            productGameObject.color = Color.white;
        }
    }

    public void SetCurrentSelectedProduct(Product product)
    {
        SelectedProduct = product;
    }

    private void callProductStadistic()
    {
        SeleccionarProductoStatistic request = new SeleccionarProductoStatistic(ProductSelectionModule.faileds, ProductSelectionModule.moduleStart);
        UploadStatisticsService.TryToCall(request); 
    }
}
