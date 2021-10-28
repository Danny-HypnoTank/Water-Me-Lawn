using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask mask;        //layermask for raycast
    [SerializeField] GameObject cursor;
    [SerializeField] int lives;
    [SerializeField] Text livesText;

    bool errorCooldown = false;
    public Animator anim;
    Rigidbody body;
    [SerializeField] GameObject secondCam;

    bool playingGame = true;

    bool mobileInput = true;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] CharacterController controller;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject lawnMower;
    [SerializeField] GameObject wateringCan;
    [SerializeField] ParticleSystem lawnmowerParticle;
    Vector3 spawnPoint;

    [SerializeField] private GameObject comboTextOBJ;
    [SerializeField] private GameObject waterPopUpOBJ;
    [SerializeField] private TextMeshPro comboText;
    Animator comboTextAnim;
    [SerializeField] Animator UIAnimator;
    [SerializeField] TextMeshProUGUI complimentText;
    public static int comboCount;
    int popUpCount = 100;
    int counterPopUpcount = 5;
    string[] compliments = new string[] { "Beautiful!", "Lovely!", "Gorgeous!", "Pretty!", "Very Clean!", "Amazing!"};



    void Start(){
        //livesText.text = "Lives: " + lives.ToString();
        body = GetComponent<Rigidbody>(); 
        spawnPoint = transform.position;
        comboTextAnim = comboTextOBJ.GetComponent<Animator>();
    }


    void Update(){

        Vector2 Input = playerInput.actions["Move"].ReadValue<Vector2>();       //recieves joystick input
        Vector3 Move = new Vector3(Input.x,0,Input.y);
        controller.Move(Move*Time.deltaTime*moveSpeed);     //applies input to character controller

        if(controller.velocity.magnitude>0){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Move), 0.15F);    //aligns character rotation with player movement
        }
      

         if(Move == Vector3.zero){
        anim.SetBool("Run",false);      //run animation if moving
        }
        else anim.SetBool("Run",true);

        

    }

    void FixedUpdate(){
        if(comboCount>popUpCount){
            popUpCount = popUpCount + 100;
            UIAnimator.SetTrigger("TextPopUp");
            string randomString = compliments[Random.Range (0, compliments.Length)];
            complimentText.text = randomString;

        }

        if(comboCount>counterPopUpcount){
            
            counterPopUpcount = comboCount + 10;

            if(wateringCan.activeSelf == true){
                Instantiate (waterPopUpOBJ, new Vector3(transform.position.x,transform.position.y,transform.position.z + 1), transform.rotation);
            }

            else Instantiate (comboTextOBJ, new Vector3(transform.position.x,transform.position.y,transform.position.z + 1), transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other){

        /*if(other.gameObject.tag == "Furnishing" && errorCooldown == false){     // if player has walked over a red zone
            lives = lives - 1;
            livesText.text = "Lives: " + lives.ToString();
            errorCooldown = true;
            StartCoroutine(CooldownAfterError());
        }*/

        if(other.gameObject.tag == "MovementTile"){         
            Debug.Log("interacting with grass");
            if(other.GetComponent<GrassBlock>()){   //check if the block has weeds to be removed
                
                    
                other.GetComponent<GrassBlock>().TrimWeeds(lawnmowerParticle,comboTextAnim);
                Debug.Log(comboCount);
                
            }
            
        }

        if(other.gameObject.tag == "Bug"){         
            Destroy(other.gameObject);
            Debug.Log("destroy bug");
        }

        if(other.gameObject.tag == "Grass"){         
            other.GetComponent<IndividualGrass>().CutGrass(lawnmowerParticle);
            comboCount = comboCount + 1;
            GameManager.Instance.RemoveWeed();
            
        }        

        
        
    }



    IEnumerator CooldownAfterError(){
        yield return new WaitForSeconds(5);
        errorCooldown = false;      //cooldown to prevent lives being rapidly removed
    }

    public void WinGame(){
        playingGame = false;
            Camera.main.gameObject.SetActive(false);
            secondCam.SetActive(true);
            anim.SetTrigger("Victory");
            comboTextOBJ.SetActive(false);
    }

    public void WateringPhase(){
            lawnMower.SetActive(false);
            wateringCan.SetActive(true);
            anim.SetTrigger("Water");
    }
}
