using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bawlplayer : MonoBehaviour
{
    public SpriteRenderer sr;
    
    public Color original;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
       Selected(true);
    }
    private void Selected(bool clickSelf)
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
}
