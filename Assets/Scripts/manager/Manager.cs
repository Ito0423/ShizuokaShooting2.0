
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour
{
    //コンポーネント
    private GameObject waveText;
    //オブジェクト
    private GameObject gameStartText;
    private GameObject gameEndText;
    //クラス変数

    //定数
    readonly string STAGE_START_TEXT = "Wave";
    readonly string GAME_END_TEXT = "GameClear";
    //インスペクターで追加するオブジェクト
    [SerializeField] GameObject _playerObject;
    //インスペクターで設定する変数

    // Playerプレハブ
    public GameObject player;
    // タイトル
    private GameObject title;
    //ステージ数のテキスト
    private GameObject waveText;
    //ステージクリア時のテキスト
    

    void Start()
    {
        // Titleゲームオブジェクトを検索し取得する
        gameStartText = GameObject.Find(STAGE_START_TEXT);
        gameEndText = GameObject.Find(GAME_END_TEXT);
        //Textのアクティブを変化させる
        ChangeActiveObject(gameStartText, true);
        ChangeActiveObject(gameEndText, false);

        waveText.SetActive(false);
        gameEndText.SetActive(false);
        GameStart();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("Training");
        }
    }

    public void StageStart()
    {
        Instantiate(_playerObject, _playerObject.transform.position, _playerObject.transform.rotation);
    }

    public void ChangeActiveObject(GameObject switchText, bool SwitchOnDisplay)
    {
        switchText.SetActive(SwitchOnDisplay);
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
        gameEndText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Training");
    }
    IEnumerator GameOverWait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}

