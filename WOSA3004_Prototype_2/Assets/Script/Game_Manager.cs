using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public float Life;
    UI_Manager UIM;
    float Score;
    bool GameOver = false;
    public float SnipThreshold;
    bool SnipperEnable = false;
    void Start()
    {
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        UIM.UpdateLife(Life);
        UIM.UpdateScore(0f);
       
    }

    public void LifePickUp()
    {
        Life++;
        UIM.UpdateLife(Life);
    }

    public float ReturnScore()
    {
        return Score;
    }

    public void IncreaseScore(float _amount)
    {
        Score += _amount;
        UIM.UpdateScore(Score);
        if(Score >= SnipThreshold)
        {
            SnipperEnable = true;
            UIM.PushNote("Watch out for scissors! They will cut your line!");
        }
    }

    public bool IsSnipperActive()
    {
        return SnipperEnable;
    }

    public bool IsGameOver()
    {
        return GameOver;
    }

    public float ReturnLife()
    {
        return Life;
    }

    public void MinusLife()
    {
        Life--;
        UIM.UpdateLife(Life);
        if (Life <= 0)
        {
            GameOver = true;
            if(PlayerPrefs.GetFloat("HighScore",0f) < Score)
            {
                PlayerPrefs.SetFloat("HighScore", Score);
                UIM.PushNote("NEW HIGH SCORE! " + Score);
            }
            else
            {
                UIM.PushNote("FINAL SCORE " + Score);
                UIM.PushNote("HIGH SCORE " + (PlayerPrefs.GetFloat("HighScore", 0f)));
            }
            UIM.PushNote("Click to restart!");
        }
        else
        {
            UIM.PushNote("Left click to use an additonal life!");
        }
        
    }

    void NextGame()
    {
        if(GameOver == true && Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        NextGame();
    }
}
