using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public HealthManager Health;
    public float maxHealthE = 50f;
    public float currentHealthE = 50f;
    public GameObject Player;
    public Image healthBar;
    public float MoveSpeed = 2f;
    public float DamageCooldown = 0;
    public GameObject healthBarParent;
    public Canvas enemyCanvas;
    public int MyDamage = 20;
    public Vector2 moveTowards;
    public bool InShield = false;
    private Rigidbody2D RigidBody;
    public float Eyesight = 5;
    void Start()
    {
        currentHealthE = maxHealthE;
        Health = FindObjectOfType<HealthManager>();
        Player = FindObjectOfType<PlayerControllerChristian>().gameObject;
        healthBarParent = GameObject.FindWithTag("HealthBarParent");
        healthBar = transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).GetComponent<Image>();
        enemyCanvas = transform.GetChild(0).GetComponent<Canvas>();
        RigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        enemyCanvas.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

        //print(currentHealthE/maxHealthE);
        healthBar.fillAmount = currentHealthE/maxHealthE;
        if (currentHealthE < 0) {
            Destroy(gameObject);
            //print("hell0!");
        }
        if (DamageCooldown > 0)
        {
            DamageCooldown -= Time.deltaTime;
        }

        bool LineOfSight = false;
        if ((Player.transform.position - transform.position).magnitude < Eyesight)
        {
            LineOfSight = true;
        }
        if (LineOfSight)
        {
            float Angle = Mathf.Atan2(Player.transform.position.y - transform.position.y, Player.transform.position.x - transform.position.x);
            float dx = Mathf.Cos(Angle);
            float dy = Mathf.Sin(Angle);

            if (dx != 0 && dy != 0)
            {
                dx /= Mathf.Sqrt(2);
                dy /= Mathf.Sqrt(2);
            }

            dx *= MoveSpeed;
            dy *= MoveSpeed;

            moveTowards = new Vector2(dx, dy);

            if (!InShield)
            {
                RigidBody.velocity = moveTowards;
                
            } else if (InShield)
            {
                RigidBody.velocity = -moveTowards;
               
                //StartCoroutine(runAway());
            }
        } else {
            RigidBody.velocity = new Vector2(0, 0);
        }
    }
    private void OnCollisionStay2D(Collision2D Collision)
    {
        if (Collision.gameObject == Player && DamageCooldown <= 0)
        {
            DamageCooldown = 1;
            Health.currentHealth -= MyDamage;
        }
    }

     public IEnumerator runAway() {
        InShield = true;
        yield return new WaitForSeconds(2);
        print(InShield);
        InShield = false;
        
     }

     public void PushAway() {
        StartCoroutine(runAway());
     }

     
}
