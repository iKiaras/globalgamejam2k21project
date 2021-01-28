using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterStats charStats; //List if we need more than one character.
    private static GameManager instance;
    
    private bool gameMenuOpen, dialogActive, fadingBetweenAreas;
    private Dictionary<string, int> itemsHeld = new Dictionary<string, int>();
    private List<Item> refferenceItem;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            
            itemsHeld.Add("HP Potion", 5);
            itemsHeld.Add("Iron Sword", 1);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMenuOpen || dialogActive || fadingBetweenAreas)
        {
            PlayerController.getInstance().disableMovement();
        }
        else
        {
            PlayerController.getInstance().enableMovement();
        }
    }

    public Item GetItemDetails(string itemToGrab)
    {
        foreach (Item referencedItem in refferenceItem)
        {
            if (referencedItem.GetItemName().Equals(itemToGrab))
            {
                return referencedItem;
            }
        }
        
        return null;
    }

    public static GameManager getInstance()
    {
        return instance;
    }
    
    public Dictionary<string, int> GetItemsHeld()
    {
        return itemsHeld;
    }

    public void MenuOpened()
    {
        gameMenuOpen = true;
    }

    public void MenuClosed()
    {
        gameMenuOpen = false;
    }

    public void DialogStarted()
    {
        dialogActive = true;
    }

    public void DialogEnded()
    {
        dialogActive = false;
    }

    public void SceneTransitionStarted()
    {
        fadingBetweenAreas = true;
    }

    public void SceneTransitionEnded()
    {
        fadingBetweenAreas = false;
    }

    public CharacterStats CharStats
    {
        get => charStats;
        set => charStats = value;
    }
}
