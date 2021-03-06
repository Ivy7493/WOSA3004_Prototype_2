﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    float StartX;
    LineRenderer Path;
    public int Length;
    public float StopHeight;
    bool HookActive = true;
    GameObject Hooked;
    bool IsHooked = false;
    Game_Manager GM;
    Sound_Manager SM;
    public int score_increment;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        SM = GameObject.FindGameObjectWithTag("Sound_Manager").GetComponent<Sound_Manager>();
        Path = GetComponent<LineRenderer>();
        
        StartX = transform.position.x;
    }

    public void Snipped()
    {
        Debug.Log("Got Snippered");
        HookActive = false;
        transform.position = new Vector3(StartX, StopHeight, 0f);
        Path.SetPosition(0, new Vector3(StartX, StopHeight, 0f));
        if (IsHooked == true)
        {
            Destroy(Hooked);
        }
        GM.MinusLife();
        SM.PlaySnip();
    }


    void Motion()
    {
        if(HookActive == true)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (pos.y > StopHeight)
            {
                pos.y = StopHeight;
            }
            pos = new Vector3(StartX, pos.y, 0f);
            Path.SetPosition(0, pos);
            transform.position = pos;
          
            
        }




    }

    void HookedObject()
    {
        if(IsHooked == true)
        {
            if(Hooked != null)
            {
                Hooked.transform.position = transform.position;
            }
           
            if(transform.position.y >= StopHeight && Input.GetMouseButton(0))
            {
                //Put code to do score here
                GM.IncreaseScore(score_increment);
                Destroy(Hooked);
                IsHooked = false;
            }
        }
    }

    void ActiveHook()
    {
        if(HookActive == false && Input.GetMouseButton(0))
        {
            HookActive = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Fish")
        {

            HookActive = false;
            transform.position = new Vector3(StartX, StopHeight, 0f);
            Path.SetPosition(0, new Vector3(StartX, StopHeight, 0f));
            if (IsHooked == true)
            {
             
                Destroy(Hooked);

            }
            GM.MinusLife();
            SM.PlayFish();
            
        }else if(collision.gameObject.tag == "Trash")
        {
            if(IsHooked == false)
            {
                IsHooked = true;
                Hooked = collision.gameObject;
                Hooked.GetComponent<Movement_Motor>().SetHooked();
            }
            SM.PlayTrash();
           
        }else if (collision.gameObject.tag == "Life")
        {
            GM.LifePickUp();
            Destroy(collision.gameObject);
            SM.PlayLifeGain();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.IsGameOver() == false)
        {
            Motion();
            ActiveHook();
            HookedObject();
        }
        
    }
}
