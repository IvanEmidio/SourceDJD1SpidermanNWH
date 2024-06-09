using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage = 1;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] shoot;


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

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                
                //anim.SetTrigger("rangedAttack");
            }
            
        }
        if(PlayerInSight())
        {
            RangedAttack();
        }

        if (enemyPatrol != null) enemyPatrol.enabled = !PlayerInSight();
        
        
        if(health <= 0)
        {
            Die();
        }
        
    }


    private void RangedAttack()
    {
        cooldownTimer = 0;
        shoot[FindShoot()].transform.position = firepoint.position;
        shoot[FindShoot()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindShoot()
    {
        for (int i = 0; i < shoot.Length; i++)
        {
            if(!shoot[i].activeInHierarchy)
              return i;
        }

        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        
        
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x *range,boxCollider.bounds.size.y ,boxCollider.bounds.size.z));
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
