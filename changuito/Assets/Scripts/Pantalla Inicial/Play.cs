using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour
{
    private void OnClick()
    {
        //GameManager.Instance.StartNewGame();
        GameManager.Instance.StartAlreadyPlayedGame(LocalDatabase.LoadFile<GameRound>("partida.data"));
    }
}
