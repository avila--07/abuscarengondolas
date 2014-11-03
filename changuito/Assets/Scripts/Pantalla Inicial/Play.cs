using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour
{
		private void OnClick ()
		{
				//StartNewFakeGame ();
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

				gondolaSelectionModule.AddStep (new ChangeSceneStep ("PantallaSeleccionGondolas"));
				                                   
				GameManager.Instance.StartAlreadyPlayedGame (gameRound);
		                                   
				//GameManager.Instance.RecordStep (new TapStep (1, 1));
		                                   
				//
				//Destroy (gameObject);

		}

		private void AddGondolaAndAProduct (GondolaSelectionModule gondolaSelectionModule, int gondolaKey)
		{
				string gondolaName = GondolaFactory.getGondolaNombre (gondolaKey);

				gondolaSelectionModule.AddGondola (new Gondola (gondolaName, gondolaKey));
				gondolaSelectionModule.AddProductToBuy (new Product (GondolaFactory.getGondolaProducts (gondolaKey) [0], gondolaName));
		}
}
