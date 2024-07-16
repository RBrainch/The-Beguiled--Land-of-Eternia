using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerChristian : MonoBehaviour
{
    public float MoveSpeed = 2.5f;

    //public Spell sampleSpell;
    public GameObject spellImage1;
    public GameObject spellImage2;
    public GameObject spellImage3;
    public SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxisRaw("Horizontal");
        float dy = Input.GetAxisRaw("Vertical");
        

        
        if (dx != 0 && dy != 0)
        {
            dx /= Mathf.Sqrt(2);
            dy /= Mathf.Sqrt(2);
        }
        dx *= Time.deltaTime * MoveSpeed;
        dy *= Time.deltaTime * MoveSpeed;

        transform.Translate(dx, dy, 0);
        if (dx > 0) {
            sr.flipX = true;
        }
        else if (dx < 0) {
            sr.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //sampleSpell.cast();
        }
    }
}
