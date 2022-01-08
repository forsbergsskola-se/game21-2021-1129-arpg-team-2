using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour {

    public LayerMask PlayerLayer;
    public Dialogue dialogue;
    public GameObject face;
    [SerializeField] private float dialogueRange = 10f;
    private bool isInDialogueRange;

    [HideInInspector] public UnityEvent QuestGiverFires;

    private void Update()
    {
        isInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer);

        if (isInDialogueRange && Input.GetKey(KeyCode.F))
        {
            TriggerDialogue();
            QuestGiverFires.Invoke();
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        face.SetActive(true);
    }

}
