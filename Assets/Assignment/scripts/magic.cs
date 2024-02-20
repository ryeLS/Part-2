using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour
    //SCRIPT FOR MAGIC PROPERTIES; CLICK RIGHT MOUSE
{
    public float speed = 200f;
    public GameObject ball;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("LoseHealth", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
