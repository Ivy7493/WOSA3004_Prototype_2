using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Objects;
    public GameObject Health;
    public string Direction;
    float GCD;
    float counter;
    Game_Manager GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("Game_Manager").GetComponent<Game_Manager>();
        GCD = Random.Range(5f, 9f);
    }

    void Spawn()
    {
        GCD = Random.Range(5, 31f);
        int Select = Random.Range(0, Objects.Length);
        GameObject CurrentSpawn = Instantiate(Objects[Select], transform.position, Quaternion.identity);
        CurrentSpawn.GetComponent<Movement_Motor>().SetDirection(Direction);
    }

    void SpawnHealth()
    {
        GameObject CurrentSpawn = Instantiate(Health, transform.position, Quaternion.identity);
        CurrentSpawn.GetComponent<Movement_Motor>().SetDirection(Direction);
    }

    void NextSpawn()
    {
        counter += Time.deltaTime;
        if(counter >= GCD)
        {
            counter = 0;
            float select = Random.Range(0, 11);
            if(select <= 1 && GM.ReturnLife() < 3)
            {
                SpawnHealth();
            }
            else
            {
                Spawn();
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.IsGameOver() == false)
        {
            NextSpawn();
        }
       
    }
}
