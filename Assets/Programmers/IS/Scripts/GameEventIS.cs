using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A GameEvent represents any message that we want to send across the system
/// </summary>
[CreateAssetMenu(fileName = "Event", menuName = "Game/Event")]
public class GameEventIS : ScriptableObject
{
    private List<GameEventListenerIS> listeners = new List<GameEventListenerIS>();

    public void Raise()
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListenerIS listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventListenerIS listener) => listeners.Remove(listener);
}
