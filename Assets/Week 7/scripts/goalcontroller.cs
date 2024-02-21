using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalcontroller : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 goaldirection;
    public Vector2 dist;
    public Transform goalCenter;
    public Transform player;
    public float distanceOffGoalLine = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = goalCenter.position + controller.CurrentSelection;
    
        Vector3 directionToPlayer = (player.position - goalCenter.position).normalized;


        Vector3 newPosition = goalCenter.position + directionToPlayer * distanceOffGoalLine;


        transform.position = newPosition;

    }
}
