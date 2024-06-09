using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMoves : MonoBehaviour
{
    [SerializeField] private Transform Down;
    private Vector3 DownEdgePos;

    [SerializeField] private Transform Up;
    private Vector3 UpEdgePos;

    [Header ("Movement parameters")]
    [SerializeField] private float speed;

    private Vector3 initScale;

    private bool movingDown;

    private void Awake()
    {
        initScale = transform.localScale;
    }

    private void Start()
    {
        initScale = transform.localScale;
        DownEdgePos = Up.position;
        UpEdgePos = Down.position;
    }


    private void Update()
    {
        if (movingDown)
        {
            if(transform.position.y >= UpEdgePos.y)
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(transform.position.y <= DownEdgePos.y)
                MoveInDirection(1);
            else
                DirectionChange();
        }
        
    }

    private void DirectionChange()
    {
        movingDown = !movingDown;
    }
    
    private void MoveInDirection(int _direction)
    {
        // Make enemy face direction
        //transform.localScale = new Vector3(initScale.x, Mathf.Abs(initScale.y) * _direction, initScale.z);

        // Move in that direction
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * _direction * speed, transform.position.z);
    }   
}
