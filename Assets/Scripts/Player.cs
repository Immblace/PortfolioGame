using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BulletPlayer Bullet;
    [SerializeField] private Transform BulletSpawn;
    private ScoreManager ScoreManager;

    private float MoveSpeed = 3f;
    private float RotateSpeed = 180f;
    private int Life = 100;
    public event Action myev;


    private void Start()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
        ScoreManager.SetScore(Life);
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }


        if (Life <= 0)
        {
            myev?.Invoke();
        }
    }



    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * v * MoveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * -h * RotateSpeed * Time.deltaTime);
    }


    private void Fire()
    {
        BulletPlayer bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
    }


    public void GetDamage(int Damage)
    {
        Life -= Damage;
        ScoreManager.SetScore(Life);
        ScoreManager.SetDamage(Damage);
    }

    
}
