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
        Debug.LogError("Estas comprando " + Module.CurrentProductToBuy.Name + " en " + Module.CurrentProductToBuy.GondolaType);

        if (Module.CurrentProductToBuy.GondolaType == SelectedGondola.Type)
        {
            NGUISomosUtils.showTextInScreen("SGStatusLabel", "¡Excelente!");

            if (!automatically)
                GameManager.Instance.AddNewStep(new ProductSelectionStep());
        } else
        {
            NGUISomosUtils.showTextInScreen("SGStatusLabel", "Aquí no está.\n ¡Busquemos en otra góndola!");

            if (!automatically)
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
}