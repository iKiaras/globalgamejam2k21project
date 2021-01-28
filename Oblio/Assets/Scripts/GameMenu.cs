using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{

    [SerializeField] private GameObject theMenu;
    [SerializeField] private GameObject[] windows;
    [SerializeField] private Text nameText, hPText, mPText, levelText, expText;
    [SerializeField] private Slider expSlider;
    [SerializeField] private Image characterImage;
    [SerializeField] private Text str, defence, equippedWpn, wpnPower, equippedArmor, armorPwr;
    [SerializeField] private List<ItemButton> itemButtons;
    [SerializeField] private GameObject ItemButtonsPanel;
    private CharacterStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2")) 
        {
            if (theMenu.activeInHierarchy)
            {
                closeMenu();
            }
            else
            {
                UpdateMainStats();
                GameManager.getInstance().MenuOpened();
                theMenu.SetActive(true);
            }
        }
    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.getInstance().CharStats;

        nameText.text = playerStats.CharacterName;
        hPText.text = playerStats.CurrentHp + "/" + playerStats.MaxHp;
        mPText.text = playerStats.CurrentMp + "/" + playerStats.MaxMp;
        levelText.text = "Level: "+ playerStats.PlayerLevel;
        expText.text = playerStats.CurrentExp + "/" + playerStats.ExpToNextLevel[playerStats.PlayerLevel];
        expSlider.value = playerStats.CurrentExp;
        expSlider.maxValue = playerStats.ExpToNextLevel[playerStats.PlayerLevel];
        characterImage.sprite = playerStats.CharImage;
    }

    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();
        for (int i = 0; i < windows.Length; i++)
        {
            if (i==windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void closeMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        
        theMenu.SetActive(false);
        
        GameManager.getInstance().MenuClosed();
    }

    public void CharacterStatus()
    {
        str.text = playerStats.Strength.ToString();
        defence.text = playerStats.Defence.ToString();
        if (!playerStats.EquippedWeaponName.Equals(""))
        {
            equippedWpn.text = playerStats.EquippedWeaponName;
        }
        else
        {
            equippedWpn.text = "None";
        }
        wpnPower.text = playerStats.WeaponPower.ToString();
        if (!playerStats.EquippedArmorName.Equals(""))
        {
            equippedArmor.text = playerStats.EquippedArmorName;
        }
        else
        {
            equippedArmor.text = "None";
        }
        armorPwr.text = playerStats.ArmorPower.ToString();
    }

    public void ShowItems()
    {
        foreach (string key in GameManager.getInstance().GetItemsHeld().Keys)
        {
            if (GameManager.getInstance().GetItemsHeld()[key] > 0)
            {
                // GameObject
                ItemButton newItemButton = Instantiate(Resources.Load("ItemButton")) as ItemButton;
                newItemButton.GetButtonImage().gameObject.SetActive(true);
                newItemButton.GetButtonImage().sprite = GameManager.getInstance().GetItemDetails(key).GetItemSprite();
                newItemButton.GetAmountText().text = GameManager.getInstance().GetItemsHeld()[key].ToString();
                itemButtons.Add(newItemButton);
            }
        }

        foreach (ItemButton itemButton in itemButtons)
        {
            Instantiate(itemButton).transform.parent = ItemButtonsPanel.transform;
        }

        // foreach (ItemButton itemPicked in itemButtons)
        // {
        //     if (GameManager.getInstance().GetItemsHeld().ContainsKey(itemPicked.name) && GameManager.getInstance().GetItemsHeld()[itemPicked.name] > 0)
        //     {
        //         itemPicked.GetButtonImage().gameObject.SetActive(true);
        //         itemPicked.GetButtonImage().sprite = GameManager.getInstance().GetItemDetails(itemPicked.name).GetItemSprite();
        //     }
        // }
    }
}
