using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 3f;
    private float playerSpeed;

    Rigidbody2D rigidbody2D;

    float minX;
    float maxX;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        // カメラの端をワールド座標で取得
        Camera cam = Camera.main;
        Vector3 left = cam.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        Vector3 right = cam.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));

        minX = left.x;
        maxX = right.x;
    }


    void Update()
    {
        // 左キー
        if (Input.GetKey(KeyCode.LeftArrow)) playerSpeed = -speed;
        // 右キー
        else if (Input.GetKey(KeyCode.RightArrow)) playerSpeed = speed;
        // キーを離したら停止
        else playerSpeed = 0;

        rigidbody2D.linearVelocity = new Vector2(playerSpeed, rigidbody2D.linearVelocity.y);

        // ★ ここで位置を制限する
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }

}
