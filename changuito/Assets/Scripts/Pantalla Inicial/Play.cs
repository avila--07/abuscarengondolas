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
        
        GameManager.Instance.StartNewGame();
        //GameManager.Instance.StartAlreadyPlayedGame(LocalDatabase.LoadFile<GameRound>("partida.data"));
    }
}
