using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private int Damage;
    private int BulletSpeed;



    private void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        transform.Translate(Vector3.up * BulletSpeed * Time.deltaTime);
    }


    public void SetBulletProp(int Damage , int BulletSpeed)
    {
        this.Damage = Damage;
        this.BulletSpeed = BulletSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().GetDamage(Damage);
            Destroy(gameObject);
        }
    }

}
