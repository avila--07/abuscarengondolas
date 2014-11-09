using UnityEngine;
using System.Collections;

public class EndGameRoundStep : Step
{
    protected override bool IsReady
    {
        get { return true; }
    }

    protected override IEnumerator DoAction(bool automatically)
    {
        if (automatically)
        {
            Debug.LogError("Fin reproduccion automatica");
        } else
        {
            Debug.LogError("Fin jugando una persona real");

            UploadGameRoundService.TryToCall(GameManager.Instance.GameRound);

            //ELIMINAR ESTA LINEA, ES SOLO PARA PROBAR
            LocalDatabase.SaveFile("partida.data", GameManager.Instance.GameRound);
        }
        yield break;
    }

    protected override IEnumerator GoToScene()
    {
        Application.LoadLevel("PantallaFinal");

        yield return new WaitForSeconds(2f);
    }
}
