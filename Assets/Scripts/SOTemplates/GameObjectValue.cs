using UnityEngine;

[CreateAssetMenu(fileName = "GameObjectValue", menuName = "Value/GameObjectValue")]
public class GameObjectValue : ScriptableObject
{
    [SerializeField] private GameObject _gameObject;
    
    public GameObject Value
    {
        get => _gameObject;
        set => _gameObject = value; 
    }
}
