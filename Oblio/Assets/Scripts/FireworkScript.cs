using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireworkScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private bool exploded = false;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        moveUpwards();
    }

    private void moveUpwards()
    {
        _rigidbody2D.velocity = new Vector2(0,Random.Range(4,8));
    }

    public void OnMouseDown()
    {
        _animator.SetTrigger("Explode");
        _rigidbody2D.velocity = new Vector2(0,0);
        exploded = true;
        FireworkGamePlayerInfo.AddScore();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (exploded && _animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.y > 6.60f)
        {
            Destroy(gameObject);
        }
    }
}
