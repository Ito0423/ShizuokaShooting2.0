using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBullet : MonoBehaviour
{

    //弾丸が消える時間
    [SerializeField] int m_bulletTime = 5;
    //弾丸が与えるダメージ
    [SerializeField] int m_bulletPower = 1;
    //弾丸のスピード
    [SerializeField] float m_bulletSpeed =1.0f;


    public void SetBulletSpeed()
    {
        //velositｙで弾を発射
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * m_bulletSpeed;
        //時間で破壊
        Destroy(gameObject, m_bulletTime);
    }
}
