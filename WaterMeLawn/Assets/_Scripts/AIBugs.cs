using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBugs : MonoBehaviour
{
    
    [SerializeField] NavMeshAgent agent;
    [HideInInspector] public  GameManager manager;
    

    // Update is called once per frame

    /*public void FindBlock(){
        foreach(GameObject weed in GameManager.Instance.Weeds)
            {
                if(weed.HasWeeds==false){
                    agent.destination = weed.transform.position;
                    break;
                }
            }
    }
    


    void OnTriggerEnter(Collider other){
        if(other.tag == "MovementTile"){

            if(other.GetComponent<GrassBlock>()){
                    other.GetComponent<GrassBlock>().Revert();
                    Debug.Log("reverting Blocks");

                    foreach(GameObject weed in GameManager.Instance.Weeds)
                    {
                        if(weed.HasWeeds==false){
                            Debug.Log("find new Blocks");
                            agent.destination = weed.transform.position;
                            break;
                        }
                    }
            }
        }
    }*/

}
