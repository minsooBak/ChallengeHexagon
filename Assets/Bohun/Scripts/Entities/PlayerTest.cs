using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ���� ����
    public float rotationSpeed = 180f; // ȸ�� �ӵ� ���� ����

    void Update()
    {
        // �¿� �̵� ó��
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // 6������ ���� ����
        float rotationAmount = -horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
