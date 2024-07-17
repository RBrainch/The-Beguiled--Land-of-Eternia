using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellController : MonoBehaviour
{
    public GameObject[] spellsList = new GameObject[3];
    public GameObject player;
    public GameObject enemy;
    public Vector3 mousePos;
    public Vector3 missileDirection;
    public bool Slot1Cast = true;
    public bool Slot2Cast = true;
    public bool Slot3Cast = true;
    

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        // player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindWithTag("Enemy");
        if (enemy == null) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        GetSpellSlot();
        Cast();
        //print(Slot1Cast);

        
    }

    public int GetSpellSlot() {
        if (Input.GetKeyDown(KeyCode.E) && Slot1Cast) {
            return 0;
        }
        else if (Input.GetKeyDown(KeyCode.R) && Slot2Cast) {
            return 1;
        }
        else if (Input.GetKeyDown(KeyCode.F) && Slot3Cast) {
            return 2;
        }
        else {
            return -1;
        }
    }

    public void Cast() {
        
        if (GetSpellSlot() != -1) {
           //print(GetSpellSlot());
            Instantiate((spellsList[GetSpellSlot()]), player.transform.position, transform.rotation);
            
        }
    }
}
