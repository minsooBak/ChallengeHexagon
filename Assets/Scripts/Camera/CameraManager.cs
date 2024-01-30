using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Transform _transform;

    [Header("Camera Settings")]
    [SerializeField] [Range(1, 90)] private float _tiltAngle = 1f;
    [SerializeField] [Range(0f, 10f)] private float _rotationSpeed = 1.0f;
    [SerializeField] [Range(20f, 35)] private float _zoomAmount = 20f;
    [SerializeField] private bool _isClockwise = true; // true = �ð����, false = �ݽð����


    private float _rotationAngle = 0f;
    private float _zoomDestination = 0f;
    private float _zoomSpeed = 0f;

    private Vector3 _worldOrigin = Vector3.zero;
    private Vector3 _headDirecton =Vector3.zero;

    private float _cameraX = 0f;
    private float _cameraY = 0f;
    private float _cameraZ = 0f;

    private bool _isAnimationEnd;

    private float Temp { get; set;}

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        _transform = mainCamera.GetComponent<Transform>();
    }


    private void Start()
    {
        _tiltAngle = 1f;
        _rotationSpeed = 1.0f;
        _zoomAmount = 20f;
        _zoomDestination = _zoomAmount;
        _zoomSpeed = 1.0f;
        _isClockwise = true;
        _isAnimationEnd = true;
        GameManager.I.OnGame += CameraMove;
    }

    private void CameraMove()
    {
        UpdateAngles();
        UpdatePositions();
        UpdateCameraPosition();
        UpdateCameraRotation();
        UpdateZoom();
    }

    private void UpdateAngles()
    {
        _rotationAngle += _rotationSpeed * ReturnDirection(_isClockwise);
    }

    private void UpdatePositions()
    {
        _cameraX = Mathf.Sin(_tiltAngle * Mathf.Deg2Rad) * Mathf.Cos(_rotationAngle * Mathf.Deg2Rad) * _zoomAmount;
        _cameraY = Mathf.Sin(_tiltAngle * Mathf.Deg2Rad) * Mathf.Sin(_rotationAngle * Mathf.Deg2Rad) * _zoomAmount;
        _cameraZ = Mathf.Cos(_tiltAngle * Mathf.Deg2Rad) * _zoomAmount * (-1);
        mainCamera.orthographicSize = _zoomAmount;
        _headDirecton = new Vector3(0f, 0f, _cameraZ);
    }

    private void UpdateCameraPosition()
    {
        _transform.position = new Vector3(_cameraX, _cameraY, _cameraZ);
    }

    private void UpdateCameraRotation()
    {
        _transform.rotation = Quaternion.LookRotation(_worldOrigin - _transform.position, _headDirecton);
        _transform.rotation = new Quaternion(0, 0, _transform.rotation.z, _transform.rotation.w);
    }

    private void UpdateZoom()
    {
        _zoomAmount = Mathf.Lerp(_zoomAmount, _zoomDestination, Time.deltaTime * _zoomSpeed);
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
        if (random == 0 && _isAnimationEnd)
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
        _isAnimationEnd = false;
        Temp = _rotationSpeed;
        _rotationSpeed = amount;
        _isClockwise = direction;

        Invoke("SetrotationSpeedTemp", time);
    }



    private void ZoomInOutSustain(bool isOut = true, float time = 3.0f, float amount = 5.0f, float speed = 1.0f)
    {
        _isAnimationEnd = false;
        Temp = _zoomAmount;

        if (isOut)
        {
            Debug.Log("ZoomOut");
            ZoomOut(amount, speed);
        }
        else
        {
            Debug.Log("ZoomIn");
            ZoomIn(amount, speed);
        }

        Invoke("SetZoomDestinationTemp", time);
    }

    private void ZoomIn(float amount, float speed)
    {
        _zoomDestination = _zoomAmount - amount;
        _zoomSpeed = speed;
    }

    private void ZoomOut(float amount, float speed)
    {
        _zoomDestination = _zoomAmount + amount;
        _zoomSpeed = speed;
    }

    private void SetZoomDestinationTemp()
    {
        _zoomDestination = Temp;
        _zoomSpeed = 5.0f;
        Invoke("SetZoomAmountTemp", 1.0f);
    }
    private void SetZoomAmountTemp()
    {
        _zoomAmount = Temp;
        _zoomDestination = _zoomAmount;
        _zoomSpeed = 1.0f;
        Invoke("SetAnimationEnd", 1.0f);
    }

    private void SetrotationSpeedTemp()
    {
        _rotationSpeed = Temp;
        Invoke("SetAnimationEnd", 1.0f);
    }


    private void SetAnimationEnd()
    {
        _isAnimationEnd = true;
    }



}


