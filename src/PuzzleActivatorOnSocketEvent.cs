using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PuzzleActivatorOnSocketEvent : MonoBehaviour
{
    [Header("퍼즐 조각")]
    public GameObject pieceA;
    public GameObject pieceB;
    public GameObject pieceC;

    [Header("소켓")]
    public XRSocketInteractor socketA;
    public XRSocketInteractor socketB;
    public XRSocketInteractor socketC;

    [Header("성공 시 활성화할 오브젝트")]
    public GameObject objectToActivate;

    private bool activated = false;

    private void OnEnable()
    {
        socketA.selectEntered.AddListener(OnAnySelectEntered);
        socketB.selectEntered.AddListener(OnAnySelectEntered);
        socketC.selectEntered.AddListener(OnAnySelectEntered);
    }

    private void OnDisable()
    {
        socketA.selectEntered.RemoveListener(OnAnySelectEntered);
        socketB.selectEntered.RemoveListener(OnAnySelectEntered);
        socketC.selectEntered.RemoveListener(OnAnySelectEntered);
    }

    private void OnAnySelectEntered(SelectEnterEventArgs args)
    {
        if (activated) return;

        if (IsCorrectlyPlaced(socketA, pieceA) &&
            IsCorrectlyPlaced(socketB, pieceB) &&
            IsCorrectlyPlaced(socketC, pieceC))
        {
            objectToActivate.SetActive(true);
            activated = true;
        }
    }

    private bool IsCorrectlyPlaced(XRSocketInteractor socket, GameObject expectedPiece)
    {
        var selectedInteractable = socket.GetOldestInteractableSelected();
        return selectedInteractable != null &&
               selectedInteractable.transform.gameObject == expectedPiece;
    }
}
