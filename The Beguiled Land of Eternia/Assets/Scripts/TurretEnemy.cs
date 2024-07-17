using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    public HealthManager Health;
    public GameObject Player;
    public GameObject Projectile;

    private float ShootTimer = 0;
    public float ShootInterval = 2;

    public Vector3 moveTowards;
    public bool InShield = false;
    void Start()
    {
        Health = FindObjectOfType<HealthManager>();
        Player = FindObjectOfType<PlayerControllerChristian>().gameObject;
    }
    void Update()
    {
        ShootTimer += Time.deltaTime;
        if (ShootTimer >= ShootInterval)
        {
            ShootTimer -= ShootInterval;
            float Angle = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            Instantiate(Projectile, transform.position, Quaternion.Euler(0, 0, Angle));
        }
    }
}