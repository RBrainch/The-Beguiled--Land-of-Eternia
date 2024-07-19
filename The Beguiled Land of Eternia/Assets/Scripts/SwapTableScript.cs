using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTableScript : MonoBehaviour
{
    public GameObject player;
    public SpellSwitchManager swapManager;
    public GameObject thing;
    public bool inSpellTable;
    // Start is called before the first frame update
    void Start()
    {
        swapManager = FindObjectOfType<SpellSwitchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - transform.position).magnitude < 2)
        {
            if(!inSpellTable)
            {
                thing.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
               swapManager.OpenSpellGUI();
               thing.SetActive(false); 
               inSpellTable = true;
            }
        }else{
            thing.SetActive(false);
        }
    }
}
