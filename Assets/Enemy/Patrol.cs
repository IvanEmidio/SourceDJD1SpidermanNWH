using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    private Vector3 leftEdgePos;

    [SerializeField] private Transform rightEdge;
    private Vector3 rightEdgePos;

    [Header ("Movement parameters")]
    [SerializeField] private float speed;

    private Vector3 initScale;

    private bool movingLeft;

    private void Awake()
    {
        initScale = transform.localScale;
    }

    private void Start()
    {
        initScale = transform.localScale;
        leftEdgePos = leftEdge.position;
        rightEdgePos = rightEdge.position;
    }


    private void Update()
    {
        if (movingLeft)
        {
            if(transform.position.x >= leftEdgePos.x)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(transform.position.x <= rightEdgePos.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
        
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }
    
    private void MoveInDirection(int _direction)
    {
        // Make enemy face direction
        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        // Move in that direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed, transform.position.y, transform.position.z);
    }   
}
