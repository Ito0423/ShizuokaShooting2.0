using UnityEngine;
using System.Collections;
using DG.Tweening;

public class _Enemy : NewSpaceShip
{
    //コンポーネントクラス
    private Animator _animator;
    //クラス変数

    //定数
    readonly string BULLET_PLAYER_LAYER_NAME = "Bullet(Player)";
    readonly string DAMAGE_ANIMATION_NAME = "Damage";

    //インスペクターで追加するオブジェクト
    [SerializeField] GameObject maneyPrefub;

    //インスペクターで設定する変数
    [SerializeField] int enemyHp;
    [SerializeField] int dropManeyPoint;

    void OnTriggerEnter2D(Collider2D c)
    {
        HitEnemyToObject(c);
    }
    private void HitEnemyToObject(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != BULLET_PLAYER_LAYER_NAME) return;

        // PlayerBulletのTransformを取得
        Transform playerBulletTransform = c.transform.parent;

        // Bulletコンポーネントを取得
        NewBullet newBullet = playerBulletTransform.GetComponent<NewBullet>();

        // ヒットポイントを減らす
        enemyHp -= newBullet.BulletPower;

        // 弾の削除
        Destroy(c.gameObject);

        // ヒットポイントが0以下であれば
        if (enemyHp <= 0)
        {
            DestroyEnemyProcess();
        }
        else
        {
            _animator = GetComponent<Animator>();
            _animator.SetTrigger(DAMAGE_ANIMATION_NAME);
        }
    }
    private void DestroyEnemyProcess()
    {
        FindObjectOfType<Score>().AddPoint(dropManeyPoint);

        //爆発
        Explosion();

        GameObject createManey = Instantiate(maneyPrefub, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}

