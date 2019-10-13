
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour
{
    // Playerプレハブ
    public GameObject player;

    // タイトル
    private GameObject title;
    //ステージ数のテキスト
    private GameObject waveText;
    //ステージクリア時のテキスト
    private GameObject gameClearText;

    void Start()
    {
        // Titleゲームオブジェクトを検索し取得する
        waveText = GameObject.Find("Wave");
        gameClearText = GameObject.Find("GameClear");
        waveText.SetActive(false);
        gameClearText.SetActive(false);
        GameStart();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("Training");
        }
    }

    void GameStart()
    {
        // ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
        //title.SetActive(false);
        StartCoroutine("ChangeColor");
        Instantiate(player, player.transform.position, player.transform.rotation);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        GetComponent<AudioSource>().Play();
        GameObject[] oneYen = GameObject.FindGameObjectsWithTag("1en");
        foreach (GameObject Yens in oneYen)
        {
            Destroy(Yens);
        }
        // ゲームオーバー時に、タイトルを表示する
       // FindObjectOfType<PlayerCangeSts>().ResetSts();
        StartCoroutine("GameOverWait");

    }
    public bool IsPlaying()
    {
        // ゲーム中かどうかはタイトルの表示/非表示で判断する
        // return title.activeSelf == false;
        return true;
    }
    IEnumerator ChangeColor()
    {

        Text score_text = waveText.GetComponent<Text>();
        score_text.text = "STAGE" + Emitter.stageCount;
        waveText.SetActive(true);
        //3秒停止
        yield return new WaitForSeconds(1);
        score_text.text = "START!!";
        yield return new WaitForSeconds(2);
        waveText.SetActive(false);
        //青色にする

    }

    public void GameClear()
    {
        StartCoroutine("ClearText");
    }
    IEnumerator ClearText()
    {
        GameObject[] bullet = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullets in bullet)
        {
            Destroy(bullets);
        }
        gameClearText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Training");
    }
    IEnumerator GameOverWait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}

