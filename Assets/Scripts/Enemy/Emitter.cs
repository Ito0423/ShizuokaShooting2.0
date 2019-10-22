﻿
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Emitter : MonoBehaviour
{
    //定数
    readonly float WAIT_EMITTE_TIME = 2.0f;
    readonly string ENEMY_TAG = "Enemy";

    //インスペクターで追加するオブジェクト
    public GameObject[] _waves;

    IEnumerator Start()
    {
        int _currentWave = 0;

        for (_currentWave = 0; _currentWave < _waves.Length; _currentWave++)
        {
            yield return new WaitForSeconds(WAIT_EMITTE_TIME);

            //waves配列に格納されたエネミーを生む
            GameObject wave = Instantiate(_waves[_currentWave],
                _waves[_currentWave].transform.position, _waves[_currentWave].transform.rotation);

            GameObject[] enemyTags = GameObject.FindGameObjectsWithTag(ENEMY_TAG);

            foreach (GameObject enemyTag in enemyTags)
            {
                while (enemyTag)
                {
                    yield return new WaitForEndOfFrame();
                }

                Destroy(this.gameObject);
            }

            //画面のエネミーがすべて倒されるまで待つ

            Debug.Log(_currentWave);
            Debug.Log(_waves.Length);
            //格納されたwa
            if (_currentWave == _waves.Length - 1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    /*for (int i = 0; i < 3; i++)
    {
        //  配列に格納されたプレハブ Wave からインスタンスを生成して wave に格納




        // 敵機 wave を Emitter の子要素にする
        //one.transform.parent = transform;
        // Emitter の子要素の敵機 wave の数が 0 でなければ
        // 敵機 wave の削除

        // 現在の敵機のインデックスに加算し、配列に格納された数以上になれば
        if (_waves.Length <= ++_currentWave)
        {
            // 現在の敵機のインデックスを 0 にする
            _currentWave = 1;
        }
    }*/
}


/* IEnumerator Start()
 {

     //ディレイをかける
     //yield return new WaitForSeconds(WAIT_EMITTE_TIME);
     // Waveが存在しなければコルーチンを終了する
     if (_waves.Length == 0)
     {
         yield break;
     }

     //m_roopCountEmitterの数だけコルーチンを繰り返す
     while(true){
         //wavaオブジェクトを作成
         GameObject wave = (GameObject)Instantiate(_waves[_currentWave], transform.position, Quaternion.identity);


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
         if (_waves.Length <= ++_currentWave)
         {
             _currentWave = 0;
             *//* i++;
              if (_roopCountEmitter == i)
              {
                  //格納させているwavaをすべて実行したらステージカウントを増やしゲームクリアとする
                  stageCount++;
                  Destroy(this);
              }*//*
         }
     }
         *//*//次のwavaが出るまでディレイをかける
         yield return new WaitForSeconds(1.5f);*//*

 }*/




//古いコード↓

/*IEnumerator Start()
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
}*/

