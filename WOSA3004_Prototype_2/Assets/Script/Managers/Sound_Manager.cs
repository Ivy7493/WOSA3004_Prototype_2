using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip LifeGain;
    public AudioClip LifeLose;
    public AudioClip Seal;
    public AudioClip Trash;
    public AudioClip Fish;
    public AudioClip Snip;
    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }


    public void PlayLifeGain()
    {
        if(AS.isPlaying == false)
        {
            AS.clip = LifeGain;
            AS.Play();
        }
      
        
    }


    public void PlayLifeLose()
    {
        if (AS.isPlaying == false)
        {
            AS.clip = LifeLose;
            AS.Play();
        }
    }

    public void PlaySeal()
    {
        if (AS.isPlaying == false)
        {
            AS.clip = Seal;
            AS.Play();
        }
    }

    public void PlayTrash()
    {
        if (AS.isPlaying == false)
        {
            AS.clip = Trash;
            AS.Play();
        }
    }

    public void PlayFish()
    {
        if (AS.isPlaying == false)
        {
            AS.clip = Fish;
            AS.Play();
        }
    }

   public void PlaySnip()
    {
        if (AS.isPlaying == false)
        {
            AS.clip = Snip;
            AS.Play();
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
