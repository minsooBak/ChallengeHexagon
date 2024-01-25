using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    /// <summary>
    /// 키보드 입력 A /D 
    /// </summary>
    /// <param name="value">좌우 백터값</param>
    //public void OnMove(InputValue value)
    //{
    //    Vector2 dirVec = value.Get<Vector2>().normalized;
    //    Debug.Log(dirVec);
    //    Debug.Log("Move");
    //    CallMoveEvent(dirVec);
    //}
    /// <summary>
    /// 마우스 우클릭
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnRightClick(InputValue inputValue)
    {
        Vector2 dirVec = Vector2.right;
       
        if (!inputValue.isPressed)
        {
            dirVec = Vector2.zero;
        }
        CallMoveEvent(dirVec);
    }
    /// <summary>
    /// 마우스 좌 클릭
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnLeftClick(InputValue inputValue)
    {
        Vector2 dirVec = Vector2.left;
        
        if (!inputValue.isPressed)
        {
            dirVec = Vector2.zero;
        }
        CallMoveEvent(dirVec);
    }
}
