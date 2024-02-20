using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class enemy : MonoBehaviour
{
    public float maxhealth = 10;
    public float health;
    Animator animator;
    public Color colourA; //british spelling is better
    public Color colourB;
    public SpriteRenderer sr;
    public float interpol;
    public float timelerp;
    AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = maxhealth;
        sr = GetComponent<SpriteRenderer>();
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
            interpol = curve.Evaluate(timelerp);
            timelerp = Time.deltaTime;
            sr.color = Color.Lerp(colourA, colourB, interpol);
        }
        else
        {

        }
    }
}
