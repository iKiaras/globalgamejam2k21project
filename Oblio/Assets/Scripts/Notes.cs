using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private int speed;
    [SerializeField] private bool last = false;
    private Transform startingPosition;
    
    private void Awake()
    {
        startingPosition = gameObject.transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D.velocity = new Vector2(-speed,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        checkIfLastExitedScene();
    }

    void checkIfLastExitedScene()
    {
        if (last)
        {
            if (gameObject.transform.position.x < -64f)
            {
                DanceGamePlayerInfo.lost = true;
                Destroy(gameObject);
            }
        }
    }
}
