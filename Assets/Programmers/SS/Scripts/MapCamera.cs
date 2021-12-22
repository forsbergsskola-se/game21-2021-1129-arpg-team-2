using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] private Vector3 offset;
    Vector3 velocity;
    [SerializeField] private int miniMapFOV;
    [SerializeField] private int maxMapFOV;
    [SerializeField] private GameObject miniMapContainer;
    [SerializeField] private GameObject maxMapContainer;
    [SerializeField] private bool isMapMaximized;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        MinimizeMiniMap();
    }

    void LateUpdate()
    {
        if(isMapMaximized)
        {
            transform.position = new Vector3(0, transform.position.y, 40f);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, playerTransform.position + offset, ref velocity, 0.3f, 30f);
        }
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            
            if(isMapMaximized==true)
            {
                MinimizeMiniMap();
            }
            else
            {
                MaximizeMiniMap();
            }
            isMapMaximized = !isMapMaximized;
        }
    }

    private void MaximizeMiniMap()
    {
        miniMapContainer.SetActive(false);
        maxMapContainer.SetActive(true);
        this.GetComponent<Camera>().fieldOfView = maxMapFOV;
        Time.timeScale = 0;
    }

    private void MinimizeMiniMap()
    {
        miniMapContainer.SetActive(true);
        maxMapContainer.SetActive(false);
        this.GetComponent<Camera>().fieldOfView = miniMapFOV;
        Time.timeScale = 1;
        transform.position = playerTransform.position + offset;
    }

}
