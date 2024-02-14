using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lerptest : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform Startpos;
    public Transform Endpos;
    public float lerptimer;
    public float interpolation;
    public Color cola;
    public Color colb;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interpolation = curve.Evaluate(lerptimer);
        transform.position = Vector3.Lerp(Startpos.position, Endpos.position, interpolation);
        lerptimer = lerptimer + Time.deltaTime;
        sr.color = Color.Lerp(cola, colb, interpolation);
    }
}
