using System;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutlineActivation : MonoBehaviour
{
   private Outline _outline;

   private void Awake()
   {
      _outline = GetComponent<Outline>();
      _outline.enabled = false;
   }

   private void OnMouseOver()
   {
      Debug.Log("Mouse is on the Rat");
      _outline.enabled = true;
   }

   private void OnMouseExit()
   {
      _outline.enabled = false;
   }
}
