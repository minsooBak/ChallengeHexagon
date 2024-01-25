using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCamera;
    public static CameraManager I;

    private Transform _transform;
    private Camera _camera;

    private void Awake()
    {
        _transform = mainCamera.GetComponent<Transform>();
        _camera = mainCamera.GetComponent<Camera>();
        I = this;
    }

}
