using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> animalList = new();
    [SerializeField] List<GameObject> foodList = new();
    [SerializeField] GameObject food;
    [SerializeField] GameObject cow;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject canvasSlider;
    [SerializeField] Slider animalNumberSlider;
    public Slider speedSlider;
    private PlaneScale plane; 
    private AnimalMove animalMove;
    private float spawnRange;
    private FoodScript foodScript;
    void Start()
    {
        plane = GameObject.Find("Plane").GetComponent<PlaneScale>();
    }
    public Vector3 GenerateSpawnPosition()
    {
        float spawnposX = Random.Range(-spawnRange, spawnRange);
        float spawnposZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new(spawnposX, 0.2f, spawnposZ);
        return randomPos;
    }
    private void SetObjects()
    {
        for (int i = 0; i < animalNumberSlider.value; i++)
        {
            GameObject foodClone = Instantiate(food, GenerateSpawnPosition(), food.transform.rotation);
            foodList.Add(foodClone);
            foodList[i].name = "Food " + i;
            foodScript = foodList[i].GetComponent<FoodScript>();
            
            GameObject animalClone = Instantiate(cow, GenerateSpawnPosition(), cow.transform.rotation);
            animalList.Add(animalClone);
            animalList[i].name = "Animal " + i;
            animalMove = animalList[i].GetComponent<AnimalMove>();          
            animalMove.targetfood = foodList[i];
            foodScript.targetAnimal = animalList[i];
        }
    }
    public void StartGame()
    {
        titleScreen.SetActive(false);
        canvasSlider.SetActive(true);
        plane.Begin();
        spawnRange = plane.VerticeListToShow[0].x;
        SetObjects();      
    }
}

