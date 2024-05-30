using AdapterLDL;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

//Al Interactuar logica para abrir una puerta
[CreateAssetMenu(fileName ="OpenDoor",menuName = "Interacciones/Puerta")]
public class OpenDoorBehavior : InteractionBehavior
{
    [Header("Door Settings")]
    public Vector3 openEulerAngle = Vector3.zero;
    public float openTime = 2f;
    public bool closeAutomatically = false;
    public float autoCloseDelay = 5f;
    public AudioClip openSound;

    private bool _isRotating = false;
    private bool _Open = false;
    private Quaternion _closedRotation; // La rotación cuando la puerta está cerrada
    private Quaternion _openRotation; // La rotación cuando la puerta está abierta
    private ATransform _interactableTransform;
    private int _interactableIndex;
    private string DoorID;

    public override void Inicialize(AGameObject interactable , int interactableID)
    {
        _closedRotation = interactable.Transform.Rotation;
        _openRotation = _closedRotation * Quaternion.Euler(openEulerAngle);
        _interactableTransform = interactable.Transform;
        _isRotating = false;
        _Open = false;
        _interactableIndex = interactableID + interactable.GameObject.GetInstanceID();
        DoorID = interactableID.ToString();
    }

    public override void Interact(AGameObject Interactor)
    {
        // Si la puerta ya se está moviendo, no hacer nada.
        if (_isRotating) { return; }

        if (_Open)
        {
            //Cerraria la puerta
            if (CoroutineHandler.Instance.CorountineHasRunning(_interactableIndex + 2) && !CoroutineHandler.Instance.CorountineHasRunning(_interactableIndex + 3))
            {
                //Cerre la puerta mientras esta el cerrado automatico
                CoroutineHandler.Instance.StopCoroutine(_interactableIndex + 2);
                CoroutineHandler.Instance.RunCoroutine(_interactableIndex + 1, CloseDoor());
            }
            else if (!CoroutineHandler.Instance.CorountineHasRunning(_interactableIndex + 1))
            {
                //Cerre la puerta manualmente
                CoroutineHandler.Instance.RunCoroutine(_interactableIndex + 1, CloseDoor());
            }

            CambiarTootTipText("Abrir");

            return;
        }

        //abriria la puerta
        if (!CoroutineHandler.Instance.CorountineHasRunning(_interactableIndex))
        {
            CoroutineHandler.Instance.RunCoroutine(_interactableIndex, OpenDoor());
            CambiarTootTipText("Cerrar");
        }
    }

    private void CambiarTootTipText(string toolTipText)
    {
        base.ToolTipText = toolTipText;
    }

    private IEnumerator RotateDoor(int id,ATransform doorTransform, Quaternion initialRotation, Quaternion targetRotation)
    {
        _isRotating = true;
        float startTime = Time.time;           
        while (Time.time < startTime + (1f / openTime))
        {
            float progress = (Time.time - startTime) * openTime;
            doorTransform.Rotation = Quaternion.Slerp(initialRotation, targetRotation, progress);
            yield return null;
        }
        doorTransform.Rotation = targetRotation;
        _isRotating = false;
        CoroutineHandler.Instance.StopCoroutine(id);
    }

    #region Estados

    private IEnumerator OpenDoor()
    {
        Debug.Log("Open");
        while (_isRotating) yield return null;
        yield return CoroutineHandler.Instance.RunCoroutine(_interactableIndex + 3, RotateDoor(_interactableIndex + 3, _interactableTransform, _closedRotation, _openRotation));
        PlayDoorSound();
        EventManager.TriggerEvent("DoorOpened", DoorID);
        if (closeAutomatically)
        {
            CoroutineHandler.Instance.RunCoroutine(_interactableIndex + 2, AutoCloseDoor(_interactableTransform));
        }
        _Open = true;
        CoroutineHandler.Instance.StopCoroutine(_interactableIndex);
    }

    private IEnumerator CloseDoor()
    {
        Debug.Log("Close");
        while (_isRotating) yield return null;
        yield return CoroutineHandler.Instance.RunCoroutine(_interactableIndex + 3, RotateDoor(_interactableIndex + 3, _interactableTransform, _openRotation, _closedRotation));
        PlayDoorSound();
        EventManager.TriggerEvent("DoorClosed", DoorID);
        _Open = false;
        CoroutineHandler.Instance.StopCoroutine(_interactableIndex + 1);
    }

    private IEnumerator AutoCloseDoor(ATransform doorTransform)
    {
        yield return new WaitForSeconds(autoCloseDelay);
        while (_isRotating) yield return null;
        yield return CoroutineHandler.Instance.RunCoroutine(_interactableIndex + 3, RotateDoor(_interactableIndex + 3, doorTransform, _openRotation, _closedRotation));
        PlayDoorSound();
        _Open = false;
        CoroutineHandler.Instance.StopCoroutine(_interactableIndex + 2);
    }

    #endregion
    private void PlayDoorSound()
    {
        if (openSound != null && !_isRotating)
        {
            AudioSource.PlayClipAtPoint(openSound, _interactableTransform.Position.ToUnityVector3());
        }
    }
}
