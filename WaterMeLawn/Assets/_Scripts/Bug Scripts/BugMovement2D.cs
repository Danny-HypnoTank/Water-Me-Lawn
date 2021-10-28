using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement2D : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private int randomNumber;

    [SerializeField]
    private BugControllerSpawns bugController;

    [SerializeField]
    private GameObject explosion;

    private void OnMouseDown()
    {
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        this.gameObject.SetActive(false);
        bugController.BugsRemaining--;
    }

    private void OnEnable()
    {
        randomNumber = Random.Range(0, 7);

        if (randomNumber == 0)
        {
            rb2D.velocity = transform.up * speed;
        }
        else if (randomNumber == 1)
        {
            rb2D.velocity = transform.up * speed;
        }
        else if (randomNumber == 2)
        {
            rb2D.velocity = transform.right * -speed;
        }
        else if (randomNumber == 3)
        {
            rb2D.velocity = transform.up * -speed;
        }
        else if (randomNumber == 4)
        {
            rb2D.velocity = (transform.right * speed) + (transform.up * speed);
        }
        else if (randomNumber == 5)
        {
            rb2D.velocity = (transform.right * -speed) + (transform.up * -speed);
        }
        else if (randomNumber == 6)
        {
            rb2D.velocity = (transform.right * speed) + (transform.up * -speed);
        }
        else if (randomNumber == 7)
        {
            rb2D.velocity = (transform.right * -speed) + (transform.up * speed);
        }
    }

    private void Start()
    {
        randomNumber = Random.Range(0, 7);

        if (randomNumber == 0)
        {
            rb2D.velocity = transform.up * speed;
        }
        else if (randomNumber == 1)
        {
            rb2D.velocity = transform.up * speed;
        }
        else if (randomNumber == 2)
        {
            rb2D.velocity = transform.right * -speed;
        }
        else if (randomNumber == 3)
        {
            rb2D.velocity = transform.up * -speed;
        }
        else if (randomNumber == 4)
        {
            rb2D.velocity = (transform.right * speed) + (transform.up * speed);
        }
        else if (randomNumber == 5)
        {
            rb2D.velocity = (transform.right * -speed) + (transform.up * -speed);
        }
        else if (randomNumber == 6)
        {
            rb2D.velocity = (transform.right * speed) + (transform.up * -speed);
        }
        else if (randomNumber == 7)
        {
            rb2D.velocity = (transform.right * -speed) + (transform.up * speed);
        }
    }
}
