using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runway : MonoBehaviour
{
    BoxCollider2D boxCollider;
    public Vector2 plane;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.OverlapPoint(plane);
    }
}
