using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerChristian : MonoBehaviour
{
    public GameObject Camera;
    public float MoveSpeed = 2.5f;
    private Rigidbody2D RigidBody;
    private Animator Anim;

    //public Spell sampleSpell;
    public GameObject spellImage1;
    public GameObject spellImage2;
    public GameObject spellImage3;
    public SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        RigidBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        float dx = Input.GetAxisRaw("Horizontal");
        float dy = Input.GetAxisRaw("Vertical");

        if (dx != 0 && dy != 0)
        {
            dx /= Mathf.Sqrt(2);
            dy /= Mathf.Sqrt(2);
        }
        dx *= MoveSpeed;
        dy *= MoveSpeed;

        Anim.SetBool("Moving",(dx != 0 || dy != 0));

        RigidBody.velocity = new Vector2(dx, dy);
        if (dx > 0) {
            sr.flipX = false;
        }
        else if (dx < 0) {
            sr.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //sampleSpell.cast();
        }
    }
}
