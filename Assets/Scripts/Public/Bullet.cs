using UnityEngine;

public class Bullet : MonoBehaviour
{
    //弾が消える時間
    int m_lifeTime = 5;

    public int m_power = 1;

    public void SetBulletSpeed(float bulletSpeed)
    {
        //velositｙで弾を発射
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * bulletSpeed;
        //時間で破壊
        Destroy(gameObject, m_lifeTime);
    }
}
