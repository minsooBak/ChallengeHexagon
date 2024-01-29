using UnityEngine;
using UnityEngine.UI;

public class LifeTimeText : MonoBehaviour
{
    [SerializeField] private Text lifeTimeText;

    private float lifeTime;

    private void Update()
    {
        lifeTime = GameManager.I.lifeTime;
        lifeTimeText.text = lifeTime.ToString("F2");
    }

}
