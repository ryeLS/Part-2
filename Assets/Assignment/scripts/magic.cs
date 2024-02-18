using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour
{
    public float speed = 3;
    Rigidbody2D rb;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D()
    {
        Destroy(ball);
    }
}
