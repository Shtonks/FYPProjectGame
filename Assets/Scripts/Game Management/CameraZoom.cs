using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private float cameraDist;
    public float sensitivity = 10f;
    public float zoomInLimit = 14f;
    public float zoomOutLimit = 30f;

    private void Update() {
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && virtualCamera.m_Lens.OrthographicSize > zoomInLimit) {
                cameraDist = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
                virtualCamera.m_Lens.OrthographicSize -= cameraDist;
        } else if(Input.GetAxis("Mouse ScrollWheel") < 0 && virtualCamera.m_Lens.OrthographicSize < zoomOutLimit) {
                cameraDist = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
                virtualCamera.m_Lens.OrthographicSize -= cameraDist;
        }
    }
}
