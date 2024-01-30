using UnityEngine;

public class Stage : MonoBehaviour
{
    public enum Level
    {
        point,
        line,
        triangle,
        square,
        pentagon,
        hexagon
    }

    private GameManager _gameManager;
    private ObjectManager _objectManager;
    private EventManager _eventManager;
    //TODO
    //private CameraManager _cameraManager;
    //private LightEvent light;

    public Level _level;

    private void Start()
    {
        _gameManager = GameManager.I;
        _eventManager = _gameManager.EventManager;
        _objectManager = GameObject.Find("ObjectManager").GetComponent<ObjectManager>();
        //_cameraManager = GameObject.Find("CameraManager").GetComponent<CameraManager>();
        //light = GameObject.Find("Light").GetComponent<LightEvent>();
        _gameManager.OnGame += WallUpdate;
    }

    private void WallUpdate()
    {
        LevelUpdater();
        TakeWall();
    }

    private void TakeWall()
    {
        if (_objectManager.CheckAnimationEnd())
        {
            _objectManager.CheckOut();
        }
    }

    private void LevelUpdater()
    {
        switch (_gameManager.lifeTime)
        {
            case < 10f:
                {
                    _level = Level.point;
                    MainStage(Random.Range(0, 101));
                    break;
                }
            case < 20f:
                {
                    if (_level == Level.point)
                    {
                        _objectManager.ObjectUpdate(4, 12, 7);
                        _objectManager.ChangeObject(1, false);
                    }
                    _level = Level.line;
                    MainStage(Random.Range(10, 101));
                    break;
                }
            case < 30f:
                {
                    if (_level == Level.line)
                    {
                        _objectManager.ObjectUpdate(3, 15, 10);
                        _objectManager.ChangeObject(1, true);
                    }
                    _level = Level.triangle;
                    MainStage(Random.Range(20, 101));
                    break;
                }
            case < 45f:
                {
                    if (_level == Level.triangle)
                    {
                        _objectManager.ObjectUpdate(2, 17, 15);
                        _objectManager.ChangeObject(1, false);
                        _objectManager.ChangeObject(2, false);
                    }
                    _level = Level.square;
                    MainStage(Random.Range(30, 101));
                    break;
                }
            case < 60f:
                {
                    if (_level == Level.square)
                    {
                        _objectManager.ObjectUpdate(2, 20, 20);
                        _objectManager.ChangeObject(2, true);
                    }
                    _level = Level.pentagon;
                    MainStage(Random.Range(40, 101));
                    break;
                }
            case >= 60f:
                {
                    if (_level == Level.pentagon)
                    {
                        _objectManager.ObjectUpdate(1.5f, 20, 30);
                        _objectManager.ChangeObject(1, true);
                    }
                    _level = Level.hexagon;
                    MainStage(Random.Range(50, 101));
                    break;
                }
        }
    }

    private void MainStage(int random)
    {
        if (random < 50 | _objectManager.GetEvent)
        {
            return;
        }
        _objectManager.SettingEvent(_eventManager.AddData(WallEvent.Damage, 10 * (int)_level));
        switch (random)
        {
            case < 75:
                {
                    int r = Random.Range(0, 2);
                    if (r == 0)
                    {
                        _objectManager.SettingEvent(_eventManager.AddData(WallEvent.SPEED_O, 2 * (int)_level));
                    }
                    else
                    {
                        _objectManager.SettingEvent(_eventManager.AddData(WallEvent.SPEED_P, 10 * (int)_level));
                    }
                    break;
                }
            case < 85:
                {
                    int r = Random.Range(0, 2);
                    if (r == 0)
                    {
                        _objectManager.SettingEvent(_eventManager.AddData(WallEvent.HP, 10 * (int)_level));
                    }
                    else
                    {
                        _objectManager.SettingEvent(_eventManager.AddData(WallEvent.HP_MAX, 10 * (int)_level));
                    }
                    break;
                }
            default:
                {
                    int r = Random.Range(0, 2);
                    if (r == 0)
                    {
                        _objectManager.SettingEvent(_eventManager.AddData(WallEvent.MIRROR, 10 * (int)_level));
                    }
                    else
                    {
                        _objectManager.SettingEvent(_eventManager.AddData(WallEvent.Damage, 10 * (int)_level));
                    }
                    break;
                }
        }
    }
}
