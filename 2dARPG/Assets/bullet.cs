using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//The Bullet will move the ranged_AttackPattern forward at a specific speed.

public class bullet : MonoBehaviour
{

    float bulletSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    { 
 
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("fire");
    }

    public void move()
    {
       // transform.parent.parent.InverseTransformDirection(transform.forward);
        transform.Translate(Vector3.forward *bulletSpeed* Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit something");
        Destroy(gameObject);
    }

    IEnumerator fire()
    {
        move();
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
