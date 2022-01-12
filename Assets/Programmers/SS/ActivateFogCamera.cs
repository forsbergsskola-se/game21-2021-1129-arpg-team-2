using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ActivateFogCamera : MonoBehaviour
{
    
    public bool AllowFog = true;

    private void Start()
    {
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
    }

    void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        // Put the code that you want to execute before the camera renders here
        // If you are using URP or HDRP, Unity calls this method automatically
        // If you are writing a custom SRP, you must call RenderPipeline.BeginCameraRendering
        if(camera== GetComponent<Camera>())
        {
            RenderSettings.fog = false;
        }
        
    }
    void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        
            //FogOn = RenderSettings.fog;
            RenderSettings.fog = AllowFog;
        

    }
    private void OnDestroy()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
    }


}
