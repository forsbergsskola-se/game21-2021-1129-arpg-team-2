using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounterAA : MonoBehaviour
{
    [SerializeField] private IntegerValue playersCoins;
    private TextMeshProUGUI text;
    
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }
    
    void Update()
    {
        text.text =playersCoins.Int.ToString();
    }
}
