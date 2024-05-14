using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] shoot;
    private Animator anim;
    private PlayerMovemente_Test playerMovement;

    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovemente_Test>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && cooldownTimer > attackcooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        
        cooldownTimer = 0;
        //pool
        shoot[0].transform.position = firepoint.position;
        shoot[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int FindShoot()
    {
        for(int i = 0; i < shoot.Length; i++)
        {
            if(!shoot[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    
    
}