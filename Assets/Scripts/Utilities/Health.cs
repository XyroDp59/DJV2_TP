using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] private HealthBar healthBar;
    // [SerializeField] GameObject healthBar;
    private float currentHealth;

    public UnityEvent Die;
    public UnityEvent OnTakeDamage;

    void Start()
    {
        SetMaxHealth(maxHealth);
    }

    public float AddHealth(float health)
    {
        if(health < 0) OnTakeDamage.Invoke();
        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
//        Debug.Log(gameObject.name + " " + currentHealth);

        if (!healthBar.gameObject.activeSelf) { healthBar.gameObject.SetActive(true); }
        healthBar.UpdateFill(((float)currentHealth) / ((float)maxHealth));
        
        if (currentHealth <= 0) Destroy(gameObject);
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
