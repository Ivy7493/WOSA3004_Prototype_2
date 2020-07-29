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


    public void SetDirection(string _message)
    {
        switch (_message)
        {
            case "LEFT":
                transform.Rotate(new Vector3(0f, 0f, 180));
                break;
            case "RIGHT":
              
                break;
        }
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
