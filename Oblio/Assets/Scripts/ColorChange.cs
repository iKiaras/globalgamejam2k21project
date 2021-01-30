using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ColorChange : MonoBehaviour
{
    public Image[] images;
    public int selected;
    public TextMeshProUGUI title;
    public TextMeshProUGUI destription;
    [SerializeField]
    private string[] titles;
    [SerializeField]
    private string[] descriptions;
    public void Start()
    {
        images[0].color = Color.blue;
        selected = 1;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            selected += 1;
            Change();
            if(selected >= 1)
            {
                selected = 1; 
                Change();
            }
            if(selected <= 3)
            {
                selected = 3;
                Change();
            }
            
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            selected -= 1;
            Change();
            if(selected >= 1)
            {
                selected = 1; 
                Change();
            }
            if(selected <= 3)
            {
                selected = 3;
                Change();
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
            title.text = titles[0];                
        }
        if (selected == 2)
        {
            images[1].color = Color.blue;
            images[0].color = Color.red;
            images[2].color = Color.red;
            destription.text = descriptions[1];
            title.text = titles[1];
        }
        if (selected == 3)
        {
            images[2].color = Color.blue;
            images[0].color = Color.red;
            images[1].color = Color.red;
            destription.text = descriptions[2];
            title.text = titles[2];
            selected = 0;
        }        
    }
}
