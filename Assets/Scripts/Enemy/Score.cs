using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    //現在持っているかね
    static public int maney = 0;
    //金を表示するテキスト
    public Text maneyText;


 
    void Update()
    {
        //ｃキーを押すと金が増える
        if (Input.GetKeyDown(KeyCode.C))
        {
            maney += 10000;
        }

        // 金を表示
        maneyText.text = maney.ToString();

    }

    // ゲーム開始前の状態に戻す


    // 金の追加
    public void AddPoint(int point)
    {
        maney = maney + point;

    }
}