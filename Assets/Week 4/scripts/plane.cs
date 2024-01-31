using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rb;
    public float speed;
    public AnimationCurve landing;
    float landingTimer;
    Vector3 ranPosition;
    float ranRotation;
    public List<Sprite> sprite;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        speed = Random.Range(1, 3);
        ranPosition.x = Random.Range(-5, 5);
        ranPosition.y = Random.Range(-5, 5);
        ranPosition.z = 0;
        ranRotation = Random.Range (0, 360);
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        transform.position = ranPosition;
        transform.rotation = Quaternion.Euler(0, 0, ranRotation);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite[Random.Range(0, sprite.Count)];
    }
    void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }
        rb.MovePosition(rb.position + (Vector2) transform.up * speed * Time.deltaTime);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.05f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }
        lineRenderer.SetPosition(0, transform.position);
        if(points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);
                for(int i =0; i < lineRenderer.positionCount-2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));
                }
                lineRenderer.positionCount--;
                
            }
        }
    }
    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }
    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        if(Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount -1, newPosition);
            lastPosition = newPosition;
        }
    }
}
