
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour
{
    //コンポーネント
    private GameObject _waveText;
    //オブジェクト
    [SerializeField] GameObject _stageNumberText;
    [SerializeField] GameObject _stageStartText;
    [SerializeField] GameObject _stageEndText;
    [SerializeField] GameObject _playerShip;
    [SerializeField] GameObject _emitter;
    //クラス変数

    //定数
    readonly string STAGE_START_TEXT = "Wave";
    readonly string STAGE_END_TEXT = "GameClear";
    readonly string YEN_TAG = "1en";
    readonly string BULLET_ENEMY_TAG = "Bullet";
    readonly float STAGE_NUMBER_TEXT_DISPLAY_TIME = 2.0f;
    readonly float STAGE_START_TEXT_DISPLAY_TIME = 2.0f;

    //インスペクターで追加するオブジェクト
    [SerializeField] GameObject _playerObject;
    //インスペクターで設定する変数

    static private int _stageNumber;
 

 
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("Training");
        }
        checkEmitterExist();
    }

    public void GameOver()
    {
    }

    //TODO 繰り返しが多い
    IEnumerator StartStageCoroutine()
    {
       
        Text stageText = _stageNumberText.GetComponent<Text>();
        //TODO ステージテキストに現在のステージ数の文字列を追加する
        stageText.text = "STAGE" + Emitter.stageCount;
        ChangeActiveObject(_stageEndText, false);
        Instantiate(_playerObject, _playerObject.transform.position, _playerObject.transform.rotation);
        yield return new WaitForSeconds(STAGE_NUMBER_TEXT_DISPLAY_TIME);
        ChangeActiveObject(_stageNumberText, false);
        ChangeActiveObject(_stageStartText, true);
        yield return new WaitForSeconds(STAGE_START_TEXT_DISPLAY_TIME);
        ChangeActiveObject(_stageStartText, false);
    }

    IEnumerator ClearStargeCoroutine()
    {
        GameObject[] bullet = GameObject.FindGameObjectsWithTag(BULLET_ENEMY_TAG);
        foreach (GameObject bullets in bullet)
        {
            Destroy(bullets);
        }
        ChangeActiveObject(_stageEndText, true);
        yield return new WaitForSeconds(STAGE_START_TEXT_DISPLAY_TIME);
        SceneManager.LoadScene("Training");
    }
    IEnumerator GameOverCoroutine()
    {
        GameObject[] oneYens = GameObject.FindGameObjectsWithTag(YEN_TAG);
        foreach (GameObject Yen in oneYens)
        {
            Destroy(Yen);
        }
        yield return new WaitForSeconds(STAGE_START_TEXT_DISPLAY_TIME);
        SceneManager.LoadScene("GameOver");
    }


    public void ChangeActiveObject(GameObject switchText, bool SwitchOnDisplay)
    {
        switchText.SetActive(SwitchOnDisplay);
    }

    private void checkEmitterExist()
    {
        if (!_emitter)
        {
            StartCoroutine(ClearStargeCoroutine());
        }
    }


    //古いコード↓


    public bool IsPlaying()
    {
        // ゲーム中かどうかはタイトルの表示/非表示で判断する
        // return title.activeSelf == false;
        return true;
    }
}

