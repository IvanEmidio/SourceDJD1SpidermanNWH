using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBossLevel : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; set;}
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
                if(GetComponent<PlayerBoss>() != null)
                    GetComponent<PlayerBoss>().enabled = false;

                //Enemy
                if(GetComponentInParent<GoblinMoves>() != null)
                    GetComponentInParent<GoblinMoves>().enabled = false;

                dead = true; 


            }
            //Player Dies
              
        }
        
    }

}

