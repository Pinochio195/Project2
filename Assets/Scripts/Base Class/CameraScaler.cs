using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float targetAspectRatio; // Tỉ lệ màn hình 16:9
    public CinemachineVirtualCamera virtualCamera;

    //3d
    private float defaultVerticalFOV = 60f; // FOV dọc mặc định cho tỉ lệ 16:9

    private void Awake()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float scaleRatio = targetAspectRatio / currentAspectRatio;
        float fovAdjustment = Mathf.Atan(Mathf.Tan(defaultVerticalFOV * Mathf.Deg2Rad * 0.5f) * scaleRatio) * 2f *
                              Mathf.Rad2Deg;
        virtualCamera.m_Lens.FieldOfView = fovAdjustment;
    }
}