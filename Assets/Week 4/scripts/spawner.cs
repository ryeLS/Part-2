using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject planePrefab;
    public Transform spawn;
    //float maxTime= 5f;
    //float minTime= 1f;
    float timer = 0f;
    float ranValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       ranValue= Random.Range(1f, 5f);
        timer += Time.deltaTime;
        if (timer >= ranValue)
        {
            timer = 0f;
            Instantiate(planePrefab, spawn.position, spawn.rotation);
        }
    }
}
