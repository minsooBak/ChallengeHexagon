using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public EventManager EventManager { get; private set; }
    public AudioManager AudioManager { get; private set; }
    
    public float lifeTime = 0f;

    private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();

    private SaveDatas _saveDatas;

    public event Action OnGame;
    public event Action EndGame;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
            DontDestroyOnLoad(this);
            AudioManager = gameObject.AddComponent<AudioManager>();
            _saveDatas = gameObject.AddComponent<SaveDatas>();
            EventManager = gameObject.AddComponent<EventManager>();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }


    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if (_saveDatas._saveData == null)
            return;
        var temp = _saveDatas._saveData.bestLifeTime;
        _saveDatas._saveData.bestLifeTime = temp > lifeTime ? temp : lifeTime;
        lifeTime = 0;
        OnGame = null;
        EndGame = null;
        Time.timeScale = 1;
        if(scene.buildIndex == 1)
        {
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        while(true)
        {
            lifeTime += Time.deltaTime;
            OnGame?.Invoke();
            yield return fixedUpdate;
        }
    }

    public void CallEndGame()
    {
        Time.timeScale = 0;
        EndGame?.Invoke();
        StopAllCoroutines();
    }
}
