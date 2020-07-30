using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer SR;
    public Sprite[] Trash;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        int select = Random.Range(0, Trash.Length);
        SR.sprite = Trash[select];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
