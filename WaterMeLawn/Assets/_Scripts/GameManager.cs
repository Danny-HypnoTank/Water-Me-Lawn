using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay Components")]
    public List <GameObject> Weeds;
    GrassBlock[] weedList;
    GameObject[] grassList;
    public static int numberOfWeeds;
    public static int numberOfFlowers = 0;
    public static bool gameOver = false;
    int maxFlowers;
    public bool wateringPhase;

    [Header("Coin Spawning")]
    [Range(0.0f,100.0f)]
    [SerializeField] public float randomCoinSpawner;
    [SerializeField] Vector3 playersPosition;
    [SerializeField] int coinsCollected;
    [SerializeField] TMP_Text[] coinsText;
    [SerializeField] GameObject coinPlacement;
    [Range(0.0f, 10.0f)]
    [SerializeField] public float coinSpawnTime;

    [Header("Player/Gameplay Canvas")]
    public static GameManager Instance;
    [SerializeField] Vector3 startingPosition;
    [SerializeField] GameObject GameplayCanvas;
    [SerializeField] Player player;
    [SerializeField] Slider ClearingSlider;
    [SerializeField] GameObject ClearingProgressBar;
    [SerializeField] Slider WaterSlider;
    [SerializeField] GameObject WaterProgressBar;

    [Header("End Screen Components")]
    public float secondsOnEnd;
    [SerializeField] GameObject wateringCan;
    [SerializeField] GameObject winnerCanvas;
    [SerializeField] GameObject endingCanvas;
    [SerializeField] GameObject gameplayCamera;
    [SerializeField] GameObject winCamera;
    [SerializeField] Animator ProtaginistDance;
    [SerializeField] Vector3 finishingPosition;
    [SerializeField] Quaternion finishingRotation;
    [SerializeField] TMP_Text winningText;
    int countCoins;
    bool countUpCoins = false;

    [Header("Debugging")]
    public bool endScreenDebugTrigger;
    public int coinsSpawnedInGame;
    
    /**
    public bool bugsActive;
    public GameObject bug;
    public float timer = 0;
    int seconds = 0;
    public static int bugsKilled = 0;
    [SerializeField] TextMeshProUGUI secondsUI;
    [SerializeField] TextMeshProUGUI bugKilledUI;
    **/

    void Awake()
    {
        weedList =  FindObjectsOfType<GrassBlock>();
        grassList = GameObject.FindGameObjectsWithTag("Grass");
        Weeds = new List<GameObject>();

        foreach(GrassBlock weed in weedList)
        {                        
            if(weed.HasWeeds==true)
            {
                Weeds.Add(weed.gameObject);
            }
        }

        foreach(GameObject grass in grassList)
        {                        
            Weeds.Add(grass);
        }

        numberOfWeeds = Weeds.Count;
        ClearingProgressBar.SetActive(true);
        ClearingSlider.maxValue = numberOfWeeds;
        ClearingSlider.value = numberOfWeeds;
        Debug.Log(numberOfWeeds);
        maxFlowers = weedList.Length;

        if (Instance == null)
        {
            Instance = this;
        }

        startingPosition = player.transform.position;        
    }

    void Update()
    {
        playersPosition = player.transform.position;
        coinsText[0].text = coinsCollected.ToString();

        if(countCoins<coinsCollected && countUpCoins)
            {
                countCoins++;
                winningText.text= "+ " + countCoins.ToString ();    // count up coin value on the end screen
            
            }

    }

    public void RemoveWeed(){

        numberOfWeeds = numberOfWeeds - 1;
//        Debug.Log(numberOfWeeds);
        ClearingSlider.value = numberOfWeeds - 1;
        StartCoroutine(spawnCoin());

        /*if(bugsActive==false)
        {
            StartCoroutine(SpawnBugs());
        }*/

        if(numberOfWeeds == 0 || endScreenDebugTrigger == true)
        {
            ClearingProgressBar.SetActive(false);
            WateringPhase();
        }
    }

    public void KillBugs()
    {
        numberOfWeeds = 0;
        numberOfFlowers = maxFlowers;

    }

    public void AddWeed()
    {
        numberOfWeeds = numberOfWeeds + 1;
        ClearingSlider.value = numberOfWeeds;
        if(numberOfFlowers>0)
        {
            numberOfFlowers = numberOfFlowers - 1;
            ClearingSlider.value = numberOfFlowers;
        }
    }

    /**
    IEnumerator SpawnBugs()
    {
        if(wateringPhase==false)
        {
            yield return new WaitForSeconds(10);
            int bugSpawnChoice = Random.Range (1,(Weeds.Count+1));
            if(wateringPhase==false)
            {
                GameObject newBug = Instantiate(bug);
                newBug.transform.position = Weeds[bugSpawnChoice].transform.position;
                //newBug.GetComponent<AIBugs>().FindBlock();
            }
        } 
    }
    **/

    void WateringPhase()
    {
        Debug.Log("water phase started");
        WaterProgressBar.SetActive(true);
        player.WateringPhase();
        wateringPhase = true;
    }

    public void AddFlower()
    {
        numberOfFlowers = numberOfFlowers + 1;
        WaterSlider.value = numberOfFlowers + 1;
        StartCoroutine(spawnCoin());
        if (numberOfFlowers == maxFlowers || endScreenDebugTrigger == true)
        {
            GameplayCanvas.SetActive(false);
            StartCoroutine(GameOverState());
        }
    }

    IEnumerator GameOverState()             //sets the end phase of the game with the player dancing and the end screen being displayed
    {
        wateringCan.SetActive(false);
        winnerCanvas.SetActive(true);
        yield return new WaitForSeconds(1);
        
        player.GetComponent <CharacterController>().enabled = false;
        player.transform.position = finishingPosition;
        player.transform.rotation = finishingRotation;
        gameplayCamera.SetActive(false);
        winCamera.SetActive(true);
        player.transform.position = finishingPosition;
        ProtaginistDance.SetBool("Victory1", true);
        //ProtaginistDance.SetBool("Victory2", true);
        //ProtaginistDance.SetBool("Victory3", true);
        yield return new WaitForSeconds(secondsOnEnd);
        winnerCanvas.SetActive(false);
        endingCanvas.SetActive(true);
        countUpCoins = true;
    }

    IEnumerator spawnCoin()
    {
        float val = Random.Range(0, 100);
        Vector3 coinSpawnPos = playersPosition;
        if (val <= randomCoinSpawner)
        {
            GameObject spawnedCoin = Instantiate(coinPlacement);
            spawnedCoin.transform.position = coinSpawnPos;
            yield return new WaitForSeconds(coinSpawnTime);
            BoxCollider coinCollider = spawnedCoin.GetComponent<BoxCollider>();
            spawnedCoin.SetActive(true);
            yield return new WaitForSeconds(0.45f);
            coinCollider.enabled = true;
            coinsSpawnedInGame++;
        }
    }

    public void CoinCounting()
    {
        coinsCollected = coinsCollected + 10;
    }
}

