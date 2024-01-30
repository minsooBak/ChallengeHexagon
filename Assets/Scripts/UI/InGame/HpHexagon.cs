using UnityEngine;

public class HpHexagon : MonoBehaviour
{
    [SerializeField] private GameObject[] hexagon;


    private Vector3 minScale;
    private Vector3 originScale;
    private Vector3 targetPosX = Vector3.zero;
    private Vector3 targetPosY = Vector3.zero;
    private float chunk;
    private float timer;
    [SerializeField]private float zoomSpeed;
    private int bpm;
    private int count;

    private Player _player;
    


    private void Start()
    {
        originScale = hexagon[0].transform.localScale;
        _player = GameObject.Find("Player").GetComponent<Player>();
        chunk = 0f;
        bpm = 183;
        timer = 0f;
        count = 1;
        zoomSpeed = 100.0f;
    }

    private void Update()
    {
        SetScale();
        CheckBPM(bpm);
    }

    private void SetScale()
    {
        var temp = originScale;
        originScale = new Vector3(_player.HP / 2000f, _player.HP / 2000f, 1);
        if(temp != originScale)
        {
            targetPosX = Vector3.zero;
            targetPosY = Vector3.zero;
        }
        minScale = originScale * 0.9f;
    }

    private void CheckBPM(int bpm)
    {
        chunk = 60f / bpm;
        timer += Time.deltaTime;

        if (timer >= chunk * count)
        {
            MakeScaleMin();
            Invoke("MakeScaleOrigin", chunk / 3);
            count++;
        }
    }

    private void MakeScaleMin()
    {
        foreach(var item in hexagon)
        {
            var temp = item.transform.localScale;
            item.transform.localScale = Vector3.MoveTowards(originScale, minScale, Time.deltaTime * zoomSpeed);
            temp -= item.transform.localScale;
            if (targetPosX == Vector3.zero)
                targetPosX = item.transform.localPosition + (temp * 0.58f);
            item.transform.localPosition = Vector3.MoveTowards(item.transform.localPosition, new Vector3(0, targetPosX.y, 0), Time.deltaTime * zoomSpeed);
        }
    }

    private void MakeScaleOrigin()
    {
        foreach (var item in hexagon)
        {
            var temp = item.transform.localScale;
            item.transform.localScale = Vector3.MoveTowards(minScale, originScale, Time.deltaTime * zoomSpeed);
            temp -= item.transform.localScale;
            if (targetPosY == Vector3.zero)
                targetPosY = item.transform.localPosition + (temp * 0.58f);
            item.transform.localPosition = Vector3.MoveTowards(item.transform.localPosition, new Vector3(0, targetPosY.y, 0), Time.deltaTime * zoomSpeed);
        }
    }

}
