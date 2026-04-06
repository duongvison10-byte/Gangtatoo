using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyEnemy : Enemy
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float fireRate = 1f;

    protected float fireTimer;

    protected override void Update()
    {
        base.Update();
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage();
        }
    }

    protected void Shoot()
    {
        if (player == null) return;

        fireTimer += Time.deltaTime;

        if (fireTimer >= 1f / fireRate)
        {
            fireTimer = 0f;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            Vector2 dir = player.transform.position - firePoint.position;

            bullet.GetComponent<EnergyBullet>().SetDirection(dir);
        }
    }
}