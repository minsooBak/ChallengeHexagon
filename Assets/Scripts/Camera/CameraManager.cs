using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public static CameraManager I;
    
    Transform _transform;


    [Header("Camera Settings")]
    [SerializeField] [Range(1, 90)] float tiltAngle = 1f;
    [SerializeField] [Range(0f, 10f)] float rotationSpeed = 1.0f;
    [SerializeField] [Range(10f, 25f)] public float zoomAmount = 10f;
    [SerializeField] bool isClockwise = true; // true = �ð����, false = �ݽð����


    float rotationAngle = 0f;

    Vector3 worldOrigin = Vector3.zero;
    Vector3 headDirecton =Vector3.zero;

    float cameraX = 0f;
    float cameraY = 0f;
    float cameraZ = 0f;

    bool isAnimationEnd;

    float Temp { get; set;}

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        _transform = mainCamera.GetComponent<Transform>();
        I = this;
    }


    private void Start()
    {
        tiltAngle = 1f;
        rotationSpeed = 1.0f;
        zoomAmount = 10f;
        isClockwise = true;
        isAnimationEnd = true;
    }

    private void Update()
    {
        if (!GameManager.I.isGameOver)
        {
            UpdateAngles();
            UpdatePositions();
            UpdateCameraPosition();
            UpdateCameraRotation();
            CheckAnimationProbability();
        }
    }

    private void UpdateAngles()
    {
        rotationAngle += rotationSpeed * ReturnDirection(isClockwise);
    }

    private void UpdatePositions()
    {
        cameraX = Mathf.Sin(tiltAngle * Mathf.Deg2Rad) * Mathf.Cos(rotationAngle * Mathf.Deg2Rad) * zoomAmount;
        cameraY = Mathf.Sin(tiltAngle * Mathf.Deg2Rad) * Mathf.Sin(rotationAngle * Mathf.Deg2Rad) * zoomAmount;
        cameraZ = Mathf.Cos(tiltAngle * Mathf.Deg2Rad) * zoomAmount * (-1);
        mainCamera.orthographicSize = zoomAmount;
        headDirecton = new Vector3(0f, 0f, cameraZ);
    }

    private void UpdateCameraPosition()
    {
        _transform.position = new Vector3(cameraX, cameraY, cameraZ);
    }

    private void UpdateCameraRotation()
    {
        _transform.rotation = Quaternion.LookRotation(worldOrigin - _transform.position, headDirecton);
        _transform.rotation = new Quaternion(0, 0, _transform.rotation.z, _transform.rotation.w);
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

    private void CheckAnimationProbability()
    {
        int random = Random.Range(0, 100);
        if (random == 0 && isAnimationEnd)
        {
            int phase = Random.Range(0, 4);
            switch (phase)
            {
                case 0:
                    QuickTurn(false); // TurnLeft
                    break;
                case 1:
                    QuickTurn(); // TurnRight
                    break;
                case 2:
                    ZoomInOutSustain(); // ZoomOut
                    break;
                case 3:
                    ZoomInOutSustain(false); // ZoomIn
                    break;
            }
        }

    }

    private void QuickTurn(bool direction = true, float time = 0.8f, float amount = 10.0f)
    {
        isAnimationEnd = false;
        Temp = rotationSpeed;
        rotationSpeed = amount;
        isClockwise = direction;

        Invoke("SetRotationSpeedTemp", time);
    }



    private void ZoomInOutSustain(bool isOut = true, float time = 3.0f, float amount = 5.0f)
    {
        isAnimationEnd = false;
        Temp = zoomAmount;

        Debug.Log("ZoomInOutSustain");

        if (isOut)
        {
            zoomAmount += amount;
        }
        else
        {
            zoomAmount -= amount;
        }

        Invoke("SetZoomAmountTemp", time);
    }


    private void SetRotationSpeedTemp()
    {
        rotationSpeed = Temp;
        Invoke("SetAnimationEnd", 1.0f);
    }

    private void SetZoomAmountTemp()
    {
        zoomAmount = Temp;
        Invoke("SetAnimationEnd", 1.0f);
    }

    private void SetAnimationEnd()
    {
        isAnimationEnd = true;
    }



}


