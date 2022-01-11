using UnityEngine;

public class FlowerQuestScript : MonoBehaviour
{
    public GameObject firstQuest;
    [SerializeField] private BooleanValue isFlowerCollected;

    private void Start()
    {
        gameObject.SetActive(true);
    }


    void Update()
    {
        firstQuest.SetActive(!isFlowerCollected.BoolValue);
    }
}
