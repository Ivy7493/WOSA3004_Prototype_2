using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UIlife;
    public GameObject UIScore;
    public GameObject PushNotif;
    bool PushOn = false;
    float counter;
    public float PushNot;
    void Start()
    {
        PushNotif.SetActive(false);
    }


    public void UpdateLife(float _amount)
    {
        UIlife.GetComponent<Text>().text = "Life: " + _amount;
    }

    public void UpdateScore(float _amount)
    {
        UIScore.GetComponent<Text>().text = "Score: " + _amount;
    }

    public void PushNote(string _message)
    {
        if(PushOn == false)
        {
            PushOn = true;
            PushNotif.SetActive(true);
            counter = PushNot;
            PushNotif.GetComponent<Text>().text = _message;

        }else if(PushOn == true)
        {
            counter = PushNot;
            PushNotif.GetComponent<Text>().text += "\n" +  _message;
        }
    }

    void PushNoteEnable()
    {
        if(PushOn == true)
        {
            counter -= Time.deltaTime;
            if(counter <= 0)
            {
                counter = 0;
                PushOn = false;
                PushNotif.GetComponent<Text>().text = "";
                PushNotif.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PushNoteEnable();
    }
}
