
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Emitter : MonoBehaviour
{
    //エミッターを繰り返す回数
    public int m_roopCountEmitter;
    // Waveプレハブを格納する
    public GameObject[] waves;
    // 現在のWave
    private int currentWave;
    //Managerコンポーネント
    private Manager manager;
    //現在のステージ
    [SerializeField]
    public static int stageCount = 1;

    private int i = 0;


   IEnumerator Start()
    {
        //ディレイをかける
        yield return new WaitForSeconds(2);
        // Waveが存在しなければコルーチンを終了する
        if (waves.Length == 0)
        {
            //ウェーブがない場合強化画面に遷移
            SceneManager.LoadScene("Training");
            yield break;
        }
        // Managerコンポーネントをシーン内から探して取得する
        manager = FindObjectOfType<Manager>();
        

        //m_roopCountEmitterの数だけコルーチンを繰り返す
        while (m_roopCountEmitter > i)
        {
            //プレイ中ではない場合中断
            while (manager.IsPlaying() == false)
            {

                yield return new WaitForEndOfFrame();
            }

            //wavaオブジェクトを作成
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);
            

            // WaveをEmitterの子要素にする

            wave.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            // Waveの削除
            Destroy(wave);
            

            // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                
                currentWave = 0;
                i++;
                if (m_roopCountEmitter == i)
                {
                    //格納させているwavaをすべて実行したらステージカウントを増やしゲームクリアとする
                    stageCount++;
                    manager.GameClear();
                }
            }
            //次のwavaが出るまでディレイをかける
            yield return new WaitForSeconds(1.5f);
        }
    }
}
