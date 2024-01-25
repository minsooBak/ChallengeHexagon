using Unity.VisualScripting;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = 5f;
    public int Layers = 0;
    private SpriteRenderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Layers != 0)
        {
            _renderer.sortingOrder = Layers;
            Layers = 0;
        }
        if (transform.localPosition.y >= 0.54f)
        {
            Init();
        }
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
    }

    public void Init()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        _renderer.color = new Color(r, g, b);
        transform.localPosition = new Vector3(0, -0.4f, 0);
    }
}
