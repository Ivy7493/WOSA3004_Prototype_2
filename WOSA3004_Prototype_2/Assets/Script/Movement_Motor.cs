using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Motor : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 Direction;
    public float Speed;
    public float Limit;
    bool StartMov = false;
    Vector3 StartPos;
    bool Hooked = false;
    void Start()
    {
        StartPos = transform.position;
    }

    public void SetDirection(string _Direction)
    {
        switch (_Direction)
        {
            case "LEFT":
                Direction = new Vector3(-1, 0, 0);
                break;
            case "RIGHT":
                Direction = new Vector3(1, 0, 0);
                break;
        }
        StartMov = true;
    }

    public void SetHooked()
    {
        if(gameObject.tag == "Trash")
        {
            Hooked = true;
        }
    }


    void Destruct()
    {
      
            if (Vector3.Distance(transform.position, StartPos) > Limit)
            {
                Destroy(gameObject);
            }
        
       
    }


    void Motion()
    {
        if (StartMov == true && Hooked == false)
        {
            transform.position += Direction * Speed * Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Motion();
        Destruct();
    }
}
