using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField]
    private int rotateSpeed;
    [SerializeField]
    private int moveSpeed;
    [SerializeField]
    public int lifeTime;
    [SerializeField]
    private Rigidbody rb;


    private void Start()
    {
    }
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    public void TouchedCoin()
    {
        StartCoroutine(CoinFloat());
    }

    IEnumerator CoinFloat ()
    {
        GameManager otherScriptOnGameObject = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
        otherScriptOnGameObject.CoinCounting();
        rotateSpeed = 10;
        rb.velocity = transform.up * moveSpeed;
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
