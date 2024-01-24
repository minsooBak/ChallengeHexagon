using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절 변수
    public float rotationSpeed = 180f; // 회전 속도 조절 변수

    void Update()
    {
        // 좌우 이동 처리
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // 6각형을 따라 돌기
        float rotationAmount = -horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
