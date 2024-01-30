using System;
using UnityEngine;

public class CharacterBaseController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;


    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }

}