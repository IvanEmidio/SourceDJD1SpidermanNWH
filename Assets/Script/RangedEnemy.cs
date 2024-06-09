using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage = 1;

    [Header("Ranged Attack")]
   // [SerializeField] private Transform firepoint;
    // [SerializeField] private GameObject[] shoot;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    [Header("Health")]
    [SerializeField] public int health;

    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private Patrol enemyPatrol;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        enemyPatrol = GetComponent<Patrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Attack only when player in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                //anim.SetTrigger("rangedAttack");
                
            }
        }

        if (enemyPatrol != null) 
            enemyPatrol.enabled = !PlayerInSight();

        if (health <= 0)
        {
            Die();
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
}

