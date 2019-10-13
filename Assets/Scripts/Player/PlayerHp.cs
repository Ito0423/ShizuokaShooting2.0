using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    //初期プレイヤーHp
    static public int playerHp = 5;

    public Text playerHpText;


    void Update()
    {
        //HPを表示
        playerHpText.text = playerHp.ToString();
    }
}
