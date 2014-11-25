using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private GameRound _gameRound;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = new GameObject();
                gameObject.name = "GameManager";
                _instance = gameObject.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    
    public GameRound GameRound
    {
        get { return _gameRound; }
    }

    public GameManager()
    {
        DontDestroyOnLoad(this);
    }

    public T GetCurrentStep<T>()
            where T: Step
    {
        return (T)_gameRound.CurrentStep;
    }

    public T GetModule<T>()
            where T : Module
    {
        return _gameRound.GetModule<T>();
    }

    public void StartAlreadyPlayedGame(GameRound gameRound)
    {
        _gameRound = gameRound;
        StartCoroutine(_gameRound.Play(this, true));
    }

    public void StartNewGame()
    {
        _gameRound = GetNewGameRound();
        
        //Prepare modules scenarios
        foreach (Module module in _gameRound.Modules)
        {
            Debug.Log("Preparing scenario of " + module.Name + " module...");
            module.PrepareScenario();
        }

        _gameRound.AddStep(new GondolaSelectionStep());
        StartCoroutine(_gameRound.Play(this, false));
    }

    public void AddNewStep(Step step)
    {
        _gameRound.AddStep(step);
    }

    private static GameRound GetNewGameRound()
    {
        GameRound gameRound = new GameRound(Configuration.Current);

        //Add modules
        gameRound.AddModule(new GondolaSelectionModule());
        gameRound.AddModule(new ProductSelectionModule());
        gameRound.AddModule(new PurchasePaymentModule());
        gameRound.AddModule(new PurchaseChangeModule());

        return gameRound;
    }
}
