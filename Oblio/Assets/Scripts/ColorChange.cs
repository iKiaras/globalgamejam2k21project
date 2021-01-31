using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ColorChange : MonoBehaviour
{
    public Image[] images;
    public int selected;
    public TextMeshProUGUI title;
    public TextMeshProUGUI destription;
    [SerializeField]
    private string[] descriptions;

    public bool sceneTransitioning = false;
    public void Start()
    {
        images[0].color = Color.blue;
        selected = 1;
        destription.text = descriptions[0];
    }
    public void Update()
    {
        if (!sceneTransitioning)
        {
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                selected += 1;        
                if(selected < 1)
                {
                    selected = 3; 
                }
                if(selected > 3)
                {
                    selected = 1;
                }
                Change();
            
            }
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selected -= 1;               
                if(selected < 1 )
                {
                    selected = 3;
                }               
                if(selected > 3)
                {
                    selected = 1;
                }
                Change();
            }
        
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(selected == 1)
                {
                    sceneTransitioning = true;
                    SceneManager.LoadScene("DanceMiniGame" , LoadSceneMode.Single);
                    // GameManager.getInstance().SceneTransitionStarted();
                    // UIFader.getInstance().fadeToBlack();                
                }
                if(selected == 2)
                {
                    sceneTransitioning = true;
                    SceneManager.LoadScene("FireworksScene" , LoadSceneMode.Single);
                    // GameManager.getInstance().SceneTransitionStarted();
                    // UIFader.getInstance().fadeToBlack();                
                }
                if(selected == 3)
                {
                    sceneTransitioning = true;
                    SceneManager.LoadScene("DeathScene" , LoadSceneMode.Single);
                    // GameManager.getInstance().SceneTransitionStarted();
                    // UIFader.getInstance().fadeToBlack();                
                }
            }
        }
        
    }
    public void Change()
    {
        if (selected == 1)
        {
            images[0].color = Color.blue;
            images[1].color = Color.red;
            images[2].color = Color.red;
            destription.text = descriptions[0];    
        }
        if (selected == 2)
        {
            images[1].color = Color.blue;
            images[0].color = Color.red;
            images[2].color = Color.red;
            destription.text = descriptions[1];
        }
        if (selected == 3)
        {
            images[2].color = Color.blue;
            images[0].color = Color.red;
            images[1].color = Color.red;
            destription.text = descriptions[2];
        }        
    }
}
