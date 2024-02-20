using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{//ENEMY HEALTH. MOVES SLIDER BASED ON HEALTH
    public float health;
    public float currentHealth;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoseHealth(float damage)
    {

        slider.value -= damage;

    }
}
