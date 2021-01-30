using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ColorChange : MonoBehaviour
{
    public Image[] images;
    public int selected;
    public AudioClip[] clicks;
    public AudioSource source;
    public TextMeshProUGUI destription;
    public void Start()
    {
        images[0].color = Color.blue;
        selected = 1;
    }
    public void Update()
    {
        Change();
    }
    public void Change()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {     
            //source.clip = clicks[Random.Range(0 ,clicks.Length)];
            //source.Play();
            selected += 1;
            if(selected == 1)
            {
                images[0].color = Color.blue;
                images[1].color = Color.red;
                images[2].color = Color.red;  
            }
            if(selected == 2)
            {
                images[1].color = Color.blue;
                images[0].color = Color.red;
                images[2].color = Color.red;
            }
            if(selected == 3)
            {
                images[2].color = Color.blue;
                images[0].color = Color.red;
                images[1].color = Color.red; 
                selected = 0;
            } 
            
        }
    }
}
