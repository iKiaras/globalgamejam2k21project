using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator _animator;


    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
            _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) *
                                    movementSpeed;

            _animator.SetFloat("moveX", _rigidbody2D.velocity.x);
            _animator.SetFloat("moveY", _rigidbody2D.velocity.y);
        
        
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
                Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                _animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                _animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
                
                
            }
            // transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            //     Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
              
    }

    public void SetBounds(Vector3 newBottomLeftLimit, Vector3 newTopRightLimit)
    {
        // bottomLeftLimit = newBottomLeftLimit + new Vector3(1, 1, 0);
        // topRightLimit = newTopRightLimit - new Vector3(1, 1, 0);
    }

   

    public static void setInstance(PlayerController playerController)
    {
        // instance = playerController;
    }

 

    public void disableMovement()
    {
        // canMove = false;
    }

    public void enableMovement()
    {
        // canMove = true;
    }
}