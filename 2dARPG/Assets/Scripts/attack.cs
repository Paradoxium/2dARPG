using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Insantiates a collision volume infront of the actor. When a target enters the volume damage is dealt.
public class attack : MonoBehaviour
{
    public GameObject melee_AttackPattern; //this is the attack pattern prefab
    public GameObject ranged_AttackPattern;
    GameObject childObject; //this is the object that will be instatinated, could be different attack patterns.

    public GameObject attackStartLocation; //this is an empty gameobject that we will instantiate the attack pattern on top of.


    bool swing = true; //controls whether the player can attack.
    float cooldownTime; //controls the time between attacks.
    bool ranged = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the fire button is tapped and the 
        if(Input.GetButtonDown("Fire1") && swing){
            meleeAttack();
        }
        if(Input.GetButtonDown("Fire2") && swing)
        {
            rangedAttack();
        }
    }

    //this function handels all melee attacks
    void meleeAttack()
    {
        swing = false;
        childObject = Instantiate(melee_AttackPattern, attackStartLocation.transform, false) as GameObject; //insantiates the attackpattern
        childObject.transform.SetParent(attackStartLocation.transform); //sets the transform of the attackpattern
        StartCoroutine("rateOfMeleeAttack", 0.2f);
    }

    void rangedAttack()
    {
        swing = false;
        childObject = Instantiate(ranged_AttackPattern, attackStartLocation.transform, false) as GameObject; //insantiates the attackpattern
        childObject.transform.SetParent(attackStartLocation.transform); //sets the transform of the attackpattern
        StartCoroutine("rateOfFire", 0.2f);
    }


    //melee attack cooroutine distroys the swing after a set amount of time
    IEnumerator rateOfMeleeAttack(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        Destroy(childObject);
        swing = true;
    }

    //rate of Fire just controls how long between ranged weapon attacks
    IEnumerator rateOfFire(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        swing = true;
    }
}
