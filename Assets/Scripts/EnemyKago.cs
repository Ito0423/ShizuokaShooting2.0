using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKago : _Enemy
{
    [SerializeField] float _delayShotSpeed = 0.5f;

    IEnumerator Start()
    {
        // ローカル座標のY軸のマイナス方向に移動する
        MoveKago(transform.right * +1);

        //弾を打ち続ける
        while (true)
        {
            // 子要素を全て取得する
            for (int i = 0; i < transform.childCount; i++)
            {

                Transform shotPosition = transform.GetChild(i);

                ShotEnemy(shotPosition);
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(_delayShotSpeed);
        }
    }
    public void MoveKago(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * _moveSpeed;
    }
    public void ShotEnemy(Transform origin)
    {
        var pos = origin.position;

        var rot = origin.rotation;

        var shot = Instantiate(m_bullet[0], pos, rot);
        shot.SetBulletSpeed(m_bulletSpeed);
    }
}
