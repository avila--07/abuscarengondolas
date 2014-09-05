using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperMarket : MonoBehaviour
{
	private const float CHANGUITO_SIZE = 1f;
	private const int ITEMS_TO_SHOW = 3;
	public int GondolaQtyPerRow;
	public int GondolaQtyPerColumn;
	private List<Product> _productsToPurchase;
	private List<GameObject> _productsSprites = new List<GameObject> (ITEMS_TO_SHOW);
	private GameObject _productList;

	// TODO: esto va a venir de otro lado despues, pero por ahora lo dejamos aca
	private List<Product> GetProductsToPurchase ()
	{
		List<Product> products = new List<Product> (4);
		products.Add (new Product ("Lechuga"));
		products.Add (new Product ("Azucar", SpritesLocator.GetPath ("Productos", "Azucar")));
		products.Add (new Product ("Zapallo", SpritesLocator.GetPath ("Productos", "Zapallo")));
		products.Add (new Product ("Leche", SpritesLocator.GetPath ("Productos", "Leche")));
		for (int i = 0; i < ITEMS_TO_SHOW; i++)
			products.Add (new Product ("NoProduct", SpritesLocator.GetPath ("Productos", "NoProduct")));
		return products;
	}

	private void Start ()
	{
		_productsToPurchase = GetProductsToPurchase ();
		float screenExtend = Camera.main.orthographicSize;
		float screenSize = screenExtend * 2;
		Debug.Log ("screenExtend " + screenExtend);

		GameObject background = Factory.CreatePlane2D (-screenExtend, screenExtend, screenSize, screenSize);

		_productList = CreateProductList (background, screenSize);
		FillProductList (_productList);

		CreateChanguitoAndGondolas (background);
	}

	private GameObject CreateProductList (GameObject background, float screenSize)
	{
		// create product list		
		GameObject productList = Factory.CreatePlane2D (ContainerUtils.GetWidth (background) / 2, 0, screenSize * 0.20f, screenSize * 0.40f);
		ColliderUtils.PutInFrontOf (productList, background);
		return productList;
	}

	private void FillProductList (GameObject productList)
	{
		int productsToShowQuantity = Mathf.Min (ITEMS_TO_SHOW, _productsToPurchase.Count);
		IEnumerator<Product> productEnumerator = _productsToPurchase.GetEnumerator ();
		ContainerUtils.FillContainer (productList, new ContainerUtils.Padding (0, 0, 0, 0), 1, productsToShowQuantity, delegate(float top, float left, float width, float height) {
			
			productEnumerator.MoveNext ();
			Product product = productEnumerator.Current;
			GameObject productSprite = Factory.CreateSprite (product.SpritePath, top, left, width, height);
			productSprite.AddComponent<BoxCollider> ();
			productSprite.AddComponent<ClickableObject> ().OnMouseClick = delegate(Vector3 clickPosition) {
				OnProductClick (product, clickPosition);
			};
			_productsSprites.Add (productSprite);
			ColliderUtils.PutInFrontOf (productSprite, productList);
		});
	}

	private void OnProductClick (Product product, Vector3 clickPosition)
	{
		if (_productsToPurchase.Count == ITEMS_TO_SHOW)
			return;

		foreach (GameObject productSprite in _productsSprites)
			Destroy (productSprite);
		_productsSprites.Clear ();

		_productsToPurchase.Remove (product);

		FillProductList (_productList);
	}

	private void CreateChanguitoAndGondolas (GameObject background)
	{		
		// create gondolas sprites
		List<GameObject> gondolas = new List<GameObject> (GondolaQtyPerRow * GondolaQtyPerColumn);
		ContainerUtils.FillContainer (background, new ContainerUtils.Padding (0, CHANGUITO_SIZE, 0, CHANGUITO_SIZE), GondolaQtyPerRow, GondolaQtyPerColumn, delegate(float top, float left, float width, float height) {
			
			gondolas.Add (Factory.CreateSprite (SpritesLocator.GONDOLA_SPRITE, top, left, width, height));
		});

		// create changuito sprite
		float initialChanguitoTop = background.collider.bounds.center.y - background.collider.bounds.extents.y + CHANGUITO_SIZE;
		float initialChanguitoLeft = background.collider.bounds.center.x - (CHANGUITO_SIZE / 2);
		GameObject changuito = Factory.CreateSprite (SpritesLocator.CHANGUITO_SPRITE, initialChanguitoTop, initialChanguitoLeft, CHANGUITO_SIZE, CHANGUITO_SIZE);
		ColliderUtils.PutInFrontOf (changuito, gondolas [0]);
		
		// set dragable options		
		changuito.AddComponent<BoxCollider> ();
		DragableObject dragableObject = changuito.AddComponent<DragableObject> ();
		dragableObject.DragableArea = background;
		dragableObject.OnDrop = delegate () {
			int i = 0;
			foreach (GameObject gondola in gondolas) {
				if (i == 0 && ColliderUtils.IsFullyInside (gondola.renderer.bounds, changuito.collider.bounds)) {
					
					Application.LoadLevel ("PantallaSeleccionProductos");
					return;
				}
				i++;
			}

            //ContainerUtils.SetPositionTopLeft (changuito, initialChanguitoTop, initialChanguitoLeft - CHANGUITO_SIZE);
			//ColliderUtils.PutInFrontOf (changuito, gondolas [0]);
			Debug.LogError ("Gondola equivocada!");
		};
	}
}
