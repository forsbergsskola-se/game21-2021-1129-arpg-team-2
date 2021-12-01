using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraFollowAA : MonoBehaviour
{
    // camera will follow this object
    [SerializeField] private Vector3Value target;
    // camera zoom
    [SerializeField] private float scrollSpeed = 20f;
    [SerializeField] private float minY = 20;
    [SerializeField] private float maxY = 120f;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    //public Rigidbody rigidbody;
    public NavMeshAgent navMeshAgent;


    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
        Offset = camTransform.position - target.Vector3;
        //rigidbody = Target.GetComponent<Rigidbody>();
    }


    private void LateUpdate()
    {
        //Create a vector3 position empty value for the camera
        //Assign the camera position to it
        Vector3 cameraPosition = camTransform.position;
        //Check the scrolling This is what changes (Y value)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cameraPosition.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY, maxY);
        //Check player movement
        if (navMeshAgent.velocity.magnitude > 0.15f)
        {
            // update position
            Vector3 targetPosition = new Vector3(target.Vector3.x + Offset.x, cameraPosition.y, target.Vector3.z + Offset.z);
            cameraPosition = Vector3.SmoothDamp(cameraPosition, targetPosition, ref velocity, SmoothTime);

        }
        camTransform.position = cameraPosition;
        //Rotation when paning on corner
        //1-Define rotation
        if(Input.GetKeyDown(KeyCode.Space))
            camTransform.RotateAroundLocal( Vector3.up,01f);
        //2-Check condition if input position of the mouse is on screen width (we move only the y axis)
    }

    private void ZoomCamera()
    {
        
    }
}
