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
        currentHealth = maxHealth;
    }

    public float AddHealth(float health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
        if(health <= 0) Destroy(gameObject);
        return health;
    }

    private void OnDestroy()
    {
        Die.Invoke();
    }
}
