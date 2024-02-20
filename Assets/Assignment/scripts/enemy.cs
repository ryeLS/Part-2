using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class enemy : MonoBehaviour
{//DECREASES DRAGON HEALTH IF DAMAGE TAKEN AND SHOWS DEATH CLIP
    public float maxhealth = 10f;
    public float health;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoseHealth(float damage)
    {
        
        health -= damage;
        health = Mathf.Clamp(health, 0, maxhealth);
        if(health <= 0)
        {
            animator.SetTrigger("Wasted");
        }
    }
}
