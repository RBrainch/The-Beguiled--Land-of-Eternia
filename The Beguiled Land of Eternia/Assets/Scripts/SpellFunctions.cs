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
    public ParticleSystem healParticles;
    public ParticleSystem fireParticles;
    public ParticleSystem missileParticles;

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
            
            StartCoroutine(FireTimer());
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
            rb.AddForce(missileDirection * speed * Time.deltaTime, ForceMode2D.Force);

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            
           // transform.rotation = Quaternion.Euler(missileDirection.x, missileDirection.y, 0);
            // (missileDirection.x, missileDirection.y, 0);

        
    }

    void HealingSpell() {
        Instantiate(healParticles, new Vector3(player.transform.position.x, player.transform.position.y-0.75f, player.transform.position.z),player.transform.rotation);
        print("Particles Spawned");
        healthManager.currentHealth += 50;
    }
    void FireRing() {
        Instantiate(fireParticles, player.transform.position, player.transform.rotation);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        transform.position = player.transform.position;
        transform.Rotate(new Vector3(0,0,1), Space.Self);
       // StartCoroutine(FireTimer());
    }
    

    
    void OnCollisionEnter2D(Collision2D collision) {
        
        if (gameObject.CompareTag("Missile") && collision.gameObject.CompareTag("Enemy")) {

            enemyScript = (collision.gameObject).GetComponent<BasicEnemy>();
            //print("hello");
            enemyScript.currentHealthE -= 10;
            Instantiate(missileParticles, transform.position,transform.rotation);

            print("Hit enemy");
            Destroy(gameObject);

            
        }
        else if (gameObject.CompareTag("Missile") && !collision.gameObject.CompareTag("Player")) {
                print("Hit wall");
                Destroy(gameObject);
            }
        }
        void OnTriggerEnter2D(Collider2D other) {
        if (gameObject.CompareTag("FireRing") && (other.CompareTag("Enemy") || other.CompareTag("Projectile"))) {
            //enemyRB = other.GetComponent<Rigidbody2D>();
//            print(other.name);
          
            enemyScript = other.GetComponent<BasicEnemy>();
             enemyScript.PushAway();
//            print(enemyScript.InShield);
            
            enemyScript.currentHealthE -= 25;
           // StartCoroutine(enemyScript.runAway());



            //enemyRB.AddForce(enemyScript.moveTowards * -ImpulseSpeed, ForceMode2D.Impulse);
            
        }
    }
        

        

        void OnTriggerExit2D(Collider2D other) {
            if (gameObject.CompareTag("FireRing") && other.CompareTag("Enemy")) {
                
            }

        }
        IEnumerator FireTimer() {
        
            yield return new WaitForSeconds(2);
            
            Destroy(gameObject);
        }

    
}

   

    

      

