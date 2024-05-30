using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor_Character : BaseActor
{
    public EDM_Monobehaviur ImpEventoDeMiedo;
    public override void Activar()
    {
        throw new System.NotImplementedException();
    }

    public override void Desactivar()
    {
        throw new System.NotImplementedException();
    }
    public void FinalizarEvento()
    {
        if (ImpEventoDeMiedo != null)
        {
            ImpEventoDeMiedo.Finalizar();
        }
    }
}
