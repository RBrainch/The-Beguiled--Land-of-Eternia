using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    public float BaseSpeed;
    public float TurnSpeed;

    public int MyDamage = 10;

    public float myHealth = 5f;
    private Vector3 Velocity = Vector3.zero;
    private Vector3 Acceleration = Vector3.zero;
    
    public HealthManager Health;
    private GameObject Player;
    void Start()
    {
        Health = FindObjectOfType<HealthManager>();
        Player = FindObjectOfType<PlayerControllerChristian>().gameObject;
    }
    void Update() //kill me
    {
        if (myHealth <= 0) {
            Destroy(gameObject);
        }
        Vector3 TargetSteer = (Player.transform.position - transform.position).normalized * BaseSpeed; //where we WANT to point
        Vector3 Steer = (TargetSteer - Velocity).normalized * (TurnSpeed * Time.deltaTime); //where we CAN point
        Acceleration += Steer; //add the where we can point to acceleration
        Velocity += Acceleration * Time.deltaTime; //velocity
        Velocity = Vector3.ClampMagnitude(Velocity, BaseSpeed); //clamp to max speed

        float Angle;

        if (Velocity.x < 0)
        {
            Angle = Vector3.Angle(Vector3.up, Velocity); //do this because Vector3.Angle takes the closest side
        }
        else
        {
            Angle = -Vector3.Angle(Vector3.up, Velocity);
        }

        transform.rotation = Quaternion.Euler(0, 0, Angle); //rotate, just for visuals
        transform.position += Velocity * Time.deltaTime; //no clue how this matches rotation but it does somehow
    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject == Player)
        {
            Health.currentHealth -= MyDamage;
        }
        if (!Collision.gameObject.CompareTag("Projectile") && !Collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
