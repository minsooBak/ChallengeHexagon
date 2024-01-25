using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectManager : MonoBehaviour
{
    //TODO : 오브젝트클래스에 생성과 생성 수 넘겨주기
    public GameObject map;
    public Object[] objects;

    private Animator _animator;
    //private int phaseLevel = 1;
    [SerializeField] private float _dealy = 5f;
    private void Awake()
    {
        Instantiate(map, transform);
        objects = GetComponentsInChildren<Object>();
        _animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        int r = 0;
        int s = Random.Range(5, 20);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Object obj in objects)
            {
                obj.CreateWall(s, ++r);
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("1_Disabled");
        }else if(Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("1_Active");
        }
    }
}
