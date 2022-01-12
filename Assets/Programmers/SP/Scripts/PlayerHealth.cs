using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private TextMeshProUGUI text;

    [SerializeField] private FloatValue playerHealth;

    private void Awake()
    {
        // text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void LateUpdate()
    {
        if(text != null) text.text = "Health: " + playerHealth.RuntimeValue;
    }
}
