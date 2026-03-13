using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 3f;
    private float playerSpeed;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���L�[���������獶�����֐i��
        if (Input.GetKey(KeyCode.LeftArrow)) playerSpeed = -speed;
        // �E�L�[����������E�����֐i��
        else if (Input.GetKey(KeyCode.RightArrow)) playerSpeed = speed;
        // ���������Ȃ�������~�܂�
        else playerSpeed = 0;

        rigidbody2D.linearVelocity = new Vector2(playerSpeed, rigidbody2D.linearVelocity.y);
    }
}
