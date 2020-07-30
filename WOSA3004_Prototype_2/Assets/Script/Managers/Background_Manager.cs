using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public float Phase2;
    public float Phase3;
    public Sprite Phase2BG;
    public Sprite Phase3BG;
    Game_Manager GM;
    SpriteRenderer SR;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        SR = GetComponent<SpriteRenderer>();
    }


    void CheckPhase()
    {
        if(GM.ReturnScore() >= Phase3)
        {
            if(SR.sprite != Phase3BG)
            {
                SR.sprite = Phase3BG;
            }
        }else if(GM.ReturnScore() >= Phase2)
        {
            if(SR.sprite != Phase2BG)
            {
                SR.sprite = Phase2BG;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckPhase();
    }
}
