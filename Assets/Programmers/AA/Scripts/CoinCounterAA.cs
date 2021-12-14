using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounterAA : MonoBehaviour
{
    private TextMeshProUGUI text;
    public static int coinAmount;
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }
    
    void Update()
    {
        text.text = coinAmount.ToString();
    }
}
