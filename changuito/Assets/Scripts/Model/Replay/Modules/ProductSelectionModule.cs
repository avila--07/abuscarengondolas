using UnityEngine;
using System.Collections;

public class ProductSelectionModule : Module
{
		public override string Name {
				get { return "ProductSelectionModule"; }
		}
	
		public override void MakeScenario ()
		{
                GondolaFactory.generateRandomProductsWithOutTarget(GondolaSelectionModule.target);

            showTarget();

		}

    private void showTarget()
    {
        GameObject grid = GameObject.Find("ListadoGrid");
        GameObject targetLabel = GameObject.Find("ProductoLabel");

        targetLabel.GetComponent<UILabel>().text = GondolaSelectionModule.target.name;
        //Asi evitamos que al hacer click en el producto a seleccionar se dispare el label.
        GameObject target = GondolaSelectionModule.target;
        target.GetComponent<ProductProperties>().target = false;
        target.tag = "SeleccionarProducto";
        NGUITools.AddChild(grid, target);
    }

}
