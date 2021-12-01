using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChangeAA : MonoBehaviour
{
    public Texture2D cursorBase;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.ForceSoftware;
    public Vector2 hotSpot = Vector2.zero;
    Animator anim;

    private void Start()
    {
        Cursor.SetCursor(cursorBase, hotSpot, cursorMode);
        anim = gameObject.GetComponent<Animator>();
    }
    
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Active");
        }
    }    
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorBase, Vector2.zero, cursorMode);
    }
}
