using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainingButtonShizuoka : MonoBehaviour
{
    private bool firstCheck = false;
    static public bool canShotShizuButton = true;
    static public bool canShotShizuButton2 = false;
    static public int shizuokaLank = 1;
    public int shizuokaCost = 10000;
    static public bool canShotShizu2 = false;
    static public bool activeShizu2 = false;
    public GameObject shizuokaLank1;
    public GameObject shizuokaLank2;
    public AudioClip submitSound;
    public AudioClip cancelSound;
    private AudioSource audioSource;
    public  Text ManeyText;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shizuokaLank2 = GameObject.Find("ShizuokaLank2");
        if (canShotShizuButton2 == false)
        {
            shizuokaLank2.SetActive(false);
        }
        if (canShotShizuButton2 == true)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
        }
    }

    public void OnClick()
    {
        if (shizuokaLank2.activeSelf == false && Score.maney >= shizuokaCost&& firstCheck==false)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
            activeShizu2 = true;
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
        Score.maney -= shizuokaCost;
        yield return new WaitForSeconds(0.3f);
        shizuokaLank2.SetActive(true);
        canShotShizuButton = false;
        canShotShizuButton2 = true;

    }
}
