using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownManager : MonoBehaviour
{
    private float timer;
    public float cooldown;
    private bool coolingDown;
    public KeyCode activateKey;
    public GameObject parent;
    public GameObject textObj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(activateKey))
        {
            coolingDown = true;
        }
        if(coolingDown)
        {
            parent.SetActive(true);
            timer += Time.deltaTime;
            if(timer >= cooldown)
            {
                coolingDown = false;
            }
            textObj.GetComponent<TMP_Text>().text = ((int)(cooldown-timer)) + 1 + " sec";
        }
        else
        {
            parent.SetActive(false);
            timer = 0;
        }
    }
}