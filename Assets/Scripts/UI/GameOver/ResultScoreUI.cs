using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentRecordText : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text.text = GameManager.I.lifeTime.ToString("F2") + " s";
    }
}
