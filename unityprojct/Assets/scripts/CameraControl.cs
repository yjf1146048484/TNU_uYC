using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("跟蹤目標")]
    public Transform target;
    [Header("跟蹤速度"), Range(0f, 100)]
    public float speed = 1.5f;

    private void Track()
    {
        float limity = Mathf.Clamp(target.position.y, -1f, 3f);
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.3f * speed * Time.deltaTime);
    }


    private void LateUpdate()
    {
        Track();
    }
}
