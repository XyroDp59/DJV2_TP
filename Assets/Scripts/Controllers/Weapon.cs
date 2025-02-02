using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform body;

    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Ammo bullet;
    [SerializeField] float bulletFrequency;
    [SerializeField] float bulletSpeed;

    Coroutine behaviourCoroutine;

   // Start is called before the first frame update
   void OnEnable()
    {
        WaitForSeconds delay = new WaitForSeconds(1/bulletFrequency);
        behaviourCoroutine = StartCoroutine(ShootBullet());
        IEnumerator ShootBullet()
        {
            while (true)
            {
                Ammo _bullet = Instantiate(bullet, bulletSpawnPoint.position, body.rotation);
                _bullet.SetSpeedAndDir(bulletSpeed, transform.forward);
                yield return delay;
            }
        }
    }

    private void OnDisable()
    {
        StopCoroutine(behaviourCoroutine);
    }
}
