using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
   // [SerializeField] GameObject healthBar;
    private float currentHealth;

    public UnityEvent Die;

    void Start()
    {
        SetMaxHealth(maxHealth);
    }

    public float AddHealth(float health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
        Debug.Log(gameObject.name + " " + currentHealth);
        if(currentHealth <= 0) Destroy(gameObject);
        return currentHealth;
    }

    private void OnDestroy()
    {
        Die.Invoke();
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = health;
    }
}
