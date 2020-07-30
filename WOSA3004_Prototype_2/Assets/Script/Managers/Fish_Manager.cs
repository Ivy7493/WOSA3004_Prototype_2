using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Healthy;
    public Sprite[] Dead;
    public float Phase3;
    SpriteRenderer SR;
    Game_Manager GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        int select = Random.Range(0, Healthy.Length);
        SR = GetComponent<SpriteRenderer>();
        if(GM.ReturnScore() >= Phase3)
        {
            SR.sprite = Healthy[select];
        }
        else
        {
            SR.sprite = Dead[select];
        }

    }

    public void SetDirection(string _message)
    {

        switch (_message)
        {
            case "LEFT":
                transform.Rotate(new Vector3(0f, 180f, 0f));
                break;
            case "RIGHT":
                
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
