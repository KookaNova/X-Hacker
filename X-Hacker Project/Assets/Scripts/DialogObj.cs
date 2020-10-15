using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogObj : MonoBehaviour
{
    

    public string popUp;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print( "Update Called ");
            DialogSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogSystem>();
            pop.Dialog(popUp);
        } 
        
       
    }

    
}


