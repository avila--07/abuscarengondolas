using UnityEngine;
using System.Collections;
using System;

public class Play : MonoBehaviour
{
    private bool _clicked = false;

    private void OnClick()
    {
        if (_clicked)
            return;

        _clicked = true;
        
        //GameManager.Instance.StartNewGame();
        GameManager.Instance.StartAlreadyPlayedGame(LocalDatabase.LoadFile<GameRound>("partida.data"));
    }

    public void StartAlreadyPlayedGame(String gameRoundString)
    {
        Debug.Log("GR 1 " + gameRoundString);

        SharedObject gameRoundSharedObject = SharedObject.Deserialize(gameRoundString);
        GameRound gameRound = new GameRound();
        gameRound.MergeWith(gameRoundSharedObject);
        Debug.Log("GR 2 " + gameRound.ToString());
        GameManager.Instance.StartAlreadyPlayedGame(gameRound);
    }
}
