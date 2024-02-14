using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider slider;
    public void Start()
    {
        health = PlayerPrefs.GetFloat("Health", maxHealth);
    }
    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }
    
}
