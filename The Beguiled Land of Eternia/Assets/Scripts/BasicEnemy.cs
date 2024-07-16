
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public HealthManager Health;
    public GameObject Player;
    public GameObject healthParent;

    public float MoveSpeed = 2f;
    public float DamageCooldown = 0;

    public int MyDamage = 20;
    void Start()
    {
        healthParent = FindObjectOfType<HealthManager>().gameObject;
        Player = FindObjectOfType<SpellController>().gameObject;
        Health = healthParent.GetComponent<HealthManager>();
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
    public void OnTriggerStay2D(Collider2D other) {
    {
        if (other.gameObject == Player && DamageCooldown <= 0)
        {
            
            DamageCooldown = 1;
            Health.currentHealth -= MyDamage;
            
        }
    }
    }
}
*/