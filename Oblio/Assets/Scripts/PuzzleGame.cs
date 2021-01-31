using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGame : MonoBehaviour
{
    [HideInInspector]
    public bool clicked = false;
    [HideInInspector]
    public bool moved = false;
    [HideInInspector]
    public bool goLeft,goRight,goUp, goDown;
    [HideInInspector]
    public Vector2 moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePuzzle();
    }

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void OnMouseUp()
    {
        clicked = false;
        moved = false;
    }

    void MovePuzzle()
    {
        if (goLeft)
        {
            transform.position = new Vector3(transform.position.x - moveAmount.x, transform.position.y,
                transform.position.z);
            goLeft = false;
            moved = true;
        }
        if (goRight)
        {
            transform.position = new Vector3(transform.position.x + moveAmount.x, transform.position.y,
                transform.position.z);
            goRight = false;
            moved = true;
        }
        if (goUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveAmount.y,
                transform.position.z);
            goUp = false;
            moved = true;
        }
        if (goDown)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y - moveAmount.y,
                transform.position.z);
            goDown = false;
            moved = true;
        }
    }
}
