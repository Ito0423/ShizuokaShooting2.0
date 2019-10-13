using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingHpButton : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip submitSound;
    public AudioClip cancelSound;
    public int lifeCost = 2000;
    public static int maxStockHp = 5;
    public Text ManeyText;
    private bool firstCheck = false;
    static public bool soldOutCheck = false;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(soldOutCheck == true)
        {
            var ManeyTextSoldOut = "SOLD OUT";
            ManeyText.text = ManeyTextSoldOut.ToString();
        }
    }
    // Start is called before the first frame update
    public void OnClick()
    {
        if (Score.maney >= lifeCost && maxStockHp >= 0 && firstCheck == false)
        {
            audioSource.PlayOneShot(submitSound);
            PlayerHp.playerHp++;
            Score.maney -= lifeCost;
            maxStockHp--;
            if (maxStockHp == 0)
            {
                var ManeyTextSoldOut = "SOLD OUT";
                ManeyText.text = ManeyTextSoldOut.ToString();
                firstCheck = true;
                soldOutCheck = true;  
            }
        }
        else
        {
            audioSource.PlayOneShot(cancelSound);
        }
    }
}
