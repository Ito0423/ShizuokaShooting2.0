using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Title : MonoBehaviour
{
    [SerializeField]
    RectTransform rectTran;
    private GameObject plessX;
    private bool firstButton = false;
    // Start is called before the first frame update
    void Start()
    {
        //プレスxテキストオブジェクトを取得
        plessX = GameObject.Find("PlessX");
        //プレスxを非表示にする
        plessX.SetActive(false);
        //タイトルを画面中央まで移動させる
        this.rectTran.DOMove(endValue: new Vector3(this.transform.position.x, this.transform.position.y + 700, 0), duration: 3.0f).OnComplete(() =>
        {
            //プレスｘを画面に表示
            plessX.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        //タイトルが表示されている際にｘを押すとゲームスタート
        if (canPlessX() == false && Input.GetKeyDown(KeyCode.X)&&firstButton==false)
        {
            //スタートゲームコルーチンを起動
            StartCoroutine("StartGame");
            firstButton = true;
        }
    }
    public bool canPlessX()
    {
        return plessX.activeSelf == false;
    }

    IEnumerator StartGame()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        //ステージ１に画面遷移
        SceneManager.LoadScene("Stage1");

    }
}
