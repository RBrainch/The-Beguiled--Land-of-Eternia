using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float cooldown = 4;
    public GameObject honingMissile;
    public float health;
    public float maxHealth = 25f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(honingMissile.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());


        if (cooldown <= 0) {
            cooldown = 4;
            Instantiate(honingMissile, new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z), transform.rotation);
        }
        else {
            cooldown -= Time.deltaTime;
        }
        
    }

    
}
