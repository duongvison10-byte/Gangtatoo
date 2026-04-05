using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float damage;

    void Start()
    {
        // Tự động hủy sau 3 giây nếu không trúng gì để nhẹ máy
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem có trúng quái không (Giả sử quái có script EnemyHealth)
        if (collision.CompareTag("Enemy"))
        {
            // Tạm comment lại vì bạn chưa có script máu của quái
            // collision.GetComponent<EnemyHealth>().TakeDamage(damage); 

            Destroy(gameObject); // Hủy viên đạn khi trúng quái
        }
    }
}