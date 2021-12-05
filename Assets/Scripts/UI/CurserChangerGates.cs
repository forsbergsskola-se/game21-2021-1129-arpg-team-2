using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserChangerGates : MonoBehaviour
{
    public Texture2D cursorBase;
    public Texture2D cursorLocked;
    public Texture2D cursorUnlocked;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = Vector2.zero;
    Animator anim;
    [SerializeField] private BooleanValue GateIsClosed;

    private void Start()
    {
        Cursor.SetCursor(cursorBase, hotSpot, cursorMode);
        anim = gameObject.GetComponent<Animator>();
    }
    
    void OnMouseEnter()
    {
        if (GateIsClosed.BoolValue)
        {
            Cursor.SetCursor(cursorLocked, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(cursorUnlocked, hotSpot, cursorMode);
        }
    }    
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorBase, Vector2.zero, cursorMode);
    }
}
