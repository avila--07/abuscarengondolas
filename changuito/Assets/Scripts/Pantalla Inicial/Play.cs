using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour
{
		private void OnClick ()
		{
<<<<<<< HEAD
				//StartNewFakeGame ();

				GameManager.Instance.StartNewGame ();
=======
				StartNewFakeGame ();

				//GameManager.Instance.StartNewGame ();
>>>>>>> 0be3bfcc7a75754afe2c797a5a0e8a6c6102a06a
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
<<<<<<< HEAD
=======
		                                   
				//GameManager.Instance.RecordStep (new TapStep (1, 1));
		                                   
				//
				//Destroy (gameObject);

>>>>>>> 0be3bfcc7a75754afe2c797a5a0e8a6c6102a06a
		}

		private void AddGondolaAndAProduct (GondolaSelectionModule gondolaSelectionModule, int gondolaKey)
		{
				string gondolaType = GondolaFactory.getTipoGondola (gondolaKey);

				gondolaSelectionModule.AddGondola (new Gondola (gondolaType));
				gondolaSelectionModule.AddProductToBuy (new Product (GondolaFactory.getGondolaProducts (gondolaKey) [0], gondolaType));
		}
}
