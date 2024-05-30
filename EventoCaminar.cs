using AdapterLDL;
using PlayerLDL;
using UnitsLDL;
using UnityEngine;

public class EventoCaminar : MonoBehaviour
{
    Vector3 myPos;
    public Transform posDestino;
    public ANpc ANpc;
    private void Start()
    {
        myPos = transform.position;
    }

    private void OnEnable()
    {
        EventManager.StartListening<string>("DoorOpened", (DoorID) => MoveOn(DoorID));
        EventManager.StartListening<string>("DoorClosed", (DoorID) => BackTo(DoorID));
    }

    private void OnDisable()
    {
        EventManager.StopListening<string>("DoorOpened", (DoorID)=>MoveOn(DoorID));
        EventManager.StopListening<string>("DoorClosed", (DoorID)=>BackTo(DoorID));
    }

    private void MoveOn(string DoorID)
    {
        if (DoorID == "1" && posDestino != null)
        {
            ANpc.Ir(new AVector3(posDestino.position));
            ANpc.GetActions.SetParameterValueForAction("InteractuarUnidad", "InteractuableID", 2);
        }
    }

    private void BackTo(string DoorID)
    {
        if (DoorID == "1" && posDestino != null)
        {
            //ANpc.Ir(new AVector3(myPos));
            ANpc.GetActions.PerformActionByName("InteractuarUnidad");
        }
    }
}
