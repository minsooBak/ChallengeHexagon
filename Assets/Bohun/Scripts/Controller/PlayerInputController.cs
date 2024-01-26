using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    public void OnMove(InputValue value)
    {
        Vector2 dirVec = value.Get<Vector2>().normalized;
        Debug.Log(dirVec);
        Debug.Log("Move");
        CallMoveEvent(dirVec);
    }

    public void OnRightClick(InputValue inputValue)
    {
        Vector2 dirVec = Vector2.right;
       
        if (!inputValue.isPressed)
        {
            dirVec = Vector2.zero;
        }
        CallMoveEvent(dirVec);
    }
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
