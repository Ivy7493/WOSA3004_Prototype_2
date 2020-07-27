using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snipper_AI : MonoBehaviour
{
    // Start is called before the first frame update
    bool Snipped = false;
    GameObject Line;
    public float SnipDelta = 0.2f;
    void Start()
    {
        Line = GameObject.FindGameObjectWithTag("Hook");
    }

    void Encounter()
    {
        if(Snipped == false)
        {
            if(Mathf.Abs(transform.position.x) <= SnipDelta)
            {
                if(transform.position.y > Line.transform.position.y)
                {
                    Line.GetComponent<Rod_Manager>().Snipped();
                    Snipped = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Encounter();
    }
}
