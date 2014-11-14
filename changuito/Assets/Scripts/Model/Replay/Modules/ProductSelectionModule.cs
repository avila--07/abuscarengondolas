using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ProductSelectionModule : Module
{
    private const int PRODUCTS_QUANTITY = 4;

    /// <summary>
    /// Guarda la cantidad de veces que el jugador se ha equivocado antes de seleccionar el correcto. Meramente estadistico.
    /// </summary>
    public static int faileds;
    public static DateTime moduleStart;

    public override string Name
    {
        get { return "ProductSelectionModule"; }
    }

    public override string Scene
    {
        get { return "PantallaSeleccionProductos"; }
    }
    
    public override void PrepareScenario()
    {
        initializeStatistic();

        Debug.Log("[SAC - PSM] prepareScenario");
        foreach (Product productToBuy in GameManager.Instance.GetModule<GondolaSelectionModule>().ProductsToBuy)
        {
            List<string> randomProductIds = RandomUtils.GetListWithRandomElementsFrom(GondolaFactory.getGondolaProducts(productToBuy.GondolaType), PRODUCTS_QUANTITY);
            List<Product> randomProducts = new List<Product>(PRODUCTS_QUANTITY);
            randomProducts.Add(productToBuy);
            foreach (string productName in randomProductIds)
            {
                if (randomProducts.Count == PRODUCTS_QUANTITY)
                {
                    break;
                }
                if (productToBuy.Name != productName)
                {
                    randomProducts.Add(new Product(productName, productToBuy.GondolaType));
                }
            }
            // We randomnly order products
            randomProducts = RandomUtils.GetListWithRandomElementsFrom(randomProducts, randomProducts.Count);
            AddToList("prod" + productToBuy.GondolaType, randomProducts);
        }
    }

    public override void MakeScenario()
    {
        initializeStatistic();

        Debug.Log("[SAC - PSM] prepareScenario Make");
        Product productToBuy = GameManager.Instance.GetModule<GondolaSelectionModule>().CurrentProductToBuy;
       
        List<Product> otherProducts = GetOtherProducts(productToBuy);
        
        GameObject productsGrid = GameObject.Find("GondolaGrid");
        GameObject productLabelsGrid = GameObject.Find("LabelsGrid");
        
        foreach (Product product in otherProducts)
        {
            GameObject productGameObject = Resources.Load<GameObject>(Configuration.PRODUCTOS_PATH + product.Name);
            productGameObject.name = product.Name;
            productGameObject = NGUITools.AddChild(productsGrid, productGameObject);
            product.Widget = productGameObject.GetComponent<UI2DSprite>();

            ProductClick productClick = productGameObject.AddComponent<ProductClick>();
            productClick.Product = product;
            
            GameObject productLabelGameObject = Resources.Load<GameObject>("Prefabs/labelProductos");
            productLabelGameObject.name = productGameObject.name;
            productLabelGameObject.GetComponent<UILabel>().text = product.Name;
            productLabelGameObject = NGUITools.AddChild(productLabelsGrid, productLabelGameObject);

            if (product.Name == productToBuy.Name)
            {
                GameObject productToBuyLabel = GameObject.Find("ProductoLabel");
                productToBuyLabel.GetComponent<UILabel>().text = productToBuy.Name;

                GameObject productToBuyGrid = GameObject.Find("ListadoGrid");
                NGUITools.AddChild(productToBuyGrid, productGameObject);
            }
        }
        
        productsGrid.GetComponent<UIGrid>().Reposition();
        productLabelsGrid.GetComponent<UIGrid>().Reposition();
    }

    public UI2DSprite GetSelectedProductWidget(Product aProduct)
    {
        foreach (Product product in GetOtherProducts(aProduct))
        {
            if (product.Name == aProduct.Name)
            {
                return product.Widget;
            }
        }        
        throw new Exception("Product with name [" + aProduct.Name + "] not found");
    }
    
    private List<Product> GetOtherProducts(Product product)
    {
        return GetSharedObjectList<Product>("prod" + product.GondolaType);
    }

    private void initializeStatistic()
    {
        moduleStart = DateTime.Now;
        faileds = 0;
    }
}
