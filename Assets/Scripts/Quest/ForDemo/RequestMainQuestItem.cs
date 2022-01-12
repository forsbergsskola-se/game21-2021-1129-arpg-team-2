using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This script is for demo-purpose only.
/// Should retire this asap.
/// </summary>
public class RequestMainQuestItem : MonoBehaviour
{
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] private float interactRange;
    [SerializeField] private BooleanValue isCoffinOpen;
    [HideInInspector] public UnityEvent PlayerRequestMainQuestItem;

    private void Update()
    {
        if (!isCoffinOpen.BoolValue || !IsInInteractRange() || !Input.GetKeyUp(KeyCode.F)) return;
        Debug.Log("Player requesting main quest item...");
        PlayerRequestMainQuestItem.Invoke();
    }

    private bool IsInInteractRange()
    {
        var tmp = Physics.CheckSphere(transform.position, interactRange, PlayerLayer);
        return tmp;
    }
}
