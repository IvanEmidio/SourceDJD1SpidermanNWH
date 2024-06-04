using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovemente_Test : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private LayerMask wallLayer;
    [SerializeField] private float jump;

    [SerializeField] private Image StaminaBar;
    [SerializeField] private float currentstamina;
    [SerializeField] private float maxstamina;
    [SerializeField] private float attackcost;
    [SerializeField] private float Chargerate;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    private Animator anim;
    
    private Coroutine recharge;

    
    
    

    private void Awake()
    {
        // References from Unit
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");

        // Flipping the Character

        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(1.963776f,1.963776f, 1.963776f );
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1.963776f, 1.963776f, 1.963776f);

        // Setting Animations Parameters
        anim.SetBool("Run", horizontalInput != 0);
        
        //Wall Jump Logic
       if(wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            
            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else body.gravityScale = 7;

            if(Input.GetKey(KeyCode.Space)) 
                Jump();
            
        }
        else wallJumpCooldown += Time.deltaTime;

        if(Input.GetKeyDown("f"))
        {
            currentstamina -= attackcost;
            
            if(currentstamina < 0) currentstamina = 0;

            StaminaBar.fillAmount = currentstamina / maxstamina;

            if(recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());
        }
        
    }
    private void Jump()
    {
        // Jumping 
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jump);
        
        }
        // Crawl walls Mechanic
        else if (onWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z); 
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 5, 6);

            wallJumpCooldown = 0;
            
              
        }
            
       
        
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while(currentstamina < maxstamina)
        {
            currentstamina += Chargerate / 10f;
            if(currentstamina > maxstamina) currentstamina = maxstamina;

            StaminaBar.fillAmount = currentstamina / maxstamina;
            yield return new WaitForSeconds(.1f);
        }
    }
}
