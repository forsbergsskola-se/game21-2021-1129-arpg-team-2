using UnityEngine;

public class NoKillDoorInteract : MonoBehaviour
{
    private bool isOpen;
    public bool IsOpen => isOpen;
    private Animator doorAnimation;

    private void Awake()
    {
        isOpen = false;
        doorAnimation = GetComponentInParent<Animator>();
    }

    private void OnMouseDown()
    {
        isOpen = !isOpen;
        doorAnimation.SetTrigger(isOpen ? "isOpening" : "isClosing");
    }
}
