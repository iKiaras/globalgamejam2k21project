using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Text amountText;
    [SerializeField] private int buttonValue;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetButtonValue()
    {
        return buttonValue;
    }

    public Text GetAmountText()
    {
        return amountText;
    }

    public Image GetButtonImage()
    {
        return buttonImage;
    }
}
