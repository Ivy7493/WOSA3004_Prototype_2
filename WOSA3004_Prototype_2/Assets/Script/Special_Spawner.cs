using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public string Direction;
    public GameObject Enemy;
    Game_Manager GM;
    float GCD;
    float counter;
    void Start()
    {
        
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        GCD = Random.Range(5f, 9f);
    }

    void Spawn()
    {
        GCD = Random.Range(15f, 25f);
        GameObject CurrentSpawn = Instantiate(Enemy, transform.position, Quaternion.identity);
        CurrentSpawn.GetComponent<Movement_Motor>().SetDirection(Direction);
        CurrentSpawn.GetComponent<Snipper_AI>().SetDirection(Direction);
    }

    void NextSpawn()
    {
        counter += Time.deltaTime;
        if (counter >= GCD)
        {
            counter = 0;
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.IsGameOver() == false && GM.IsSnipperActive() == true)
        {
            NextSpawn();
        }
    }
}
