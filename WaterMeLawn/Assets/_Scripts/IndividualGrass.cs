using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualGrass : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject particleOBJ;

    [SerializeField] GameObject brokenGrass;

    private void Start()
    {
        particleOBJ.SetActive(false);
    }

    public void CutGrass(ParticleSystem mowerParticle){

        //particleOBJ.SetActive(true);
        //particle.Play();
        mowerParticle.Play();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        brokenGrass.SetActive(true);

    }
}
