using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData data;
    public LayerMask enemyLayer; // Layer của quái vật để tối ưu tìm kiếm

    private float currentCooldown = 0f;

    void Update()
    {
        if (data == null) return;

        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0f)
        {
            Transform target = FindClosestEnemy();
            if (target != null)
            {
                Attack(target);
                currentCooldown = data.cooldown;
            }
        }
        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0f)
        {
            Transform target = FindClosestEnemy();
            if (target != null)
            {
                Attack(target);
                currentCooldown = data.cooldown; // Reset hồi chiêu
            }
        }
    }

    
    private Transform FindClosestEnemy()
    {
        
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, data.range, enemyLayer);

        Transform closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemiesInRange)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }

   
    protected virtual void Attack(Transform target)
    {
        
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    
    private void OnDrawGizmosSelected()
    {
        if (data != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, data.range);
        }
    }
}