using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TrainingButtonHuzi : MonoBehaviour
{
    private bool firstCheck = false;
    static public bool canShotHuziButton = false;
    static public bool activeHuzi = false;
    public GameObject HuziLank1;
    public AudioClip submitSound;
    public AudioClip cancelSound;
    private AudioSource audioSource;
    public int huziCost = 7500;
    public Text ManeyText;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        HuziLank1 = GameObject.Find("HuziLank1");
        if (activeHuzi == false)
        {
            HuziLank1.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("Play");
        }
        if (canShotHuziButton == true)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
        }
    }
    public void OnClick()
    {

        if (HuziLank1.activeSelf == false && Score.maney >= huziCost&&firstCheck==false)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
            activeHuzi = true;
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
        Score.maney -= huziCost;
        yield return new WaitForSeconds(0.3f);
        HuziLank1.SetActive(true);
        canShotHuziButton = true;

    }
}
