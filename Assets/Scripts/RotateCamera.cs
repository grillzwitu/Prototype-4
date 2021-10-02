using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public float rotationSpeed = 30; // variable to control rotation speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizantalInput = Input.GetAxis("Horizontal"); //get  input from horizontal input keys(a = left, d = right)
        transform.Rotate(Vector3.up, horizantalInput * rotationSpeed * Time.deltaTime); // with horizontal input, rotate along the y-axis at rotation speed
    }
}
