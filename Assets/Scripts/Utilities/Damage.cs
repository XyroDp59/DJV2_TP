using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter(Collider other)
    {
        Health h;
        if(other.TryGetComponent(out h)){
            h.AddHealth(-1 * damage);
        }
        Destroy(gameObject);
    }

}
