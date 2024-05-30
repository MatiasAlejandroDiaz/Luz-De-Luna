using AdapterLDL;
using UnityEngine;
//[CreateAssetMenu(menuName = "Interaction Behaviors/Light Candle")]
//public class LightCandleBehavior : InteractionBehavior
//{
//    public override void Interact()
//    {
//        // Lógica específica para encender una vela
//    }
//}
//Clase que Permite a los diferentes Entidades del juego poder interactuar con el player
public class Interactable : MonoBehaviour
{
    public InteractionBehavior interactionBehavior;
    private InteractionBehavior _interactionBehaviorInstance;

    public int interactableID;

    private void Start()
    {
        _interactionBehaviorInstance = Instantiate(interactionBehavior);
        _interactionBehaviorInstance.Inicialize(new AGameObject(gameObject), interactableID);
    }
    public void Interact(AGameObject Interactor)
    {
        if (_interactionBehaviorInstance != null)
        {           
            _interactionBehaviorInstance.Interact(Interactor);
        }
    }

    public string GetToolTip()
    {
        return _interactionBehaviorInstance.ToolTipText;
    }
}
