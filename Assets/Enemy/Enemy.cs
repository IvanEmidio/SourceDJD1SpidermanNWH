using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    
    [SerializeField] private int damage;

    [Header ("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private float colliderDistance;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

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

        if(PlayerInsight())
        { 
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                print("Atack");
            }
        }
    }

    private bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x *range,boxCollider.bounds.size.y ,boxCollider.bounds.size.z), 0 , Vector2.left, 0, playerLayer);
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
        if(PlayerInsight())
        {

        }
    }
}
