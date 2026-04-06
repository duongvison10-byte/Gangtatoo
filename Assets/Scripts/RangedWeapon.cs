using UnityEngine;

public class RangedWeapon : WeaponController
{
    public Transform firePoint; 
    public float projectileForce = 20f;

    protected override void Attack(Transform target)
    {
        base.Attack(target); 

        
        GameObject projectile = Instantiate(data.projectilePrefab, firePoint.position, transform.rotation);

        
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(firePoint.right * projectileForce, ForceMode2D.Impulse);
        }

       
        Projectile projScript = projectile.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.damage = data.baseDamage;
        }
    }
}