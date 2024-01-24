using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimeText : MonoBehaviour
{
    public Text lifeTimeText;

    private float lifeTime;

    private void Update()
    {
        lifeTime = GameManager.I.lifeTime;
        lifeTimeText.text = "생존시간(초): " + lifeTime.ToString("F2");
    }

}
