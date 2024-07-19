using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretParticleScript : MonoBehaviour
{
    public GameObject honingMissile;
    public float cooldown = 3;
    public float Eyesight = 8f;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<SpellController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Physics2D.IgnoreCollision(honingMissile.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        if (cooldown <= 0) {
            cooldown = 3;
            bool LineOfSight = false;
            if ((Player.transform.position - transform.position).magnitude < Eyesight)
            {
            LineOfSight = true;
            }
            if (LineOfSight) {
            Instantiate(honingMissile, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
            }
        }
        else {
            cooldown -= Time.deltaTime;
        }
    }
}
