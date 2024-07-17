using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float cooldown = 4;
    public GameObject honingMissile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown <= 0) {
            cooldown = 4;
            Instantiate(honingMissile, transform.position, transform.rotation);
        }
        else {
            cooldown -= Time.deltaTime;
        }
        
    }

    
}
