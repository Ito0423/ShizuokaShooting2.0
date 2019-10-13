using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TrainingButtonYama : MonoBehaviour
{
    private bool firstCheck = false;
    public GameObject YamaLank1;
    static public bool canShotYamaButton = false;
    static public bool activeYama = false;
    public AudioClip submitSound;
    public AudioClip cancelSound;
    private AudioSource audioSource;
    public int yamaCost = 10000;
    public Text ManeyText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        YamaLank1 = GameObject.Find("YamaLank1");
        if (activeYama == false)
        {
            YamaLank1.SetActive(false);
        }
        if (canShotYamaButton == true)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Play");
        }
    }
    public void OnClick()
    {
        if (YamaLank1.activeSelf == false && Score.maney >= yamaCost&&firstCheck==false)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
            activeYama = true;
            StartCoroutine("build");
            firstCheck = true;
        }
        else
        {
            audioSource.PlayOneShot(cancelSound);
        }
    }
    IEnumerator build()
    {
        audioSource.PlayOneShot(submitSound);
        Score.maney -= yamaCost;
        yield return new WaitForSeconds(0.3f);
        YamaLank1.SetActive(true);
        canShotYamaButton = true;
        


    }
}
