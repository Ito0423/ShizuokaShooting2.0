using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの弾を打つ挙動を管理するクラス
public class PlayerShot : MonoBehaviour
{
    //コンポーネントクラス

    //クラス変数

    //定数

    //変数
    private static bool[] _canShotBools;

    //インスペクターで追加するオブジェクト

    //インスペクターで設定する変数
    [SerializeField] NewBullet[] _playerBullets;
    [SerializeField] int _playerBulletCount = 1;
    [SerializeField] float _bulletTime = 1.0f;
    public float BulletTime
    {
        get { return _bulletTime; }
        private set { _bulletTime = value; }
    }

    void Awake()
    {
        //_canShotBools配列の大きさを_playerBulletCountで初期化
        _canShotBools = new bool[_playerBulletCount];

        //_canShotBoolsの中身を全てfalseに
        for (int i = 0; i < _playerBulletCount; i++)
        {
            _canShotBools[i] = false;
        }
    }

    public void ShotPlayerBullet(Transform playerPos)
    {
        //TODO test修正
        _canShotBools[0] = true;
        _canShotBools[1] = true;
        for (int i = 0; i < _playerBulletCount; i++)
        {

            if (_canShotBools[i] == true)
            {
                //プレイヤーの位置に
                var pos = playerPos.transform.position;
                //バレットプレハブの角度で
                var rot = _playerBullets[i].transform.rotation;
                //弾を作成
                var shot = Instantiate(_playerBullets[i], pos, rot);
                //弾の速度を決定する
                shot.BulletSpeedControlloer();
            }
        }
    }

}