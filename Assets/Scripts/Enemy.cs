using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3; // variable fr enemy speed
    private Rigidbody enemyRb; // variable for the enemy rigid body
    private GameObject player; // variable for referencing the player game object
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); //get enemy rigid body component 
        player = GameObject.Find("Player"); //reference the player game object
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; // variable for the enemy's direction
        enemyRb.AddForce(lookDirection * speed);// give force to enemy to move towards player

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
