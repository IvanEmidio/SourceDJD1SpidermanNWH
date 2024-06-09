using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private  Vector3 velocity = Vector3.zero;

    [SerializeField] private float leftLimit;

    [SerializeField] private float rightLimit;

    [SerializeField] private float upLimit;

    [SerializeField] private float downLimit;
    [SerializeField] private Transform target;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if(transform.position.x < leftLimit)
        {
            Vector3 pos = transform.position;
            pos.x = leftLimit;
            transform.position = pos;
        }

        if(transform.position.x > rightLimit)
        {
            Vector3 pos = transform.position;
            pos.x = rightLimit;
            transform.position = pos;
        }

        if(transform.position.y > upLimit)
        {
            Vector3 pos = transform.position;
            pos.y = upLimit;
            transform.position = pos;
        }

        if(transform.position.y < downLimit)
        {
            Vector3 pos = transform.position;
            pos.y = downLimit;
            transform.position = pos;
        }
    }
}
