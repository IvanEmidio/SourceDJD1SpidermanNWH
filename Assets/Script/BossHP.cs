using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private GameObject strange;
    public float currentHealth {get; set;}

    
    

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        Debug.Log("Ouch");
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            //Player Gets Hurt
        }
        else
        {
            strange.SetActive(true);
            Destroy(gameObject);

              
        }
        
    }

}