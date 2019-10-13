using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainingButtonHamamatu : MonoBehaviour
{
    //連続で押した際に反応しないようにする変数
    private bool firstCheck = false;
    //浜松からLank１弾が出るか
    static public bool canShotHamaButton = false;
    //浜松からLAnk2弾が出るか
    static public bool activeHamamatu = false;
    //Lank１の建物画像を表示するか
    public GameObject hamamatuLank1;
    //
    public AudioClip submitSound;
    public AudioClip cancelSound;
    private AudioSource audioSource;
    public int hamamatuCost = 5000;
    public Text ManeyText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hamamatuLank1 = GameObject.Find("HamamatuLank1");
        if (activeHamamatu == false)
        {
            hamamatuLank1.SetActive(false);
        }
        if (canShotHamaButton == true)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Play");
        }
    }
    public void OnClick()
    {
        if (hamamatuLank1.activeSelf == false&&Score.maney >= hamamatuCost&& firstCheck==false)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
            activeHamamatu = true;
            StartCoroutine("build");
            firstCheck = true;
        }
        else{
            audioSource.PlayOneShot(cancelSound);
        }
    }
    IEnumerator build()
    {
        audioSource.PlayOneShot(submitSound);
        Score.maney -= hamamatuCost;
        yield return new WaitForSeconds(0.3f);
        hamamatuLank1.SetActive(true);
        canShotHamaButton = true;
        
    }
}
