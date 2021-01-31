using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FireworkGamePlayerInfo : MonoBehaviour
{
    [SerializeField] private GameObject firework;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text elliesText;
    [SerializeField] private Text carlsText;
    [SerializeField] private AudioSource song;
    [SerializeField] private AudioSource spawnSound;
    [SerializeField] private Text scoreText;
    private static int score = 0;
    private bool elliesTextShown = false;
    private bool carlsTextShown = false;
    private Random _random;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(spawnFireworks());
    }

    // Update is called once per frame
    void Update()
    {
        checkText();
        scoreText.text = score.ToString();
    }
    
     private void checkText() 
    {
        if (score >= 700 && score > 670 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            elliesTextShown = false;
            carlsTextShown = true;
            carlsText.text = "Trust me, everything is gonna be fine.";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        } else if (score <= 640 && score > 610 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "No they are not... I don't know if we can make it through!";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        } else if (score <= 580 && score > 550 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            elliesTextShown = false;
            carlsTextShown = true;
            carlsText.text = "That's great news!!";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        } else if (score <= 520 && score > 490 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "Yeah, really... And I am scared.";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        } else if (score <= 460 && score > 430 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            elliesTextShown = false;
            carlsTextShown = true;
            carlsText.text = "What?? Really???";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        } else if (score <= 400 && score > 370 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "I am pregnant...";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        }
        else if (score <= 340 && score > 310 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            elliesTextShown = false;
            carlsTextShown = true;
            carlsText.text = "What is it? I am getting worried...";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        }else if (score <= 280 && score > 250 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "I don't know if I can say it...";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        }else if (score <= 210 && score > 180 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            carlsTextShown = true;
            elliesTextShown = false;
            carlsText.text = "What is it?";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        }else if (score <= 150 && score > 120 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "Happy new year... baby... I have something to tell you...";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        }else if (score <= 90 && score > 60 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            carlsTextShown = true;
            elliesTextShown = false;
            carlsText.text = "Happy new year baby!";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        }else if (score == 30 && !elliesTextShown)
        {
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "3,2,1... HAPPY NEW YEAR.";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        }

    }
     
     public IEnumerator FadeTextToFullAlpha(Text i)
     {
         i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
         while (i.color.a < 1.0f)
         {
             i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / 0.3f));
             yield return null;
         }
     }
    
     public IEnumerator FadeTextToZeroAlpha(Text i)
     {
         i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
         while (i.color.a > 0.0f)
         {
             i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / 0.3f));
             yield return null;
         }
     }
    

    IEnumerator spawnFireworks()
    {
        while (score < 730)
        {
            var randomPosition = new Vector3(Random.Range(-5.60f, 5.60f), -6.55f, 0f);
            GameObject fireworkInstantiate = Instantiate(firework, randomPosition, Quaternion.identity);
            fireworkInstantiate.transform.parent = canvas.transform;
            fireworkInstantiate.transform.localScale = Vector3.one;
            spawnSound.Play();
            yield return new WaitForSeconds(Random.Range(1f, 4f));
        }
    }
    
    public static void AddScore()
    {
        score+=15;
    }
    
    public void returnToMenu()
    {
        SceneManager.LoadScene("MiniGameMenu" , LoadSceneMode.Single);
    }

    public void restartScene()
    {
        SceneManager.LoadScene("DanceMiniGame" , LoadSceneMode.Single);
    }
}
