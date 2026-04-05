using UnityEngine;

public class RangedWeapon : WeaponController
{
    public Transform firePoint; // Đầu nòng súng để sinh đạn
    public float projectileForce = 20f;

    protected override void Attack(Transform target)
    {
        base.Attack(target); // Gọi hàm Attack ở trên để xoay súng

        // Sinh ra viên đạn
        GameObject projectile = Instantiate(data.projectilePrefab, firePoint.position, transform.rotation);

        // Bắn viên đạn bay đi
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(firePoint.right * projectileForce, ForceMode2D.Impulse);
        }

        // Truyền sát thương cho viên đạn
        Projectile projScript = projectile.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.damage = data.baseDamage;
        }
    }
}