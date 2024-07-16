using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFunctions : MonoBehaviour
{
    public GameObject player;
    public SpellController spellController;
    public float damage;
    Rigidbody2D rb;
    public float speed = 10f;
    //public Vector2 screenPosition;
    public Vector3 mousePos;
    public Vector3 missileDirection;  

    // Start is called before the first frame update
    void Start()
    {
        spellController = player.GetComponent<SpellController>();
        player = GameObject.FindWithTag("Player");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        missileDirection = (mousePos - player.transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Missile")) {
            MagicMissile();
        }
    }
    
    void MagicMissile() {
            rb = GetComponent<Rigidbody2D>();
            //print(mousePos.normalized);
            Vector3 rotation = mousePos - player.transform.position;
            //print(missileDirection.normalized);
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            rb.AddForce(missileDirection * speed, ForceMode2D.Force);

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            
           // transform.rotation = Quaternion.Euler(missileDirection.x, missileDirection.y, 0);
            // (missileDirection.x, missileDirection.y, 0);
        
        

        
    }

    void OnCollisionEnter2D(Collision2D other) {
        
        if (gameObject.CompareTag("Missile")) {
            //print("hello");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }

      
}
