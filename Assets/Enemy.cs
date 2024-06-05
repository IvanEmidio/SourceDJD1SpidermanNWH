using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes.Test;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage = 1;

    [Header("Collider Parameters")]
    
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] public int health;

    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            Debug.Log("Player In Sight");
            if (cooldownTimer >= attackCooldown)
            {
                Debug.Log("melee");
                cooldownTimer = 0;
                anim.SetTrigger("meeleAttack");
            }
            else
            {
                Debug.Log("cooldown not set");
            }
        }

        if(health <= 0)
        {
            Die();
        }
    }


    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x *range,boxCollider.bounds.size.y ,boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damage);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
