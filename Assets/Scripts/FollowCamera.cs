using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float degree;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, ball.position, degree);
        transform.LookAt(ball);
    }
}
