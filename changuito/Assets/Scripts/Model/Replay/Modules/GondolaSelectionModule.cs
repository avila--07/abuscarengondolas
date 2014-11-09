using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GondolaSelectionModule : Module
{
    private const int PRODUCTS_LIST_CAPACITY = 3;
    private int _productToBuyIndex = -1;
    private  int failedGondola;
    private  GameObject target;
    
    public override string Name
    {
        get { return "GondolaSelectionModule"; }
    }
    
    public override string Scene
    {
        get { return "PantallaSeleccionGondolas"; }
    }

    public List<Gondola> Gondolas
    {
        get { return GetSharedObjectList<Gondola>("glatyp"); }
    }
    
    public List<Product> ProductsToBuy
    {
        get { return GetSharedObjectList<Product>("prods"); }
    }

    public Product CurrentProductToBuy
    {
        get { return (ProductsToBuy.Count > _productToBuyIndex) ? ProductsToBuy [_productToBuyIndex] : null; }
    }
    
    public Product NextProductToBuy
    {
        get { return (ProductsToBuy.Count > _productToBuyIndex + 1) ? ProductsToBuy [_productToBuyIndex + 1] : null; }
    }

    public ChanguitoDragable Changuito
    {
        get;
        private set;
    }
    
    public override void PrepareScenario()
    {       
        // Add random gondolas and products to buy
        List<int> randomGondolaTypes = RandomUtils.GetListWithRandomElementsFrom(GondolaFactory.tipoGondolasDictionary.Keys, Configuration.Current.GondolasCount);
        foreach (int randomGondolaType in randomGondolaTypes)
        {
            string gondolaName = GondolaFactory.getGondolaNombre(randomGondolaType);
            AddGondola(new Gondola(gondolaName, randomGondolaType));
            
            string productName = RandomUtils.GetRandomElementOfList(GondolaFactory.getGondolaProducts(randomGondolaType));
            AddProductToBuy(new Product(productName, randomGondolaType));
        }
    }

    /// <summary>
    /// Creamos el listado y las gondolas. Damos comienzo a las instancias de juego.
    /// </summary>
    public override void MakeScenario()
    {
        _productToBuyIndex++;
        ShowGondolas();
        ShowProductsList();
        Changuito = GameObject.Find("Changuito").GetComponent<ChanguitoDragable>();
    }

    public Vector3 GetSelectedGondolaPosition(Gondola aGondola)
    {
        foreach (Gondola gondola in Gondolas)
        {
            if (gondola.Name == aGondola.Name)
            {
                return gondola.Widget.transform.position;
            }
        }
        throw new Exception("Gondola of type [" + aGondola.Name + "] not found");
    }

    public int GetTotalCost()
    {
        int totalCost = 0;
        foreach(Product product in ProductsToBuy)
        {
            totalCost += product.Cost;
        }
        return totalCost;
    }

    private void AddGondola(Gondola gondola)
    {
        AddToList("glatyp", gondola);
    }
    
    private void AddProductToBuy(Product product)
    {
        AddToList("prods", product);
    }

    private void ShowGondolas()
    {
        GameObject gondolasGrid = GameObject.Find("SGGondolasTable");
        
        foreach (Gondola gondola in Gondolas)
        {
            GameObject gondolaGameObject = (GameObject)Resources.Load(Configuration.GONDOLAS_PATH + gondola.Name);
            gondolaGameObject.name = gondola.Name;
            gondolaGameObject = NGUITools.AddChild(gondolasGrid, gondolaGameObject);
            gondola.Widget = gondolaGameObject.GetComponent<UIWidget>();
        }
        gondolasGrid.GetComponent<UITable>().Reposition();
    }
    
    private void ShowProductsList()
    {
        GameObject productsList = GameObject.Find("SGListadoGrid");
        GameObject productToBuyGrid = GameObject.Find("SGSeleccionGrid");

        int index = 0;
        while (index < PRODUCTS_LIST_CAPACITY && index + _productToBuyIndex < ProductsToBuy.Count)
        {
            Debug.LogError("ProductsToBuy " + ProductsToBuy.Count + " index " + index);
            Product product = ProductsToBuy [index + _productToBuyIndex];

            GameObject productGameObject = (GameObject)Resources.Load(Configuration.PRODUCTOS_PATH + product.Name);
            productGameObject.name = product.Name;
            productGameObject = NGUITools.AddChild(productsList, productGameObject);
            NGUISomosUtils.setTildeProductoSeleccionado(productGameObject, false);

            if (index == 0)
            {
                NGUITools.AddChild(productToBuyGrid, productGameObject);
                NGUISomosUtils.showTextInScreen("SGSeleccionLabel", product.Name);
            }
            index++;
        }
        
        productsList.GetComponent<UIGrid>().Reposition();
    }
}