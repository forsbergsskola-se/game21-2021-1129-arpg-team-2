using UnityEngine;

public class FloatingTextControllerMT : MonoBehaviour
{
  [SerializeField] private float destroyTime;
  [SerializeField] private Vector3 Offset;

    private void Start()
  {
    Destroy(gameObject, destroyTime);
    transform.localPosition += Offset;
  }
}
