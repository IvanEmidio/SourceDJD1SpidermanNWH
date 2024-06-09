using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBossLevel : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; set;}
    

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
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
              
        }
        
    }

}

