using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float timeDestroy = 2f;

    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    void Update()
    {
        moveBullet();
    }
    void moveBullet()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ai thêm hàm nhận damage của Player thì gọi ở đây nhé
            // collision.GetComponent<Player>().TakeDamage();

            Destroy(gameObject);
        }
    }
}