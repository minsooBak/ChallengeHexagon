using UnityEngine;

public class LightEvent : MonoBehaviour
{
    [SerializeField] private float _dealy = 5f;

    private Light _light;
    private float _time = 5f;
    private Color _curColor = Color.white;

    private void Start()
    {
        _light = GetComponent<Light>();
        GameManager.I.OnGame += ColorChange;
    }

    private void ColorChange()
    {
        _time += Time.deltaTime;
        if(_time >= _dealy )
        {
            _time = 0;
            _curColor = new Color(Random.value, Random.value, Random.value);
        }
        _light.color = Color.Lerp(_light.color, _curColor, _time / _dealy);
    }
}
