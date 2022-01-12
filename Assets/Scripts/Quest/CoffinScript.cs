using UnityEngine;

public class CoffinScript : MonoBehaviour
{
    public LayerMask PlayerLayer;
    [SerializeField] private float intractionRange = 10f;
    [SerializeField] private BooleanValue isCoffinOpen;
    private bool isInIntractRange;
    private Animator _animator;

    private void Awake()
    {
        isCoffinOpen.BoolValue = false;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        isInIntractRange = Physics.CheckSphere(transform.position, intractionRange, PlayerLayer);

        if (isInIntractRange && Input.GetKey(KeyCode.F))
        {
            _animator.SetBool("CoffinOpen", true);
            isCoffinOpen.BoolValue = true;
        }
    }
}
