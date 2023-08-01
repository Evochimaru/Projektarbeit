using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSeeThrough : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float enableSeeThroughAfter = 1.0f;


    private void Awake()
    {
        if(mainCamera == null) {
            mainCamera = GetComponent<Camera>();
        }

        if(mainCamera)
        {
            mainCamera.clearFlags = CameraClearFlags.SolidColor;
            mainCamera.backgroundColor = new Color(0, 0, 0, 0);
            StartCoroutine(ToggleSeeTrough(true));
        }

        else
        {
            Debug.LogError("Main camera needs to be referenced or added to this component");
        }
    }

private IEnumarator ToggleSeeTrough(bool enable)
{
    yield return new WaitForSecounds(enableSeeThroughAfter);
    PXR_Boundary.EnableSeeThroughManual(enable);
}

private void OnApplicationPause(bool pause){
    if (!pause){
        PXR_Boundary.EnableSeeThroughManual(true);
    }
}
}
