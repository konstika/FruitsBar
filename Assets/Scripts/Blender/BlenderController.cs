using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BlenderController : MonoBehaviour
{
    private List<GameObject> _fruits = new List<GameObject>();
    [SerializeField] private Transform _fruitPoint;
    [SerializeField] private DrinkController _drinkController;

    public bool WithDrink() {
        return _drinkController.Drink is not null;
    }

    public bool WithFruits() { 
        return _fruits.Count > 0;
    }

    public void PutFruitInBlender(GameObject fruit) {
        _fruits.Add(fruit);
        fruit.transform.position = _fruitPoint.position;
    }

    public void MakeDrink() {
        List<Fruit> fruits = new List<Fruit>();
        foreach (GameObject fruit in _fruits) {
            fruits.Add(fruit.GetComponent<Fruit>());
            Destroy(fruit);
        }
        _drinkController.PourDrink(new Drink(fruits));
        _fruits.Clear();
    }

    public Drink GetDrink()
    {
        return _drinkController.Drink;
    }

    public Drink PourOutDrink() {
        Drink drink = _drinkController.Drink;
        _drinkController.ClearGlass();
        return drink;
    }
}
