using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]private float _speed = 5f;
    void Update()
    {
        if (transform.localPosition.y >= 0.56f)
        {
            gameObject.SetActive(false);
        }
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _speed * Time.deltaTime);
    }

    public void Setting(int layer)
    {
        GetComponent<SpriteRenderer>().sortingOrder = layer;
    }

    public void Init(int speed)
    {
        _speed = speed;
        transform.localPosition = new Vector3(0, -0.4f, 0);
    }
}
