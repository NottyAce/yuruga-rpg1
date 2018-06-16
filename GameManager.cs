using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    float startTime;

    public int finish;//戦闘終了のシグナル

    public GameObject player;
    public GameObject[] Train = new GameObject[4];
    private tekisutotesuto enemyScript;
    bool isActive;
    public int enemyAppearance;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        isActive = true;
        enemyAppearance = Random.Range(10, 66);//敵出現までの時間
        enemyAppearance = GameObject.Find("person").GetComponent<BaseCharacterController>().enemyAppearance;//戦闘画面移行時間の受け渡し
        
        //enemyAppearance = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= enemyAppearance && isActive)
        {
            isActive = false;
            GameObject.Find("CanvasBackground").GetComponent<Canvas>().enabled = true;
            GameObject.Find("CanvasBattle").GetComponent<Canvas>().enabled = true;
            EnemyAppearance();
            //Debug.Log("時間です");
            GameObject.Find("CanvasBattle/Text").GetComponent<tekisutotesuto>();

            GameObject.Find("BGMmanager").GetComponent<AudioSource>().Pause();//マップBGM中断
            Debug.Log("経由");
            //GameObject.Find("MusicControler").GetComponent<AudioSource>().enabled = true;//戦闘BGM
            GameObject.Find("MusicControler").GetComponent<MusicControl>().MusicPlay();//戦闘BGM
        
            finish = GameObject.Find("CanvasBattle/Text").GetComponent<tekisutotesuto>().finish;//戦闘終了のシグナル
            //Debug.Log(finish);


        }

        if (finish == 1)//戦闘終了のプロセス
        {
            finish = 2;
            GameObject.Find("CanvasBattle").GetComponent<Canvas>().enabled = false;//スクリーン消滅
            GameObject.Find("CanvasBackground").GetComponent<Canvas>().enabled = false;//スクリーン消滅
            GameObject.Find("MusicControler").GetComponent<AudioSource>().enabled = false;//戦闘BGM終了

            GameObject.Find("BGMmanager").GetComponent<AudioSource>().UnPause();//マップBGM再開 

            Debug.Log("戦闘終了");
        }
    }
    public void EnemyAppearance()
    {
        int number = Random.Range(0, 4);//配列の要素0～3を宣言
        transform.position = new Vector3(player.transform.position.x+3, player.transform.position.y, 2);//敵一体目
        GameObject enemyA = Instantiate(Train[number], transform.position, transform.rotation); // 敵オブジェクトを生成。+enemyAに格納。
        enemyScript = GameObject.Find("Text").GetComponent<tekisutotesuto>();
        enemyScript.enemy[0] = enemyA;// 今までPrefab上のオブジェクトを格納してしまっていたため、シーン上のオブジェクトを格納。
        number = Random.Range(0, 4);//敵二体目
        GameObject enemyB = Instantiate(Train[number], new Vector3(transform.position.x - 9, transform.position.y, transform.position.z), transform.rotation); // 敵オブジェクトを生成
        enemyScript = GameObject.Find("Text").GetComponent<tekisutotesuto>();
        enemyScript.enemy[1] = enemyB;
    }


}





