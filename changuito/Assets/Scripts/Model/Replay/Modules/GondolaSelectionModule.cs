using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GondolaSelectionModule : Module
{
    public static int MAX_LISTADO = 3;
    public int PosicionActual = 0;
    public static List<UI2DSprite> GondolasSprite = new List<UI2DSprite>(6);
    public static int failedGondola;
    public static DateTime gondolaStart;
    public static GameObject target;

	/// <summary>
	/// Creamos el listado y las gondolas. Damos comienzo a las instancias de juego.
	/// </summary>
	public override void MakeScenario ()
	{
        initializeStatistics();

      	if (!seleccionFinalizada ()) 
        {
            this.showGondolas();
            this.showListado();
            this.showTarget();
        }
        else
        {
            finalizarJuego();
        }
    }

    private void showTarget()
    {
        GameObject targetGrid = GameObject.Find("SGSeleccionGrid");

        Product productTarget = ProductsToBuy.ToArray()[PosicionActual];
        GameObject productGameObjectTarget = (GameObject)Resources.Load(Configuration.PRODUCTOS_PATH + productTarget.Name);
        productGameObjectTarget.GetComponent<ProductProperties>().tipo = productTarget.GondolaType;
        NGUITools.AddChild(targetGrid, productGameObjectTarget);
        NGUISomosUtils.showTextInScreen("SGSeleccionLabel", productGameObjectTarget.name);
        target = productGameObjectTarget;
    }

    private void showListado()
    {
        GameObject listgadoGrid = GameObject.Find("SGListadoGrid");
        //Corto por la cantidad maxima permitida a mostrar ...
        if (PosicionActual < MAX_LISTADO)
        {   //En el caso de que sea menor la cantidad a mostrar ...
            if (Configuration.Current.GondolasCount < MAX_LISTADO)
                this.showSomeProductsInListado(listgadoGrid, 0, Configuration.Current.GondolasCount);
            else
                this.showSomeProductsInListado(listgadoGrid, 0, MAX_LISTADO);
        }
        else
        {
            this.showSomeProductsInListado(listgadoGrid, MAX_LISTADO, Configuration.Current.GondolasCount);
        }
    }

    private void showGondolas()
    {
        GameObject gondolasGrid = GameObject.Find("SGGondolasTable");
        
        foreach (Gondola gondola in Gondolas) 
        {
		    GameObject gondolaGameObject = (GameObject)Resources.Load (Configuration.GONDOLAS_PATH + gondola.Name);
		    gondolaGameObject.name = gondola.Name;
		    gondolaGameObject.GetComponent<GondolaProperties> ().ProductType = gondola.Type;
            GondolasSprite.Add(NGUITools.AddChild(gondolasGrid, gondolaGameObject).GetComponent<UI2DSprite>());
        }
        gondolasGrid.GetComponent<UITable>().Reposition();
    }

    private void showSomeProductsInListado(GameObject grid, int ini, int fin)
    {
		GameObject listgadoGrid = GameObject.Find ("SGListadoGrid");
        for (int i = ini; i < fin; i++)
        {
            Product product = ProductsToBuy.ToArray()[i];
		    GameObject productGameObject = (GameObject)Resources.Load (Configuration.PRODUCTOS_PATH + product.Name);
		    productGameObject.name = product.Name;
		    if (productGameObject == null) {
			    Debug.LogError ("El prefab " + product.Name + " no existe");
		    }
				
            initializeProduct(productGameObject, product);
            NGUITools.AddChild(listgadoGrid, productGameObject);
	    }
        
        listgadoGrid.GetComponent<UIGrid>().Reposition();
    }

    private void initializeProduct(GameObject productGameObject, Product product)
    {
        productGameObject.GetComponent<ProductProperties> ().tipo = product.GondolaType;
		NGUISomosUtils.setTildeProductoSeleccionado (productGameObject, false);
		productGameObject.tag = "GameController";
		productGameObject.GetComponent<ProductProperties> ().target = false;

    }

    private void initializeStatistics()
    {
        failedGondola = 0;
        gondolaStart = DateTime.Now;
    }

    private void finalizarJuego()
    {
        if (Configuration.Current.PurchaseModule)
        {
            this.AddStep(new ChangeSceneStep("PantallaPago"));
        }
        else
        {
            this.AddStep(new ChangeSceneStep("PantallaFinal"));
            this.clean();
        }
    }

    private bool seleccionFinalizada()
    {
        return Configuration.Current.GondolasCount == ListadoSingleton.PosicionActual;
    }

    internal void clean()
    {
        /*foreach (GameObject gameObject in ProductsToBuy)
        {
            NGUISomosUtils.setTildeProductoSeleccionado(gameObject, false);
        }
        ListadoProductos.Clear();
        gondolasSeleccionadas.Clear();
        PagoStatus.monto = 0;
        PagoStatus.pago = 0;
        ListadoSingleton.PosicionActual = 0;
        ProductTarget = null;*/
    }

    public void AddGondola (Gondola gondola)
	{
		AddToList ("glatyp", gondola);
	}
	
	public void AddProductToBuy (Product product)
	{
			AddToList ("prods", product);
	}

    public override string Name
    {
        get { return "GondolaSelection"; }
    }

    public List<Gondola> Gondolas
    {
        get { return GetList<Gondola>("glatyp"); }
    }

    public List<Product> ProductsToBuy
    {
        get { return GetList<Product>("prods"); }
    }
}