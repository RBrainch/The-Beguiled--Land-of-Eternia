using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTableScript : MonoBehaviour
{
    public SpellSwitchManager swapManager;
    // Start is called before the first frame update
    void Start()
    {
        swapManager = FindObjectOfType<SpellSwitchManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        swapManager.OpenSpellGUI();
    }
}
