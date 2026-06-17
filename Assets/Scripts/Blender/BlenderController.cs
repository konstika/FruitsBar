using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BlenderController : MonoBehaviour
{
    private List<GameObject> _fruits = new List<GameObject>();
    [SerializeField] private Transform _fruitPoint;
    [SerializeField] private DrinkController _drinkController;
    [SerializeField] private BlenderAnimationController _animationController;
    public bool Working { get;  private set; }

    private void Start()
    {
        Working = false;
        _animationController.OnStopWorkingBlender += StopWorking;
    }
    public bool WithDrink() {
        return _drinkController.Drink is not null;
    }

    public bool WithFruits() { 
        return _fruits.Count > 0;
    }

    public void PutFruitInBlender(GameObject fruit) {
        _fruits.Add(fruit);
        fruit.transform.position = _fruitPoint.position;
        fruit.GetComponent<FruitStateController>().GravityOn();
    }

    public void MakeDrink() {
        List<Fruit> fruits = new List<Fruit>();
        foreach (GameObject fruit in _fruits) {
            fruits.Add(fruit.GetComponent<Fruit>());
            Destroy(fruit);
        }
        _drinkController.PourDrink(new Drink(fruits), 0, false);
        _fruits.Clear();

        StartWorking();
    }

    public Drink GetDrink()
    {
        return _drinkController.Drink;
    }

    public Drink PourOutDrink() {
        Drink drink = _drinkController.Drink;
        _drinkController.ClearGlass();
        _animationController.AnimatePourOut();
        return drink;
    }

    private void StartWorking() {
        Working = true;
        _animationController.AnimateWorkBlender();
    }

    private void StopWorking()
    {
        Working = false;
        _drinkController.UpdateMaterialDrink(0.3f);
    }
}
