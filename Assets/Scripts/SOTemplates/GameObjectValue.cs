using UnityEngine;

[CreateAssetMenu(fileName = "GameObject", menuName = "Value/GameObject")]
public class GameObjectValue : ScriptableObject
{
    [SerializeField] private GameObject _gameObject;
    
    public GameObject Value
    {
        get => _gameObject;
        set => _gameObject = value; 
    }
}
