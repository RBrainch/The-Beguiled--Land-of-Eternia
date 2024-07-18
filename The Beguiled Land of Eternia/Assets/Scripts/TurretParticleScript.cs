using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretParticleScript : MonoBehaviour
{
    public GameObject honingMissile;
    public float cooldown = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Physics2D.IgnoreCollision(honingMissile.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        if (cooldown <= 0) {
            cooldown = 3;
            Instantiate(honingMissile, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }
        else {
            cooldown -= Time.deltaTime;
        }
    }
}
