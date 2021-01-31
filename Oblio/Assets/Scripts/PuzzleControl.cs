using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleControl : MonoBehaviour
{
    [SerializeField] private Transform[] pictures;
    [SerializeField] private TextMeshProUGUI carlText;
    [SerializeField] private GameObject winPanel;
    public static bool youWin;
    private bool textFinished;
    // Start is called before the first frame update
    void Start()
    {
        youWin = false;
        textFinished = false;
        StartCoroutine(showText());
    }

    // Update is called once per frame
    void Update()
    {
        checkIfFinished();
        
        if ((pictures[0].rotation.z.Equals(0f) ||  pictures[0].rotation.z.Equals(360f))  && (pictures[1].rotation.z.Equals(0f) ||  pictures[1].rotation.z.Equals(360f)) 
                                                                                         && (pictures[2].rotation.z.Equals(0f) ||  pictures[2].rotation.z.Equals(360f)) 
                                                                                         && (pictures[3].rotation.z.Equals(0f) ||  pictures[3].rotation.z.Equals(360f))  
                                                                                         && (pictures[4].rotation.z.Equals(0f) ||  pictures[4].rotation.z.Equals(360f))
                                                                                         && (pictures[5].rotation.z.Equals(0f) ||  pictures[5].rotation.z.Equals(360f)) 
                                                                                         && (pictures[6].rotation.z.Equals(0f) ||  pictures[6].rotation.z.Equals(360f)) 
                                                                                         && (pictures[7].rotation.z.Equals(0f) ||  pictures[7].rotation.z.Equals(360f)) 
                                                                                         && (pictures[8].rotation.z.Equals(0f) ||  pictures[8].rotation.z.Equals(360f))
        )
        {
            youWin = true;
        }
    }

    IEnumerator showText()
    {
        carlText.text = "I know you are going to be fine, I know it. You would never do that to me, right? No, you wouldn't. You promised you would be fine.";
        StartCoroutine(FadeTextToFullAlpha(carlText));
        yield return new WaitForSeconds(10);
        StartCoroutine(FadeTextToZeroAlpha(carlText));
        yield return new WaitForSeconds(3);

        carlText.text = "You know how mad I get when you lie to me! So you better keep your promise or I will be furious, in a really bad way!";
        StartCoroutine(FadeTextToFullAlpha(carlText));
        yield return new WaitForSeconds(10);
        StartCoroutine(FadeTextToZeroAlpha(carlText));
        yield return new WaitForSeconds(3);

        carlText.text = "Please answer me. At least nod. Please, I miss you. A small nod, or move your finger and I will be fine.";
        StartCoroutine(FadeTextToFullAlpha(carlText));
        yield return new WaitForSeconds(10);
        StartCoroutine(FadeTextToZeroAlpha(carlText));
        yield return new WaitForSeconds(3);

        carlText.text = "Please I can't do it without you. I am a joke, how am I supposed to live without you? I can't even find the power to get off the bed...";
        StartCoroutine(FadeTextToFullAlpha(carlText));
        yield return new WaitForSeconds(10);
        StartCoroutine(FadeTextToZeroAlpha(carlText));
        yield return new WaitForSeconds(3);

        carlText.text = "I love you, I will always love you. I will always be with you...";
        StartCoroutine(FadeTextToFullAlpha(carlText));
        yield return new WaitForSeconds(10);
        StartCoroutine(FadeTextToZeroAlpha(carlText));
        yield return new WaitForSeconds(3);

        textFinished = true;
    }
    
    public IEnumerator FadeTextToFullAlpha(TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / 0.3f));
            yield return null;
        }
    }
    
    public IEnumerator FadeTextToZeroAlpha(TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / 0.3f));
            yield return null;
        }
    }


    private void checkIfFinished()
    {
        if (youWin && textFinished)
        {
            PlayerPrefs.SetInt("thirdStageClear",1);
            PlayerPrefs.Save();
            winPanel.SetActive(true);
        }
    }
    
    public void returnToMenu()
    {
        SceneManager.LoadScene("HospitalScene" , LoadSceneMode.Single);
    }
}
