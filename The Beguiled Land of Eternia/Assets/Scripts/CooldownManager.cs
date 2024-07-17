using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownManager : MonoBehaviour
{
    private float timer;
    public SpellFunctions spell;
    private bool coolingDown;
    public KeyCode activateKey;
    public GameObject parent;
    public GameObject textObj;
    public GameObject player;
    public SpellController spellController;
   // public GameObject spells;
    // Start is called before the first frame update
    void Start()
    {
        spellController = player.GetComponent<SpellController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       // spells = FindObjectOfType<SpellFunctions>().gameObject;
       
        if(Input.GetKeyDown(activateKey))
        {
            coolingDown = true;
        }
        
        

        if(coolingDown)
        {
            parent.SetActive(true);
            timer += Time.deltaTime;
            if(timer >= spell.cooldown)
            {
                coolingDown = false;
            }
            textObj.GetComponent<TMP_Text>().text = ((int)(spell.cooldown-timer)) + 1 + " sec";
        }
        else
        {
            parent.SetActive(false);
            timer = 0;
        }
    }
    void LateUpdate(){
        if (coolingDown && activateKey == KeyCode.E){
            
            spellController.Slot1Cast = false;
            
        }
        if (coolingDown && activateKey == KeyCode.R){
            spellController.Slot2Cast = false;
        }
        if(coolingDown && activateKey == KeyCode.F){
            spellController.Slot3Cast = false;
        }

        if (!coolingDown && activateKey == KeyCode.E){
            
            spellController.Slot1Cast = true;
        }
        if (!coolingDown && activateKey == KeyCode.R){
            spellController.Slot2Cast = true;
        }
        if(!coolingDown && activateKey == KeyCode.F){
            //print ("hello");
            spellController.Slot3Cast = true;
        }
    }
}
