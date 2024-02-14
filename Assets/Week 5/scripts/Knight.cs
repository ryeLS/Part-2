using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        health = PlayerPrefs.GetFloat("Health", maxhealth);
        
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
        if(Input.GetMouseButtonDown(0)&& !clickOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
        animator.SetFloat("movement",movement.magnitude);
        
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickOnSelf = true;
        SendMessage("TakeDamage", 1);
    }
    private void OnMouseUp() 
    {
        clickOnSelf = false;
    }
    public void TakeDamage(float damage)
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
        PlayerPrefs.SetFloat("Health", health);
        PlayerPrefs.Save();

    }
}
