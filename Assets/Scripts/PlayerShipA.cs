using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipA : _PlayerShip
{
    //クラス変数
    private PlayerShot _playerShot;
    //インスペクターで設定する変数
    [SerializeField] float _delayShotSpeed = 0.5f;
    IEnumerator Start()
    {
        GetBasicSpaceShipComponent();
        GetPlayerComponent();
        _playerShot = GetComponent<PlayerShot>();

        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            _playerShot.ShotPlayerBullet(transform);
            yield return new WaitForSeconds(_delayShotSpeed);
        }
    }
    private void Update()
    {
        MovePlayer();
        GetManey();
    }
    private void MovePlayer()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        _rigidbody2d.velocity = direction * _moveSpeed;

        //プレイヤーの移動を制限
        ClampPlayerMove();
    }

}
