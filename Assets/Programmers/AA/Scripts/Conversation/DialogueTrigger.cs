using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour {

    public LayerMask PlayerLayer;
    public Dialogue dialogue;
    public GameObject face;
    [SerializeField] private float dialogueRange = 10f;
    private bool isInDialogueRange;

    [HideInInspector] public UnityEvent QuestGiverFires;
    
    // IMPORTANT: Below it's for demo ONLY; REMOVE and do it the proper way after demo
    [HideInInspector] public UnityEvent FamilyMattersActivated;
    // IMPORTANT: Above it's for demo ONLY; REMOVE and do it the proper way after demo

    private void Update()
    {
        isInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer);

        if (isInDialogueRange && Input.GetKey(KeyCode.F))
        {
            TriggerDialogue();
            QuestGiverFires.Invoke();
            FamilyMattersActivated.Invoke();
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        face.SetActive(true);
    }

}
