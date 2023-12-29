using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private Enemy Enemy;
    [SerializeField] private Transform[] SpawnPosition = new Transform[4];
    [SerializeField] private GameObject GameOverMenu;
    private List<Enemy> EnemyClone = new List<Enemy>();

    private float Timer;




    private void Start()
    {
        GameOverMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Enemy Clone = Instantiate(Enemy , SpawnPosition[Random.Range(0 , SpawnPosition.Length)].position , Quaternion.identity);
            EnemyClone.Add(Clone);
            Timer = Random.Range(2f, 5f);
        }
    }

    private void OnEnable()
    {
        Player.myev += GameOver;
    }

    private void OnDisable()
    {
        Player.myev -= GameOver;
    }


    private void GameOver()
    {
        for (int i = 0; i < EnemyClone.Count; i++)
        {
            if (EnemyClone[i] == null)
            {
                continue;
            }
            Destroy(EnemyClone[i].gameObject);
        }
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
    }




}
