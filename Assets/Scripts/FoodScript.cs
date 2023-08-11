using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject targetAnimal;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(targetAnimal))
        {
            gameObject.SetActive(false);
            transform.position = gameManager.GenerateSpawnPosition();
            gameObject.SetActive(true);            
        }
    }
}