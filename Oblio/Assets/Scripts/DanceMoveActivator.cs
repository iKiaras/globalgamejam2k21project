using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanceMoveActivator : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private bool createMode;
    [SerializeField] private GameObject note;
    private Color oldColor;
    private Image _image;
    private bool active = false;


    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        oldColor = _image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(note, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }
        
            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                DanceGamePlayerInfo.AddScore();
            }   
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        active = true;
        if (collider.gameObject.tag =="Note")
        {
            note = collider.gameObject;
        }
    }

    
    private void OnTriggerExit2D(Collider2D collider)
    {
        active = false;
    }

    IEnumerator Pressed()
    {
        _image.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        _image.color = oldColor;

    }
}
