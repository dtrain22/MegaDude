using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerHealth>().InvincibilityCounter > 0)
        {
            GetComponent<Renderer>().material.color = new Color32(236, 108, 108, 255);
        }  
        else if(GetComponent<Weapon>().chargeTimer >= 2 && GetComponent<PlayerHealth>().InvincibilityCounter > 0)
        {
            GetComponent<Renderer>().material.color = new Color32(236, 108, 108, 255);
        }   
        else if(GetComponent<Weapon>().chargeTimer >= 2 && GetComponent<PlayerHealth>().InvincibilityCounter <= 0)
        {
            GetComponent<Renderer>().material.color = new Color32(0, 217, 255, 255);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        }
            
    }
}
