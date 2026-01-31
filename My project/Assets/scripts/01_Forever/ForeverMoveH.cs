using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと、移動する（水平）

public class ForeverMoveH : MonoBehaviour
{
    public float speed = 1;

    void FixedUpdate()
    {
		// 右に動く
        // transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

		transform.Translate(speed * Time.deltaTime, 0, 0);

		// 左に動く
		// transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }
}
