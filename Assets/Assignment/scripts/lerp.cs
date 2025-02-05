using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class lerp : MonoBehaviour
    //LERP FOR MOVING DRAGON ONTO SCREEN
{
    public AnimationCurve curve;
    public Transform startPos;
    public Transform endPos;
    public float lerptimer;
    public float interpolation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interpolation = curve.Evaluate(lerptimer);
        transform.position = Vector3.Lerp(startPos.position, endPos.position, interpolation);
        lerptimer = lerptimer + Time.deltaTime;

    }
}
