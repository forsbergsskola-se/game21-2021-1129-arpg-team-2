using UnityEngine;

public class Billboard : MonoBehaviour
{
    // public Transform cam;
    public Transform billboard;
    private Transform cam;
    private Vector3 offset;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        offset = new Vector3(0, 2f, 0);
    }

    void LateUpdate()
    { 
        billboard.rotation = cam.rotation;
    }
}
