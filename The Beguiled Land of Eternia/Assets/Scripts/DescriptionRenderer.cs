using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionRenderer : MonoBehaviour
{
    public GameObject description;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseEnter(){
        description.SetActive(true);
    }

    void OnMouseExit(){
        description.SetActive(false);
    }
}
