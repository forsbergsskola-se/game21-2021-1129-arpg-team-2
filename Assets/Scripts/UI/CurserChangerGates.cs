using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserChangerGates : MonoBehaviour
{
    public Texture2D cursorBase;
    public Texture2D cursorLocked;
    public Texture2D cursorUnklocked;
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
        if (GateIsClosed)
        {
            Cursor.SetCursor(cursorLocked, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(cursorUnklocked, hotSpot, cursorMode);
        }
    }    
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorBase, Vector2.zero, cursorMode);
    }
}
