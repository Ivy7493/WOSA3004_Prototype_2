using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Hook;
    SpriteRenderer SR;
    void Start()
    {
        Hook = GameObject.FindGameObjectWithTag("Hook");
        SR = GetComponent<SpriteRenderer>();
    }


    void Effect()
    {
        if(transform.position.y > Hook.transform.position.y)
        {
            SR.color = Color.white;
        }else if (transform.position.y < Hook.transform.position.y)
        {
            SR.color = Color.clear;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Effect();
    }
}
