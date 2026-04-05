using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float damage;

    void Start()
    {
        
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Enemy"))
        {
             

            Destroy(gameObject); 
        }
    }
}