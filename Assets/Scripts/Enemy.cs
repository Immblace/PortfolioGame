using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BulletEnemy Bullet;
    [SerializeField] private Transform BulletSpawn;

    private Transform Player;
    private float MoveSpeed;
    private float FireSpeed;
    private int BulletSpeed;
    private int Damage;
    private float Timer;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Damage = Random.Range(3, 8);
        MoveSpeed = Random.Range(0.5f, 1.8f);
        FireSpeed = Random.Range(1f, 3f);
        BulletSpeed = Random.Range(2, 4);
    }


    private void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Fire();
            Timer = FireSpeed;
        }


        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector3 DirectionToPlayer = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(DirectionToPlayer.y, DirectionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector3.MoveTowards(transform.position , Player.position, MoveSpeed * Time.deltaTime);
        
    }


    private void Fire()
    {
        BulletEnemy bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
        bullet.SetBulletProp(Damage, BulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer")
        {
            Destroy(gameObject);
        }
    }

}
