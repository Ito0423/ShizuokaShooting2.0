using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

[RequireComponent(typeof(Rigidbody2D))]
public class _SpaceShip : MonoBehaviour
{
    //コンポーネント
    [System.NonSerialized] public Rigidbody2D _rigidbody2d;

    //インスペクターで追加するオブジェクト
    [SerializeField] GameObject _ExplosionPrefub;

    //インスペクターで設定する変数
    public float _moveSpeed = 1.0f;

    public void GetBasicSpaceShipComponent()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    public void Explosion()
    {
        Instantiate(_ExplosionPrefub, transform.position, transform.rotation);
    }
}


