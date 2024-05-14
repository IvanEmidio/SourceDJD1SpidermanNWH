using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField]private float starting_Health;
    public float current_Health {get; private set;}

    private void Awake()
    {
        current_Health = starting_Health;
    }

    public void TakeDamage(float _damage)
    {
        current_Health = Mathf.Clamp(current_Health - _damage, 0, starting_Health);

        if(current_Health > 0)
        {

        }
        else
        {

        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}
