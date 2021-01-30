using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireworkGamePlayerInfo : MonoBehaviour
{
    [SerializeField] private GameObject firework;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text elliesText;
    [SerializeField] private Text carlsText;
    [SerializeField] private AudioSource song;
    private static int score = 0;
    private bool elliesTextShown = false;
    private bool carlsTextShown = false;
    private Random _random;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnFireworks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     private void checkText() //TODO FIX DIALOG
    {
        if (score >= 700 && score > 670 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            elliesTextShown = false;
            carlsTextShown = true;
            carlsText.text = "I love you too....";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        } else if (score <= 640 && score > 610 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = " ….I love you...";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        } else if (score <= 580 && score > 550 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            elliesTextShown = false;
            carlsTextShown = true;
            carlsText.text = "We will close our eyes and we will hardwire this memory to our brains, in this way as long as we are alive we can live this moment again and again!";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        } else if (score <= 520 && score > 490 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "Oh I love magic tricks! Tell me!";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        } else if (score <= 460 && score > 430 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            elliesTextShown = false;
            carlsTextShown = true;
            carlsText.text = "I'll tell you what, we will do a magic trick.";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        } else if (score <= 400 && score > 370 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "hahahaha";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        }
        else if (score <= 340 && score > 310 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            elliesTextShown = false;
            carlsTextShown = true;
            carlsText.text = "Me too, or until I feel excruciating pain from my feet, which I think it will be in the next 10 minutes.";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        }else if (score <= 280 && score > 250 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "I hope this dance lasts forever!";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        }else if (score <= 210 && score > 180 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            carlsTextShown = true;
            elliesTextShown = false;
            carlsText.text = "They will be the best!";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        }else if (score <= 150 && score > 120 && !elliesTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(carlsText));
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "Oh am I? I really hope that are at least good.";
            StartCoroutine(FadeTextToFullAlpha(elliesText));
        }else if (score <= 90 && score > 60 && !carlsTextShown)
        {
            StartCoroutine(FadeTextToZeroAlpha(elliesText));
            carlsTextShown = true;
            elliesTextShown = false;
            carlsText.text = "There are many things you don't know about me!";
            StartCoroutine(FadeTextToFullAlpha(carlsText));
        }else if (score == 30 && !elliesTextShown)
        {
            carlsTextShown = false;
            elliesTextShown = true;
            elliesText.text = "Who would imagine that you are such a good dancer.";
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

        while (score < 100)
        {
            var randomPosition = new Vector3(Random.Range(-5.60f, 5.60f), -6.55f, 0f);
            GameObject fireworkInstantiate = Instantiate(firework, randomPosition, Quaternion.identity);
            fireworkInstantiate.transform.parent = canvas.transform;
            fireworkInstantiate.transform.localScale = Vector3.one;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }

    }
    
    public static void AddScore()
    {
        score+=10;
    }
}
