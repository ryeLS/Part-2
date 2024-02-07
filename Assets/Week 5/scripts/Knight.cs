using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Animator animator;
    bool clickOnSelf = false;
    public float maxhealth = 5;
    public float health;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxhealth;
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        {
            
        }
        movement = destination-(Vector2)transform.position;
        
        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if(Input.GetMouseButtonDown(0)&& !clickOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("movement",movement.magnitude);
        
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickOnSelf = true;
        TakeDamage(1);
    }
    private void OnMouseUp() 
    {
        clickOnSelf = false;
    }
    void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxhealth);
        if(health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Wasted");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("takeDamage");
        }

    }
}
