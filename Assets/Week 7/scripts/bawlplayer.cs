using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bawlplayer : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float speed = 100f;
    
    public Color original;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        controller.SetCurrentSelection(this);
    }
    public void Selected(bool clickSelf)
    {
        if (clickSelf)
        {
            sr.color = Color.yellow;
        }
        else
        {
            sr.color = original;
        }
    }
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
