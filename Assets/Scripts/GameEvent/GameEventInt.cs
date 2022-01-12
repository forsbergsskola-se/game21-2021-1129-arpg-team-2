using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// An int game event that emits an int value upon being raised
/// </summary>
[CreateAssetMenu(fileName = "IntEvent", menuName = "Game/Event/IntEvent")]
public class GameEventInt : ScriptableObject
{
    private List<GameEventIntListener> listeners = new List<GameEventIntListener>();

    public void Raise(int? value)
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(GameEventIntListener listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventIntListener listener) => listeners.Remove(listener);
}
