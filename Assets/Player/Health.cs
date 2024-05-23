using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            //Player Gets Hurt
        }
        else
        {
            if(!dead)
            {
                //Player
                if(GetComponent<PlayerMovemente_Test>() != null)
                    GetComponent<PlayerMovemente_Test>().enabled = false;

                //Enemy
                if(GetComponentInParent<Patrol>() != null)
                    GetComponentInParent<Patrol>().enabled = false;

                // if(GetComponent<Enemy>() != null)
                   // GetComponent<Enemy>().enabled = false;

                dead = true; 


            }
            //Player Dies
              
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
}
