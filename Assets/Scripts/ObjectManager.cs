using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjectManager : MonoBehaviour
{
    //TODO : ������ƮŬ������ ������ ���� �� �Ѱ��ֱ�
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
