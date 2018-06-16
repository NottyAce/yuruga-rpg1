using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    public int enemyHP = 70;
    public int enemyAttack = 20;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void EnemyAttack(PlayerStatus playerStatus)//敵が与える攻撃
    {
        playerStatus.PlayerDamage(enemyAttack);
    }
    public void EnemyDamage(int playerAttack)//敵が受けるダメージ
    {
        enemyHP -= playerAttack;
    }

}
