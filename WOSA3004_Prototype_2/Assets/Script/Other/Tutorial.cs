using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    UI_Manager UIM;
    float counter;
    bool Tut = true;
    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Tut == true)
        {
            if(counter >= 3)
            {
                UIM.PushNote("Left click to capture trash once you have reeled it in!");
                Tut = false;
            }
            else 
            if(counter == 0)
            {
                UIM.PushNote("Move the line up and down with the mouse!");
                UIM.PushNote("Try to catch as much trash as possible!");
            }
            counter += Time.deltaTime;
            
        }
    }
}
