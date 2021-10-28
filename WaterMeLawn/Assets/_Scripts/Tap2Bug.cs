using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap2Bug : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private int health;

    [SerializeField]
    private BugController bugController;

    [SerializeField]
    private GameObject explosion;

    private void OnMouseDown()
    {
        if (bugController.Lose == false && bugController.Win == false)
        {
            health--;
            //do particle here
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            if (health <= 0)
            {
                bugController.BugsRemaining--;
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        int randomNumber = Random.Range(0, 7);
        
        if (randomNumber == 0)
        {
            rb.velocity = transform.right * speed;
        }
        else if (randomNumber == 1) 
        {
            rb.velocity = transform.up * speed;
        }
        else if (randomNumber == 2)
        {
            rb.velocity = transform.right * -speed;
        }
        else if (randomNumber == 3)
        {
            rb.velocity = transform.up * -speed;
        }
        else if (randomNumber == 4)
        {
            rb.velocity = (transform.right * speed) + (transform.up * speed);
        }
        else if (randomNumber == 5)
        {
            rb.velocity = (transform.right * -speed) + (transform.up * -speed);
        }
        else if (randomNumber == 6)
        {
            rb.velocity = (transform.right * speed) + (transform.up * -speed);
        }
        else if (randomNumber == 7)
        {
            rb.velocity = (transform.right * -speed) + (transform.up * speed);
        }
    }
}