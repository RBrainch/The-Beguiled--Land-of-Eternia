using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public HealthManager Health;
    public GameObject Player;

    public float MoveSpeed = 2f;
    public float DamageCooldown = 0;

    public int MyDamage = 20;
    void Start()
    {
        Health = FindObjectOfType<HealthManager>();
        Player = FindObjectOfType<PlayerControllerChristian>().gameObject;
    }
    void Update()
    {
        if (DamageCooldown > 0)
        {
            DamageCooldown -= Time.deltaTime;
        }

        float Angle = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
        float dx = Mathf.Cos(Angle);
        float dy = Mathf.Sin(Angle);

        if (dx != 0 && dy != 0)
        {
            dx /= Mathf.Sqrt(2);
            dy /= Mathf.Sqrt(2);
        }

        dx *= Time.deltaTime * MoveSpeed;
        dy *= Time.deltaTime * MoveSpeed;

        transform.Translate(dx, dy, 0);
    }
    private void OnTriggerStay2D(Collider2D Collision)
    {
        if (Collision.gameObject == Player && DamageCooldown <= 0)
        {
            DamageCooldown = 1;
            Health.currentHealth -= MyDamage;
        }
    }
}
