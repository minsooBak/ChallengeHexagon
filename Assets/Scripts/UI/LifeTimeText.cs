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
        lifeTimeText.text = lifeTime.ToString("F2");
    }

}
