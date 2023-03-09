using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineComponentBase componentBase;
    private float cameraDist;
    public float sensitivity = 10f;

    private void Update() {
        if(componentBase == null) {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        // TO DO: upper and lower must be added to zoom level

        if(Input.GetAxis("Mouse ScrollWheel") != 0) {
            cameraDist = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            virtualCamera.m_Lens.OrthographicSize -= cameraDist;
            // if(componentBase is CinemachineFramingTransposer) {
            //     (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDist;
            //     // Debug.Log("ZOOMINNNNNNNNNN");
            // }
        }
    }
}
