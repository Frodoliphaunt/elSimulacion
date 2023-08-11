using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;

public class AnimalMove : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticle;
    private GameManager gameManager;
    private AnimalMove setActive;
    public GameObject targetfood;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        setActive = GetComponent<AnimalMove>();
        setActive.enabled = true;
    }

    void FixedUpdate()
    {
        Pacing();
    }
    void Pacing()
    {       
        transform.Translate(Vector3.forward * Time.deltaTime * gameManager.speedSlider.value * 10f);
        transform.LookAt(targetfood.transform.position);        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(targetfood))
        {
            explosionParticle.Play();
        }
    }
}
