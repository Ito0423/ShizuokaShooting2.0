using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBullet : MonoBehaviour
{
    //コンポーネント
    private Rigidbody2D _rigidbody2d;
    //クラス変数

    //定数

    //インスペクターで追加するオブジェクト

    //インスペクターで設定する変数
    [SerializeField] float _bulletSpeed = 1.0f;
    [SerializeField] int _bulletPower = 5;
    public int BulletPower
    {
        get { return _bulletPower; }
        private set { _bulletPower = value; }
    }


    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void BulletSpeedControlloer()
    {
        PlayerShot playerShot = FindObjectOfType<PlayerShot>();

        _rigidbody2d.velocity = transform.up.normalized * _bulletSpeed;

        Destroy(gameObject, playerShot.BulletTime);
    }
}
