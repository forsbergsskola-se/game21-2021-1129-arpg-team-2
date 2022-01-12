using UnityEngine;
using UnityEngine.Events;

public class GameEventIntListener : MonoBehaviour
{
    public GameEventInt Event;
    public UnityEvent<int?> Response;

    private void OnEnable() => Event.RegisterListener(this);
    private void OnDisable() => Event.UnregisterListener(this);
    public void OnEventRaised(int? value) => Response.Invoke(value);
}
