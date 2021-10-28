using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlock : MonoBehaviour
{
    public bool HasWeeds = false;
    [SerializeField] GameObject weeds1;
    [SerializeField] GameObject weeds2;
    [SerializeField] GameObject brokenWeed1;
    [SerializeField] GameObject brokenWeed2;
    [SerializeField] GameObject flowerBed;
    [SerializeField] GameObject flowerBed2;
    [SerializeField] GameObject grassObject;
    [SerializeField] GameObject weedObject;
    [SerializeField] GameObject weedObject2;
    [SerializeField] GameObject weedParticle;
    [SerializeField] ParticleSystem weedSpray;

    bool weedsRemoved = false;
    bool grassRemoved = false;

    bool reverted = true;
    bool watered = false;
    int numberChoice;
    int weedChoice;
    GameManager manager;

   

void Awake(){
    numberChoice = Random.Range (1,3);
    weedChoice = Random.Range (1,3);

    if(weedChoice==1){
        HasWeeds = true;
    }

    else if(weedChoice==2){
    HasWeeds = false;
    }

    

    if(numberChoice==1 && HasWeeds){
        weeds1.SetActive(true);
        grassObject.SetActive(true);
    }
    else if(numberChoice==2 && HasWeeds) 
    {
        
        weeds2.SetActive(true);
        grassObject.SetActive(true);
      
    }

    if(HasWeeds==false){
        grassObject.SetActive(true);
    }

        weedParticle.SetActive(false);
}


    public void TrimWeeds(ParticleSystem particle,Animator anim){

        
        
        if(HasWeeds && weedsRemoved == false){      //remove weed if available
            

            weedObject.GetComponent<MeshRenderer>().enabled = false;
            weedObject2.GetComponent<MeshRenderer>().enabled = false;
            
            particle.Play();
            anim.SetTrigger("Appear");
            
            HasWeeds = false;
            GameManager.Instance.RemoveWeed();
            weedParticle.SetActive(true);
            weedSpray.Play();
            weedsRemoved = true;
            reverted = false;

            if(numberChoice==1){
                brokenWeed1.SetActive(true);
            
            }
            else if(numberChoice==2){
              
            brokenWeed2.SetActive(true);
            }

            Player.comboCount = Player.comboCount + 1;
        }

        if(HasWeeds==false && grassRemoved == false){      //remove weed if available
            

            //grassObject.SetActive(false);
            
            grassRemoved = true;
            particle.Play();
            weedSpray.Play();
            Player.comboCount = Player.comboCount + 1;
        }

        if(GameManager.Instance.wateringPhase==true && watered == false){     //spawn flowers if weed is removed
            Debug.Log("watering flowers");
            anim.SetTrigger("Appear");
            Player.comboCount = Player.comboCount + 20;
            
            if(numberChoice==1){
                flowerBed.SetActive(true);
            }
            if(numberChoice==2){
                flowerBed2.SetActive(true);
            }
            GameManager.Instance.AddFlower();
            watered = true;
            

        }

        
        
    }

    public void Revert(){
    if(reverted==false){

        watered = false;
        weedsRemoved = false;
        HasWeeds = true;
        weeds1.SetActive(true);
            weeds2.SetActive(true);
            flowerBed.SetActive(false);
            flowerBed2.SetActive(false);
            GameManager.Instance.AddWeed();
            reverted = true;
    }

        
    }
}
