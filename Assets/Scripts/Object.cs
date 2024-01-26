using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Object : MonoBehaviour
{
    public GameObject wall;
    [SerializeField]private GameObject[] objWalls;

    public int Layer { get; set; }

    private void Update()
    {
        if (transform.localScale.x < 1)
            gameObject.SetActive(false);
    }

    //TODO
    //������Ʈ Ǯ������ �������� ���� ��Ű�� ��ġ �ʱ�ȭ ������

    public void TakeOutWall(int speed, int damage)
    {
        GameObject obj = ObjectPool.instance.SpawnFromPool("Wall");
        obj.transform.parent = transform;
        obj.GetComponent<Wall>().Init(speed, damage);
        obj.SetActive(true);
        obj.GetComponent<Wall>().Setting(Layer);

        for (int i = 0; i < objWalls.Length; i++)
        {
            if (objWalls[i].activeSelf == false)
            {
                objWalls[i].GetComponent<Wall>().Init(speed, damage);
                objWalls[i].SetActive(true);
                break;
            }
        }
    }

    public void SettingData(WallEventData data)
    {
        for (int i = 0; i < objWalls.Length; i++)
        {
            if (objWalls[i].activeSelf == false)
            {
                objWalls[i].GetComponent<Wall>().SettingData(data);
                break;
            }
        }
    }

    /*public void CreateWall(int count, int layer)
    {
        objWalls = new GameObject[count];
        for (int i = 0; i < count; i++) 
        {
            objWalls[i] = Instantiate(wall, transform);
            var w = objWalls[i].GetComponent<Wall>();
            w.Setting(layer);
            objWalls[i].SetActive(false);
        }
    }*/
}
