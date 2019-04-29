﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Text targetCounter;
    public AudioClip targetHit;
    private int hitTargets;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray aim = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hitInfo;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(aim, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("target"))
                {
                    hitTargets += 1;
                    targetCounter.text = hitTargets.ToString();
                    Destroy(hitInfo.collider.gameObject);
                    audioSource.PlayOneShot(targetHit);
                }
            }
        }
    }
}
