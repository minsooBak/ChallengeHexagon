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
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        AudioManager = gameObject.AddComponent<AudioManager>();
        _saveDatas = gameObject.AddComponent<SaveDatas>();
        EventManager = gameObject.AddComponent<EventManager>();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
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
        StopAllCoroutines();
        EndGame?.Invoke();
    }
}
