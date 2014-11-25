using UnityEngine;
using System.Collections;

public class GondolaSelectionStep : Step<GondolaSelectionModule>
{
    protected override bool IsReady
    {
        get { return SelectedGondola != null; }
    }

    public Gondola SelectedGondola
    {
        get { return GetSharedObject<Gondola>("gondola"); }
        private set { Set("gondola", value); }
    }

    protected override IEnumerator DoAction(bool automatically)
    {
        if (Module.CurrentProductToBuy.GondolaType == SelectedGondola.Type)
        {
            NGUISomosUtils.showTextInScreen("SGStatusLabel", "¡Excelente!");
            
            if (!automatically)
                callFinGondolaStadistic();
                GameManager.Instance.AddNewStep(new ProductSelectionStep());
        } else
        {
            NGUISomosUtils.showTextInScreen("SGStatusLabel", "Aquí no está.\n ¡Busquemos en otra góndola!");

            if (!automatically)
                GondolaSelectionModule.faileds++;
                GameManager.Instance.AddNewStep(new GondolaSelectionStep());
        }

        Module.Changuito.transform.position = Module.GetSelectedGondolaPosition(SelectedGondola);

        yield return new WaitForSeconds(1f);
    }

    public void SetCurrentSelectedGondola()
    {
        SelectedGondola = GetSelectedGondola(Module.Changuito);
    }

    private Gondola GetSelectedGondola(ChanguitoDragable changuitoDragable)
    {
        foreach (Gondola gondola in Module.Gondolas)
        {
            if (ColliderUtils.IsFullyInside(gondola.Widget, changuitoDragable.Widget))
            {
                return gondola;
            }
        }
        return null;
    }

    private void callFinGondolaStadistic()
    {
        SeleccionarGondolaStatistic request = new SeleccionarGondolaStatistic(GondolaSelectionModule.faileds, GondolaSelectionModule.moduloStart);
        UploadStatisticsService.TryToCall(request); 
    }
}