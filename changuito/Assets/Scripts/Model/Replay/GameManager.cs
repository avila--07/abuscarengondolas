using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
		private static GameManager _instance;
		private GameRound _gameRound;

		public static GameManager Instance {
				get {
						if (_instance == null) {
								GameObject gameObject = new GameObject ();
								gameObject.name = "GameManager";
								_instance = gameObject.AddComponent<GameManager> ();
						}
						return _instance;
				}
		}

		public Module CurrentModule {
				get { return _gameRound.CurrentModule; }
		}

		public void StartAlreadyPlayedGame (GameRound gameRound)
		{
				_gameRound = gameRound;
				_gameRound.Play ();
		}

		public void StartNewGame ()
		{
				_gameRound = new GameRound (Configuration.Current);

				GondolaSelectionModule gondolaSelectionModule = BuildGondolaSelectionModule ();
				gondolaSelectionModule.AddStep (new ChangeSceneStep ("PantallaSeleccionGondolas"));

				_gameRound.AddModule (BuildGondolaSelectionModule ());

				if (Configuration.Current.PurchaseModule) {
						_gameRound.AddModule (BuildPurchaseModule ());
				}
				if (Configuration.Current.ChangeControlModule) {
						_gameRound.AddModule (BuildChangeControlModule ());
				}
				_gameRound.Play ();
		}

		public void RecordStep (Step step)
		{
				CurrentModule.AddStep (step);
		}

		private static GondolaSelectionModule BuildGondolaSelectionModule ()
		{
				GondolaSelectionModule gondolaSelectionModule = new GondolaSelectionModule ();
		
				// Add random gondolas and products to buy
				List<int> randomGondolaKeys = RandomUtils.GetListWithRandomElementsFrom (GondolaFactory.tipoGondolasDictionary.Keys, Configuration.Current.GondolasCount);
				foreach (int randomGondolaKey in randomGondolaKeys) {

						string gondolaType = GondolaFactory.getGondolaType (randomGondolaKey);
						gondolaSelectionModule.AddGondola (new Gondola (gondolaType));

						string productName = RandomUtils.GetRandomElementOfList (GondolaFactory.getGondolaProducts (randomGondolaKey));
						gondolaSelectionModule.AddProductToBuy (new Product (productName, gondolaType));
				}
				
				return gondolaSelectionModule;
		}

		private static PurchaseModule BuildPurchaseModule ()
		{
				//TODO: implementar	
				return new PurchaseModule ();
		}
	
		private static ChangeControlModule BuildChangeControlModule ()
		{
				//TODO: implementar
				return new ChangeControlModule ();
		}
}
