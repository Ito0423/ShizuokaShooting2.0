using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

[RequireComponent(typeof(Rigidbody2D))]
public class NewSpaceShip : MonoBehaviour
{
    // 機体が移動するスピード
    public float m_moveSpeed = 1.0f;

    //機体が打つ弾のスピード
    public float m_shotBulletSpeed = 0.1f;

    //機体が弾を打つ間隔
    public float m_shotDelay = 0.5f;

    //弾を打つかどうか
    public bool m_CanShot = true;

    //弾のPrefab
    public Bullet[] m_BulletPrefub;

    //爆発のprefab
    public GameObject m_ExplosionPrefub;

    //弾の攻撃力
    public int m_BulletPower = 5;

    //リキッドボディコンポーネント 
    [System.NonSerialized] public Rigidbody2D m_rigidbody2d;

    //オーディオソースコンポーネント
    [System.NonSerialized] public AudioSource m_audioSource;

    //アニメーターコンポーネント
    [System.NonSerialized] public Animator m_animator;

    //弾を打った時の音
    public AudioClip m_ShotBulletSound;

    //弾を受けた時の音
    public AudioClip m_getDamageSound;

    //機体に必要なコンポーネントを獲得
    public void GetConponent()
    {
        //オーディオコンポーネントを取得して格納
        m_audioSource = GetComponent<AudioSource>();

        //アニメーターコンポーネントを取得して格納
        m_animator = GetComponent<Animator>();

        //rigidbody2dコンポーネントを取得して格納
        m_rigidbody2d = GetComponent<Rigidbody2D>();
    }
}
