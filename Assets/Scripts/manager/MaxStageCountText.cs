using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaxStageCountText : MonoBehaviour
{
    //到達ステージ数のオブジェクト
    private GameObject maxStageCount;
    // Start is called before the first frame update
    void Start()
    {
        //MaxStageCountテキストを発見
        maxStageCount = GameObject.Find("MaxStageCount");
        //テキストオブジェクトに変数化
        Text score_text = maxStageCount.GetComponent<Text>();
        //スコアテキストに最終ステージを表示
        score_text.text = "FINISH STAGE" + Emitter.stageCount;
        //スタティック変数を初期化
        FindObjectOfType<PlayerCangeSts>().ResetSts();
    }
    void Update()
    {
        //xを押すとリトライ
        if (Input.GetKeyDown(KeyCode.X))
        {
            //コルーチンの起動
            StartCoroutine("StartGame");
        }
    }
    IEnumerator StartGame()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage1");
    }

    // Update is called once per frame

}
