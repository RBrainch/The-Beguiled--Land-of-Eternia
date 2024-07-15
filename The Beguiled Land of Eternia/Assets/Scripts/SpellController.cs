using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public GameObject[] spellsList = new GameObject[3];
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
       // player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetSpellSlot();
        Cast();

        
    }

    public int GetSpellSlot() {
        if (Input.GetKeyDown(KeyCode.E)) {
            return 0;
        }
        else if (Input.GetKeyDown(KeyCode.R)) {
            return 1;
        }
        else if (Input.GetKeyDown(KeyCode.F)) {
            return 2;
        }
        else {
            return -1;
        }
    }

    public void Cast() {
        if (GetSpellSlot() != -1) {
            Instantiate((spellsList[GetSpellSlot()]), player.transform.position, transform.rotation);
        }
    }
}
