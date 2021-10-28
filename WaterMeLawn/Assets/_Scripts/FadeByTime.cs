using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeByTime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private float fadeSpeed;
    private bool fadeOut = false;

    private void Awake()
    {
        this.GetComponent<Renderer>().material = Instantiate<Material>(GetComponent<Renderer>().material);
    }

    private void Start()
    {
        StartCoroutine(ParticleLifeCycle());
    }

    private void Update()
    {
        if (fadeOut == true)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a <= 0)
            {
                fadeOut = false;
                //Destroy(this.gameObject);
            }
        }
    }

    IEnumerator ParticleLifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        fadeOut = true;
    }
}
