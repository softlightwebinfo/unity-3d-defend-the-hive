using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private Slider healthBar;
    public static float currentHealth;

    private void Awake()
    {
        this.healthBar = GetComponent<Slider>();
        this.healthBar.maxValue = 100;
        currentHealth = 100;
    }

    public void ReduceHealth()
    {
        currentHealth -= 50f;
        this.healthBar.value = currentHealth;
    }

    private void Update()
    {
        this.healthBar.value = currentHealth;
    }
}
