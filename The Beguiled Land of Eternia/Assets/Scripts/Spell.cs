using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public string name;
    public int power;
    public float cooldown;
    public string description;
    public Sprite icon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void cast(){}

    // public virtual string getName(){}
    // public virtual int getPower(){}
    // public virtual int getCooldown(){}
    // public virtual string getDescription(){}
    // public virtual Image getIcon(){}
}
