using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public LayerMask PlayerLayer;
    public Dialogue dialogue;
    [SerializeField] private float dialogueRange = 10f;
    private bool isInDialogueRange;

    private void Update()
    {
        isInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer);

        if (isInDialogueRange && Input.GetKey(KeyCode.F))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
