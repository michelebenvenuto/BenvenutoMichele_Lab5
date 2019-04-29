using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody rb;
    private int force = 20;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        //Adds a force
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(myRay, out hitInfo))
        {
            rb.AddForce(-hitInfo.normal*force, ForceMode.Impulse);
        }
        //Plays the sound
        if (audio) {
            audio.Play();
        }
    }
    private void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
