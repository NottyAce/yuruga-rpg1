using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int playerHP = 100;
    public int playerAttack = 30;
    // public int playerSkill = 50;
    public int playerRecover = 50;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayerAttack(EnemyScript enemyScript) //プレイヤーが与えるダメージ
    {
        enemyScript.EnemyDamage(playerAttack);

    }
    public void PlayerDamage(int enemyAttack)//プレイヤーが受けるダメージ
    {
        playerHP -= enemyAttack;

    }
    public void PlayerRecover()//プレイヤーが回復する
    {
            playerHP += playerRecover;
    }
    public void PlayerDefence(int enemyAttack)//プレイヤーが防御する
    {
        playerHP -= (enemyAttack / 2);
    }





    //  public void PlayerSkill(EnemyScript enemyHP);//特殊攻撃
    //  {
    //      enemyHP -= playerSkill;
    //  }


}
