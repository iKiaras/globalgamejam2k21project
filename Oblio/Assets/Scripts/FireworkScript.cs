using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireworkScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private bool exploded = false;
    [SerializeField] private AudioSource explosion1, explosion2, explosion3;
    private Animator _animator;

    private AudioSource thisAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        thisAudioSource = gameObject.GetComponent<AudioSource>();
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
        // _animator.SetTrigger("Explode");
        int choice = Random.Range(1, 4);
        _animator.SetInteger("firework",choice);

        if (choice == 1)
        {
            thisAudioSource.clip = explosion1.clip;
            thisAudioSource.Play();
        }
        else if(choice == 2)
        {
            thisAudioSource.clip = explosion2.clip;
            thisAudioSource.Play();
        }
        else
        {
            thisAudioSource.clip = explosion2.clip;
            thisAudioSource.Play();
        }
        
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
