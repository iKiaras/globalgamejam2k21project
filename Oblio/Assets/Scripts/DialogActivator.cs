using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogActivator : MonoBehaviour
{
    [SerializeField] private List<string> lines;
    [SerializeField] private bool isPerson = true;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Text text3;
    [SerializeField] private Text text4;
    private bool _canActivate;
    private int firstStage;
    private int secondStage;
    private int thirdStage;

    private bool dialogOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        firstStage = PlayerPrefs.GetInt("firstStageClear");
        secondStage = PlayerPrefs.GetInt("secondStageClear");
        thirdStage = PlayerPrefs.GetInt("thirdStageClear");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPerson ==false && _canActivate && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
        {
            SceneManager.LoadScene("MiniGameMenu" , LoadSceneMode.Single);
        }
        else if (isPerson && _canActivate && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && !dialogOpen)
        {
            dialogOpen = true;
            dialogPanel.SetActive(true);

            if (firstStage == 0 && secondStage == 0 && thirdStage == 0)
            {
                text1.gameObject.SetActive(true);
            }
            else if (firstStage == 1 && secondStage == 0 && thirdStage == 0)
            {
                text2.gameObject.SetActive(true);
            } else if (firstStage == 1 && secondStage == 1 && thirdStage == 0)
            {
                text3.gameObject.SetActive(true);
            } else if (firstStage == 1 && secondStage == 1 && thirdStage == 1)
            {
                text4.gameObject.SetActive(true);
            }
        }
        else if (isPerson && _canActivate && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && dialogOpen)
        {
            dialogPanel.SetActive(false);
            dialogOpen = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canActivate = false;
        }
    }
}
