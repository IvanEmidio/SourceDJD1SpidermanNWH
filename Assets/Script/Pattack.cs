using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] shoot;
    private Animator anim;
    private PlayerBoss playerMovement;

    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerBoss>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && cooldownTimer > attackcooldown && playerMovement.canAttack() && playerMovement.currentstamina >= playerMovement.attackcost)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        
        cooldownTimer = 0;
        //pool
        shoot[FindShoot()].transform.position = firepoint.position;
        shoot[FindShoot()].GetComponent<Project>().SetDirection(Mathf.Sign(transform.localScale.x));

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
