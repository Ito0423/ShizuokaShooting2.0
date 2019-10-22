
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class StageManager : MonoBehaviour
{
    PublicManager publicManager;
    //オブジェクト
    [SerializeField] GameObject _stageNumberText;
    [SerializeField] GameObject _stageEndText;
    [SerializeField] GameObject _playerObject;
    [SerializeField] GameObject _emitter;
    //定数
    readonly string YEN_TAG = "1en";
    readonly string BULLET_ENEMY_TAG = "Bullet";
    readonly float STAGE_NUMBER_TEXT_DISPLAY_TIME = 2.0f;
    readonly float STAGE_START_TEXT_DISPLAY_TIME = 2.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("Training");
        }
        //エミッターが消滅したらステージクリアにする
        checkEmitterExist();
    }

    public void GameOver()
    {
    }

    //TODO 繰り返しが多い
    IEnumerator Start()
    {
        publicManager = GetComponent<PublicManager>();
        Text stageText = _stageNumberText.GetComponent<Text>();
        //TODO ステージテキストに現在のステージ数の文字列を追加する
        stageText.text = "STAGE" + publicManager.StageCount;
        ChangeActiveObject(_stageEndText, false);
        Instantiate(_playerObject, _playerObject.transform.position, _playerObject.transform.rotation);
        yield return new WaitForSeconds(STAGE_NUMBER_TEXT_DISPLAY_TIME);
        stageText.text = "START!!";
        yield return new WaitForSeconds(STAGE_START_TEXT_DISPLAY_TIME);
        ChangeActiveObject(_stageNumberText, false);
    }

    public IEnumerator ClearStargeCoroutine()
    {
        GameObject[] bullet = GameObject.FindGameObjectsWithTag(BULLET_ENEMY_TAG);
        foreach (GameObject bullets in bullet)
        {
            Destroy(bullets);
        }
        ChangeActiveObject(_stageEndText, true);
        publicManager.StageCount += 1;
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

    public void checkEmitterExist()
    {
        if (!_emitter)
        {
            StartCoroutine(ClearStargeCoroutine());
        }
    }
}
