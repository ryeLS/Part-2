using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ASSETS- magic orb - https://opengameart.org/content/particle-effects
// BIRD AND BACKGROUND BY ME
public class bird : MonoBehaviour
    //PLAYER MOVEMENT AND ANIMATIONS
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Animator animator;
    public Transform player;
    public GameObject magicPrefab;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {//MOVE
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);//LEFT CLICK MOVES CHARACTER TO MOUSE POS
        }
        if(movement.x != 0 || movement.y != 0)
        {//VALUES FOR ANIMATION CLIPS TO MOVE PROPERLY
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(1))
        {//CLIP FOR ATTACKING
            animator.SetTrigger("Attack");
            Instantiate(magicPrefab, player.position, player.rotation);
        }
    }
}
