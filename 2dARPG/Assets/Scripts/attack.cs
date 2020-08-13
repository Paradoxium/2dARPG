using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Insantiates a collision volume infront of the actor. When a target enters the volume damage is dealt.
public class attack : MonoBehaviour
{
    public GameObject attackPattern; //this is the attack pattern prefab
    GameObject childObject; //this is the object that will be instatinated, could be different attack patterns.

    public GameObject attackStartLocation; //this is an empty gameobject that we will instantiate the attack pattern on top of.

    bool swing = true; //controls whether the player can attack.
    float cooldownTime; //controls the time between attacks.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the fire button is tapped and the 
        if(Input.GetButtonDown("Fire1") && swing){
            swing = false;
            childObject = Instantiate(attackPattern, attackStartLocation.transform,false) as GameObject; //insantiates the attackpattern
           // childObject.transform.SetParent(attackStartLocation.transform); //sets the transform of the attackpattern
            
            Debug.Log("FIRE");
            StartCoroutine("rateOfAttack", 0.2f);

        }
    }



    IEnumerator rateOfAttack(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        Destroy(childObject);
        swing = true;
        
    }

}
