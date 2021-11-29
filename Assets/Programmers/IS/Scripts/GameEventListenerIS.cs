using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerIS : MonoBehaviour
{
    public GameEventIS Event;
    public UnityEvent Response;

    private void OnEnable() => Event.RegisterListener(this);
    private void OnDisable() => Event.UnregisterListener(this);
    public void OnEventRaised() => Response.Invoke();
}
