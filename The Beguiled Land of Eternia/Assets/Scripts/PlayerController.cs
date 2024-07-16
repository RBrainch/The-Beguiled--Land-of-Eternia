using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Spell sampleSpell;
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
            sampleSpell.cast();
        }
    }
}
