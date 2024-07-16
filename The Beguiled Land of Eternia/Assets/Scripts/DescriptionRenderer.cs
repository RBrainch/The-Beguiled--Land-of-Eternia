using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DescriptionRenderer : MonoBehaviour
{
    public GameObject description;
    public SpellFunctions spellFunctions;
    //public CooldownManager cooldownManager;
    public TMP_Text nameText;
    public TMP_Text powerText;
    public TMP_Text cooldownText;
    public TMP_Text descriptionText;
    int UILayer;
    
    // Start is called before the first frame update
    void Start()
    {
        UILayer = LayerMask.NameToLayer("UI");
        description.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        GetComponent<Image>().sprite = spellFunctions.icon; 
        GameObject slot = IsPointerOverUIElement();
        if(slot != null)
        {
            description.SetActive(true);
            if(slot.CompareTag("SpellSlot") && gameObject.CompareTag("SpellSlot"))
            {
                nameText.text = spellFunctions.name;
                powerText.text = "Power: " + spellFunctions.damage;
                cooldownText.text = "Cooldown: " + spellFunctions.cooldown;
                descriptionText.text = spellFunctions.description;
            }else if(slot.CompareTag("SpellSlot2") && gameObject.CompareTag("SpellSlot2"))
            {
                nameText.text = spellFunctions.name;
                powerText.text = "Power: " + spellFunctions.damage;
                cooldownText.text = "Cooldown: " + spellFunctions.cooldown;
                descriptionText.text = spellFunctions.description;
            }else if(slot.CompareTag("SpellSlot3") && gameObject.CompareTag("SpellSlot3"))
            {
                nameText.text = spellFunctions.name;
                powerText.text = "Power: " + spellFunctions.damage;
                cooldownText.text = "Cooldown: " + spellFunctions.cooldown;
                descriptionText.text = spellFunctions.description;
            }
        }else{
            description.SetActive(false);
        }
    }

     //Returns 'true' if we touched or hovering on a SpellSlot UI element.
    public GameObject IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }
 
 
    //Returns 'true' if we touched or hovering on Unity UI element.
    private GameObject IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer && (curRaysastResult.gameObject.CompareTag("SpellSlot") || curRaysastResult.gameObject.CompareTag("SpellSlot2") || curRaysastResult.gameObject.CompareTag("SpellSlot3")))
                return curRaysastResult.gameObject;
        }
        return null;
    }
 
 
    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
