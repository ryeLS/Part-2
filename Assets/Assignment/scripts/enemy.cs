using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class enemy : MonoBehaviour
{
    public float maxhealth = 10f;
    public float health;
    Animator animator;
    public Color colourA; //british spelling is better
    public Color colourB;
    public SpriteRenderer sr;
    public float interpol;
    public float timelerp = 1f;
    public AnimationCurve curve;
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
            timelerp = timelerp + Time.deltaTime;
            interpol = curve.Evaluate(timelerp);
            sr.color = Color.Lerp(sr.color, colourB, interpol);
        }
        //else
        //{

        //}
    }
}
