using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour
{
		private void OnClick ()
		{
				StartNewFakeGame ();
				//GameManager.Instance.StartNewGame ();
		}

		private void StartNewFakeGame ()
		{				
				//Prueba
				GondolaSelectionModule gondolaSelectionModule = new GondolaSelectionModule ();
				AddGondolaAndAProduct (gondolaSelectionModule, GondolaFactory.ALMACEN);
				AddGondolaAndAProduct (gondolaSelectionModule, GondolaFactory.BEBIDAS);
				AddGondolaAndAProduct (gondolaSelectionModule, GondolaFactory.FRESCOS);
				AddGondolaAndAProduct (gondolaSelectionModule, GondolaFactory.FRUTAS);
		                                   
				GameRound gameRound = new GameRound (Configuration.Current);
				gameRound.AddModule (gondolaSelectionModule);
				                                   
				GameManager.Instance.StartAlreadyPlayedGame (gameRound);
		}

		private void AddGondolaAndAProduct (GondolaSelectionModule gondolaSelectionModule, int gondolaType)
		{
				string gondolaName = GondolaFactory.getGondolaNombre (gondolaType);

				gondolaSelectionModule.AddGondola (new Gondola (gondolaName, gondolaType));
				gondolaSelectionModule.AddProductToBuy (new Product (GondolaFactory.getGondolaProducts (gondolaType) [0], gondolaType));
		}
}
