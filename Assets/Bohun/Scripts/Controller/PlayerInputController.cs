using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    public void OnMove(InputValue value)
    {
        Vector2 dirVec = value.Get<Vector2>().normalized;
        Debug.Log("Move");
        CallMoveEvent(dirVec);
    }
    public void OnRightClick(InputValue value)
    {

    }
}
