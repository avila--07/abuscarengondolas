using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
		private static GameManager _instance;
		private GameRound _gameRound;
        public GondolaSelectionModule gondolaSelectionModule;

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

		public GameManager ()
		{
				DontDestroyOnLoad (this);
		}

		public void StartAlreadyPlayedGame (GameRound gameRound)
		{
				Application.LoadLevel ("PantallaSeleccionGondolas");

				_gameRound = gameRound;
				StartCoroutine (_gameRound.Play (this));
		}

		public void StartNewGame ()
		{
				_gameRound = new GameRound (Configuration.Current);

				gondolaSelectionModule = BuildGondolaSelectionModule ();
				gondolaSelectionModule.AddStep (new ChangeSceneStep ("PantallaSeleccionGondolas"));

                _gameRound.AddModule(gondolaSelectionModule);

				if (Configuration.Current.PurchaseModule) {
						_gameRound.AddModule (BuildPurchaseModule ());
				}
				if (Configuration.Current.ChangeControlModule) {
						_gameRound.AddModule (BuildChangeControlModule ());
				}
				StartCoroutine (_gameRound.Play (this));
		}

		public void RecordStep (Step step)
		{
				CurrentModule.AddStep (step);
		}

		private static GondolaSelectionModule BuildGondolaSelectionModule ()
		{
				GondolaSelectionModule gondolaSelectionModule = new GondolaSelectionModule ();

				// Add random gondolas and products to buy
				List<int> randomGondolaTypes = RandomUtils.GetListWithRandomElementsFrom (GondolaFactory.tipoGondolasDictionary.Keys, Configuration.Current.GondolasCount);
				foreach (int randomGondolaType in randomGondolaTypes) {

						string gondolaName = GondolaFactory.getGondolaNombre (randomGondolaType);
						gondolaSelectionModule.AddGondola (new Gondola (gondolaName, randomGondolaType));

						string productName = RandomUtils.GetRandomElementOfList (GondolaFactory.getGondolaProducts (randomGondolaType));
						gondolaSelectionModule.AddProductToBuy (new Product (productName, randomGondolaType));
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
