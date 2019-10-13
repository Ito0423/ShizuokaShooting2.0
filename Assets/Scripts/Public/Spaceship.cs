using UnityEngine;

// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    // 移動スピード
    public float m_speed = 5;
    //弾の速さ
    public float m_bulletSpeed = 0.1f;
    //弾を撃つ間隔
    public float m_shotDelay = 0.5f;
    //弾を打つ場所の数
    public int m_shotCount = 1;
    //弾の数
    public int m_bulletCount = 1;
    //弾を打つかどうか
    public bool m_canShot;
    //弾のPrefab
    [SerializeField]
    public Bullet[] m_bullet;
    //爆発のprefab
    public GameObject explosion;
    //弾の攻撃力
    //public int[] m_bulletPower;
    //アニメーターコンポーネント
    private Animator animator;


    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
    void Awake ()    {
        // アニメーターコンポーネントを取得
        animator = GetComponent<Animator>();
    }
    // 弾の作成
    public void Shot(Transform origin)
    {
        var pos = origin.position; // プレイヤーの位置
        //var rot = origin2.localRotation; // 弾の向き
        var rot = origin.rotation;
        // TrainingButtonShizuoka.canShotShizuButton;
        bool canShotBullet0 = TrainingButtonShizuoka.canShotShizuButton;
        bool canShotBullet1 = TrainingButtonHamamatu.canShotHamaButton;
        bool canShotBullet2 = TrainingButtonHuzi.canShotHuziButton;
        bool canShotBullet3 = TrainingButtonYama.canShotYamaButton;
        bool canShotBullet4 = TrainingButtonIzu.canShotIzuButton;
        bool canShotBullet5 = TrainingButtonShizuoka.canShotShizuButton2;
        
        rot.z += 1;
        //プレイヤーが配列に格納されているbulletオブジェクトを条件によって発射
        int bulletCountIndex = 0;
        if (canShotBullet0 == true) {
            var shot0 = Instantiate(m_bullet[0], pos, rot);
            shot0.SetBulletSpeed(m_bulletSpeed);
            bulletCountIndex++;
        }

        if (canShotBullet1 == true)
        {
            var shot1 = Instantiate(m_bullet[1], pos, rot);
            shot1.SetBulletSpeed(m_bulletSpeed);
            bulletCountIndex++;
        }
        if (canShotBullet2 == true)
        {
            var shot2 = Instantiate(m_bullet[2], pos, rot);
            shot2.SetBulletSpeed(m_bulletSpeed);
            bulletCountIndex++;
        }
        if (canShotBullet3 == true)
        {
            var shot3 = Instantiate(m_bullet[3], pos, rot);
            shot3.SetBulletSpeed(m_bulletSpeed);
            bulletCountIndex++;
        }
        if (canShotBullet4 == true)
        {
            var shot4 = Instantiate(m_bullet[4], pos, rot);
            shot4.SetBulletSpeed(m_bulletSpeed);
            bulletCountIndex++;
        }
        if (canShotBullet5 == true)
        {
            var rot1 = rot;
            var rot2 = rot;
            rot1.z += 0.20f;
            rot2.z -= 0.15f;
            var shot5 = Instantiate(m_bullet[5], pos, rot2);
            var shot6 = Instantiate(m_bullet[5], pos, rot1);
            shot5.SetBulletSpeed(m_bulletSpeed);
            shot6.SetBulletSpeed(m_bulletSpeed);//TODD外に抜き出せる
        }
    }
    //敵が子要素の角度、位置から弾を発射
    public void shotEnemy(Transform origin)
    {
        var pos = origin.position; 

        var rot = origin.rotation;

        var shot = Instantiate(m_bullet[0], pos, rot);
        shot.SetBulletSpeed(m_bulletSpeed);
    }
    // 機体の移動
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * m_speed;
    }
    //アニメーターコンポーネントの取得
    public Animator GetAnimator()
    {
        return animator;
    }
}

