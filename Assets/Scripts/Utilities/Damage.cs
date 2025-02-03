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
            h.AddHealth(-1*damage);
            return;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Health h; Damage d;
        if (collision.gameObject.TryGetComponent(out h))
        {
            h.AddHealth(-1 * damage);
            return;
        }
    }

}
