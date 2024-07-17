using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellFunctions : MonoBehaviour
{
    public GameObject player;
    public SpellController spellController;
    public float damage;
    public string name;
    public string description;
    public float cooldown;
    public Sprite icon;
    Rigidbody2D rb;
    public BasicEnemy enemyScript;
    public float speed = 10f;
    //public Vector2 screenPosition;
    public Vector3 mousePos;
    public Vector3 missileDirection;  
    public GameObject healthParent;
    public HealthManager healthManager;
    public Animator anim;
    public Rigidbody2D enemyRB;
    public float ImpulseSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spellController = player.GetComponent<SpellController>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        missileDirection = (mousePos - player.transform.position).normalized;
        healthParent = FindObjectOfType<HealthManager>().gameObject;
        healthManager = healthParent.GetComponent<HealthManager>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Missile")) {
            MagicMissile();
        }
        if (gameObject.CompareTag("Heal")) {
            HealingSpell();
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("FireRing")) {
            FireRing();
        }

        
    }
    
    void MagicMissile() {
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
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

    void HealingSpell() {
        healthManager.currentHealth += 50;
    }
    void FireRing() {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        transform.position = player.transform.position;
    }
    

    
    void OnTriggerEnter2D(Collider2D other) {
        
        if (gameObject.CompareTag("Missile")) {

            enemyScript = other.GetComponent<BasicEnemy>();
            //print("hello");
            enemyScript.currentHealthE -= 10;

            Destroy(gameObject);
        }

        if (gameObject.CompareTag("FireRing") && other.CompareTag("Enemy")) {
            //enemyRB = other.GetComponent<Rigidbody2D>();
//            print(other.name);
            enemyScript = other.GetComponent<BasicEnemy>();
//            print(enemyScript.InShield);
            enemyScript.InShield = true;
            enemyScript.currentHealthE -= 50 * Time.deltaTime;
           // StartCoroutine(enemyScript.runAway());



            //enemyRB.AddForce(enemyScript.moveTowards * -ImpulseSpeed, ForceMode2D.Impulse);
            StartCoroutine(FireTimer());
        }
    }
        

        

        void OnTriggerExit2D(Collider2D other) {
            if (gameObject.CompareTag("FireRing") && other.CompareTag("Enemy")) {
                enemyScript.InShield = false;
            }

        }
        IEnumerator FireTimer() {
        
        yield return new WaitForSeconds(2);
        enemyScript.InShield = false;
        Destroy(gameObject);
        }

    
}

   

    

      

