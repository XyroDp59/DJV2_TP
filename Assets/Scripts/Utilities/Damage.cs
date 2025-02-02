using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health h;
        if(other.TryGetComponent(out h)){
            Debug.Log(other.gameObject.name + " : " + h.AddHealth(-1 * damage));
        }
        Destroy(gameObject);
    }

}
