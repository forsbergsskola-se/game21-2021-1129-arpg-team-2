using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private Vector3 Offset;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += Offset;
    }
}