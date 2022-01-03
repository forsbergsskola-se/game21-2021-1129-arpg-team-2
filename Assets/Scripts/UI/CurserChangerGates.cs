using UnityEngine;

public class CurserChangerGates : MonoBehaviour
{
    public Texture2D cursorBase;
    public Texture2D cursorLocked;
    public Texture2D cursorUnlocked;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = Vector2.zero;
    private KillTriggeredGate killGate;

    private void Awake()
    {
        killGate = GetComponent<KillTriggeredGate>();
    }

    private void Start()
    {
        Cursor.SetCursor(cursorBase, hotSpot, cursorMode);
    }
    
    void OnMouseEnter()
    {
        if (killGate.GateIsLocked) Cursor.SetCursor(cursorLocked, hotSpot, cursorMode);
        else Cursor.SetCursor(cursorUnlocked, hotSpot, cursorMode);
    }    
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorBase, Vector2.zero, cursorMode);
    }
}
