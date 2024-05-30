using AdapterLDL;
using UnityEngine;

//Scriptable object base para los diferentes comportamientos que tendra una entidad al ser Interactuada por el player
public abstract class InteractionBehavior : ScriptableObject
{
    public string ToolTipText;
    public abstract void Inicialize(AGameObject interactable , int interactableID);
    public abstract void Interact(AGameObject Interactor);
}
