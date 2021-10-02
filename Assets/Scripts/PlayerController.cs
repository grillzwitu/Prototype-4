using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb; //variable to reference access player's rigid body component
    public float speed; // variable for player's speed
    private GameObject focalPoint; //variable to reference and access the focal point
    public bool hasPowerUp; //variable to check if player has power up
    private float powerUpStrength = 15; //variable to for the strenght/magnitude of a power up
    public GameObject powerupIndicator; //variable for player's power up indicator

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // get/reference and access the player's rigid body component
        focalPoint = GameObject.Find("Focal Point"); // get/reference and access the focal point object
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical"); ///get  input from vertical input keys(w = forward, s = backward).
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput); //with vertical input, give motion(addForce) to player at speed, in the direction of the foacl point.
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    //When the player collides with a power up, triggering a collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power Up")) {
            hasPowerUp = true; //player has  power up
            Destroy(other.gameObject); //power up is destroyed from the scene
            powerupIndicator.gameObject.SetActive(true); //powerup indicator is active
            StartCoroutine(PowerupCountdownRoutine()); //power up life span counter is activated
        }
    }

    //when player collides with an enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>(); //get the rigidbody of the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);// direction to send enemy away to

            Debug.Log("Collided with " + collision.gameObject.name + " with power up set to " + hasPowerUp); //debud test collisions
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse); //send enemy away with force 
        }
    }

    //Method/Coroutine to manage validity of powerup
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); //count seven seconds
        hasPowerUp = false; //powerup expires/disabled
        powerupIndicator.gameObject.SetActive(false); // powerup indicator is inactive
    }
}
