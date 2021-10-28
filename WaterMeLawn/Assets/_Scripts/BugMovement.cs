using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BugMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;
    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private BugController bugController;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    public GameObject startupText;

    private void OnMouseDown()
    {
        if (bugController.Lose == false && bugController.Win == false)
        {
            bugController.Start1 = true;
            startupText.SetActive(false);
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            this.gameObject.SetActive(false);
            bugController.BugsRemaining--;
        }
    }

    private void Start()
    {
        int randomNumber = Random.Range(0, 7);

        if (randomNumber == 0)
        {
            rb2D.velocity = transform.right * speed;
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