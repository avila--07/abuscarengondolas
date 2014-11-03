using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour
{
		private void OnClick ()
		{
				//StartNewFakeGame ();

				GameManager.Instance.StartNewGame ();
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
		}

		private void AddGondolaAndAProduct (GondolaSelectionModule gondolaSelectionModule, int gondolaKey)
		{
				string gondolaType = GondolaFactory.getTipoGondola (gondolaKey);

				gondolaSelectionModule.AddGondola (new Gondola (gondolaType));
				gondolaSelectionModule.AddProductToBuy (new Product (GondolaFactory.getGondolaProducts (gondolaKey) [0], gondolaType));
		}
}
