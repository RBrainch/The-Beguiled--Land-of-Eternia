using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFunctions : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public float speed = 10f;
    //public Vector2 screenPosition;
    public Vector3 mousePos;
    public Vector3 missileDirection;  
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        missileDirection = (mousePos - player.transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        MagicMissile();
    }
    
    void MagicMissile() {
        rb = GetComponent<Rigidbody2D>();
            //print(mousePos.normalized);
            print(missileDirection + "Hello");
            rb.AddForce(missileDirection * speed);
            
           // transform.rotation = Quaternion.Euler(missileDirection.x, missileDirection.y, 0);
            // (missileDirection.x, missileDirection.y, 0);
        
        

        
    }
}
