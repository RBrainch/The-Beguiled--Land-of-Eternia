using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpellController : MonoBehaviour
{

    public Spell spellSlot1;
    public Spell spellSlot2;
    public Spell spellSlot3;
    public GameObject spellImage1;
    public GameObject spellImage2;
    public GameObject spellImage3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            spellSlot1.cast();
        }
        spellImage1.GetComponent<Image>().sprite = spellSlot1.icon;
    }
}
