using UnityEngine;

public class Billboard : MonoBehaviour
{
    // public Transform cam;
    public Transform cam;
    public Transform billboard;

    public Transform rat;
    private Vector3 offset;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        offset = new Vector3(0, 2f, 0);
    }

    void LateUpdate()
    { 
        //Keeps the the enemy hp bars looking at the camera
        billboard.rotation = cam.rotation;
    }

    // public void KillBar()
    // {
    //     Destroy(gameObject);
    // }
}
