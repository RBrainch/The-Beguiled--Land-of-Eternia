using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellSwitchManager : MonoBehaviour
{
    public int selectedSlot = 1;
    public CooldownManager cooldownManager1;
    public CooldownManager cooldownManager2;
    public CooldownManager cooldownManager3;


    public DescriptionRenderer spellSlot1;
    public DescriptionRenderer spellSlot2;
    public DescriptionRenderer spellSlot3;
    public SpellController spellController;
    public Button button1;
    public Button button2;
    public Button button3;
    public GameObject magicMissile;
    public GameObject catapault;
    public GameObject heal;
    public GameObject spellSwitchThing;
    public GameObject spellTable;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(() => SetSpellTo(magicMissile));
        button2.onClick.AddListener(() => SetSpellTo(catapault));
        button3.onClick.AddListener(() =>SetSpellTo(heal));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSpellGUI()
    {
        spellSwitchThing.SetActive(true);
        Time.timeScale = 0.01f;
        selectedSlot = 1;
    }

    void SetSpellTo(GameObject spell)
    {
        if(selectedSlot == 1)
        {
            spellSlot1.spellFunctions = spell.GetComponent<SpellFunctions>();
            cooldownManager1.spell = spell.GetComponent<SpellFunctions>();
            spellController.spellsList[0] = spell;
        }else if(selectedSlot == 2)
        {
            spellSlot2.spellFunctions = spell.GetComponent<SpellFunctions>();
            cooldownManager2.spell = spell.GetComponent<SpellFunctions>();
            spellController.spellsList[1] = spell;
        }else if(selectedSlot == 3)
        {
            spellSlot3.spellFunctions = spell.GetComponent<SpellFunctions>();
            cooldownManager3.spell = spell.GetComponent<SpellFunctions>();
            spellController.spellsList[2] = spell;
        }

        if(selectedSlot == 3)
        {
            selectedSlot = 1;
            spellSwitchThing.SetActive(false);
            Time.timeScale = 1;

        }else
        {
            selectedSlot++;
        }
    }
}
