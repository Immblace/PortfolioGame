using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] TextMeshProUGUI LifeText;
    [SerializeField] TextMeshProUGUI DamageText;


    private void Start()
    {
        DamageText.text = "";
    }


    private void Update()
    {
        DamageText.transform.position = new Vector2(Player.transform.position.x , Player.transform.position.y + 0.3f);
    }




    public void SetScore(int Score)
    {
        LifeText.text = "Life: " + Score;
    }

    public void SetDamage(int Damage)
    {
        DamageText.text = "-" + Damage;
        StartCoroutine(HideDamage());
    }


    IEnumerator HideDamage()
    {
        yield return new WaitForSeconds(0.7f);
        DamageText.text = "";
    }


}
