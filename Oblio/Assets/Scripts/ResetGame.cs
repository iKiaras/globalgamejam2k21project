using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("firstStageClear", 0);
        PlayerPrefs.SetInt("secondStageClear", 0);
        PlayerPrefs.SetInt("thirdStageClear", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
