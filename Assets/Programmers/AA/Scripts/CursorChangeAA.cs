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

    private void Start()
    {
        Cursor.SetCursor(cursorBase, hotSpot, cursorMode);
    }
    
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
                //Debug.Log("Pressed primary button.");

        //if (Input.GetMouseButtonDown(1))
                //Debug.Log("Pressed secondary button.");

        //if (Input.GetMouseButtonDown(2))
                //Debug.Log("Pressed middle click.");
    }
    

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }    
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorBase, Vector2.zero, cursorMode);
    }
}
