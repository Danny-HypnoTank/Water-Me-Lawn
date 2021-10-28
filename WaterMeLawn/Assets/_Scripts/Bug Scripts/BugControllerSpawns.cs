using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BugControllerSpawns : MonoBehaviour
{
    [SerializeField]
    private int bugsRemaining;
    [SerializeField]
    private int maxBugs;
    [SerializeField]
    private GameObject[] bugs;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private int bugsToSpawn;

    public int BugsRemaining { get => bugsRemaining; set => bugsRemaining = value; }

    private void Start()
    {
        StartCoroutine(SpawnBugs());
    }

    private void Update()
    {

    }

    IEnumerator SpawnBugs()
    {
        yield return new WaitForSeconds(waitTime);

        while (true)
        {
            if (bugsRemaining < maxBugs)
            {
                if (bugs[0].activeInHierarchy == false && bugsRemaining < maxBugs && bugsToSpawn > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    bugs[0].SetActive(true);
                    bugsRemaining++;
                    bugsToSpawn--;
                }
                if (bugs[1].activeInHierarchy == false && bugsRemaining < maxBugs && bugsToSpawn > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    bugs[1].SetActive(true);
                    bugsRemaining++;
                    bugsToSpawn--;
                }
                if (bugs[2].activeInHierarchy == false && bugsRemaining < maxBugs && bugsToSpawn > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    bugs[2].SetActive(true);
                    bugsRemaining++;
                    bugsToSpawn--;
                }
                if (bugs[3].activeInHierarchy == false && bugsRemaining < maxBugs && bugsToSpawn > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    bugs[3].SetActive(true);
                    bugsRemaining++;
                    bugsToSpawn--;
                }
                if (bugs[4].activeInHierarchy == false && bugsRemaining < maxBugs && bugsToSpawn > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    bugs[4].SetActive(true);
                    bugsRemaining++;
                    bugsToSpawn--;
                }
                if (bugs[5].activeInHierarchy == false && bugsRemaining < maxBugs && bugsToSpawn > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    bugs[5].SetActive(true);
                    bugsRemaining++;
                    bugsToSpawn--;
                }
                if (bugs[6].activeInHierarchy == false && bugsRemaining < maxBugs && bugsToSpawn > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    bugs[6].SetActive(true);
                    bugsRemaining++;
                    bugsToSpawn--;
                }
                if (bugs[7].activeInHierarchy == false && bugsRemaining < maxBugs && bugsToSpawn > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                    bugs[7].SetActive(true);
                    bugsRemaining++;
                    bugsToSpawn--;
                }
            }
            if (bugsToSpawn <= 0)
            {
                bugsToSpawn = 2;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}