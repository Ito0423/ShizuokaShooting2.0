using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainingButtonIzu : MonoBehaviour

{
    private bool firstCheck = false;
    static public bool canShotIzuButton = false;
    public GameObject IzuLank1;
    public AudioClip submitSound;
    public AudioClip cancelSound;
    private AudioSource audioSource;
    static public bool activeIzu = false;
    public int izuCost = 15000;
    public Text ManeyText;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        IzuLank1 = GameObject.Find("IzuLank1");
        if (activeIzu == false)
        {
            IzuLank1.SetActive(false);
        }
        if (canShotIzuButton == true)
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

        if (IzuLank1.activeSelf == false && Score.maney >= izuCost&&firstCheck==false)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
            activeIzu = true;
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
        Score.maney -= izuCost;
        yield return new WaitForSeconds(0.3f);
        IzuLank1.SetActive(true);
        canShotIzuButton = true;


    }
}
