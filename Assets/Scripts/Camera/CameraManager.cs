using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCamera;
    public static CameraManager I;

    Transform _transform;


    [Header("Camera Settings")]
    [SerializeField] [Range(1, 90)] float tiltAngle = 30f;
    [SerializeField] [Range(0f, 10f)] float rotationSpeed = 1.0f;
    [SerializeField] bool isClockwise = true; // true = �ð����, false = �ݽð����

    float rotationAngle = 0f;

    Vector3 worldOrigin = new Vector3(0f, 0f, 0f);
    Vector3 headDirecton = new Vector3(0f, 0f, 0f);

    float cameraX = 0f;
    float cameraY = 0f;
    float cameraZ = 0f;

    private void Awake()
    {
        _transform = mainCamera.GetComponent<Transform>();
        I = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!GameManager.I.isGameOver)
        {
            UpdateAngles();
            UpdatePositions();
            UpdateCameraPosition();
            UpdateCameraRotation();
        }
    }

    private void UpdateAngles()
    {
        rotationAngle += rotationSpeed * ReturnDirection(isClockwise);
    }

    private void UpdatePositions()
    {
        cameraX = Mathf.Sin(tiltAngle * Mathf.Deg2Rad) * Mathf.Cos(rotationAngle * Mathf.Deg2Rad) * 10f;
        cameraY = Mathf.Sin(tiltAngle * Mathf.Deg2Rad) * Mathf.Sin(rotationAngle * Mathf.Deg2Rad) * 10f;
        cameraZ = Mathf.Cos(tiltAngle * Mathf.Deg2Rad) * 10f * (-1);
        headDirecton = new Vector3(0f, 0f, cameraZ);
    }

    private void UpdateCameraPosition()
    {
        _transform.position = new Vector3(cameraX, cameraY, cameraZ);
    }

    private void UpdateCameraRotation()
    {
        _transform.rotation = Quaternion.LookRotation(worldOrigin - _transform.position, headDirecton);
    }

    private int ReturnDirection(bool clockwise)
    {
        if (clockwise)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    
}


