using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject myCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();
        
        fireWeapon();
    }


    private void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right * horizontalInput * 8 * Time.deltaTime);

        if (transform.position.x > 5.50f )
        {
            transform.position = new Vector3(-5.50f, transform.position.y, 0);
        }
        else if(transform.position.x < -5.50f)
        {
            transform.position = new Vector3(5.50f, transform.position.y, 0);
        }
    }


    private void fireWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
           laser.transform.localScale = new Vector3(0.05f,0.05f);
           laser.transform.parent = myCanvas.transform;
        }
    }
}

