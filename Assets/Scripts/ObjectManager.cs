using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectManager : MonoBehaviour
{
    //TODO : 오브젝트클래스에 생성과 생성 수 넘겨주기
    public GameObject map;

    private void Awake()
    {
        Instantiate(map);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
