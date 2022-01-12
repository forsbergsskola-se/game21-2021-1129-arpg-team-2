using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapCamera : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] private Vector3 offset;
    Vector3 velocity;
    [SerializeField] private int miniMapSize;
    [SerializeField] private int maxMapSize;
    [SerializeField] private GameObject miniMapContainer;
    [SerializeField] private GameObject maxMapContainer;
    [SerializeField] private Vector3 miniMapPosCrypt;
    [SerializeField] private Vector3 miniMapPosFarm;
    [SerializeField] private Vector3 miniMapPosForst;
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
            if (SceneManager.GetActiveScene().name == "Farmland_NEW_MAIN")
            {
                transform.position = new Vector3(miniMapPosFarm.x, miniMapPosFarm.y, miniMapPosFarm.z);
            }
            else if (SceneManager.GetActiveScene().name == "Level_Crypt")
            {
                transform.position = new Vector3(miniMapPosCrypt.x, transform.position.y, miniMapPosCrypt.z);
            }
            else if (SceneManager.GetActiveScene().name == "ForestNew")
            {
                transform.position = new Vector3(miniMapPosForst.x, transform.position.y, miniMapPosForst.z);
            }

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
        this.GetComponent<Camera>().orthographicSize = maxMapSize;
        Time.timeScale = 0;
    }

    private void MinimizeMiniMap()
    {
        miniMapContainer.SetActive(true);
        maxMapContainer.SetActive(false);
        this.GetComponent<Camera>().orthographicSize = miniMapSize;
        Time.timeScale = 1;
        transform.position = playerTransform.position + offset;
    }

}
