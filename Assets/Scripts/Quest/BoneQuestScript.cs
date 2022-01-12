using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneQuestScript : MonoBehaviour
{
    public GameObject firstQuest;
    [SerializeField] private BooleanValue isBoneCollected;

    private void Start()
    {
        gameObject.SetActive(true);
    }


    void Update()
    {
        firstQuest.SetActive(!isBoneCollected.BoolValue);
    }
}
