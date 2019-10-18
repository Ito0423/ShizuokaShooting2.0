using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    //コンポーネント
    private GameObject waveText;
    //クラス変数

    //定数
    readonly string GAME_START_TEXT = "Wave";
    //オブジェクト
    private GameObject GameStartText;
    //インスペクターで追加するオブジェクト
    [SerializeField] GameObject _playerObject;
    //インスペクターで設定する変数

    private void Start()
    {
        GameStartText = GameObject.Find("GAME_START_TEXT");

    }

    public void StageStart()
    {
        Instantiate(_playerObject, _playerObject.transform.position, _playerObject.transform.rotation);
    }

    public void ChangeActive(GameObject switchText, bool SwitchOnDisplay)
    {
        switchText.SetActive(!SwitchOnDisplay);
    }
}
