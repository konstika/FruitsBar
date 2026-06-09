using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Drink
{
    public string Name { get; private set; }
    public Color Color { get; private set; }

    private string _structureName = "";
    private List<Ingridient> _ingridients = new List<Ingridient>();
    private List<Ingridient> _noDrinkIngridients = new List<Ingridient>();

    public Drink()
    {
        Name = "water";
        _noDrinkIngridients.Add(Ingridient.Water);
        Color = new Color(1, 1, 1, 0.2f);
    }

    public Drink(List<Fruit> fruits)
    {
        for (int i = 0; i < fruits.Count; i++)
        {
            Fruit fruit = fruits[i];
            _ingridients.Add(fruit.FruitType);

            if (i == 0) { Color = fruit.Color; }
            else { Color = Color.Lerp(Color, fruit.Color, 1f / (i + 1)); }

            if (i == fruits.Count - 1) { _structureName += fruit.Name.Replace(" slices", ""); }
            else { _structureName += fruit.Name.Replace(" slices", "") + "-"; }
        }
        Name = _structureName + " drink";
    }

    public void AddNoDrinkIngridient(Ingridient idgridientType, string name) {
        _noDrinkIngridients.Add(idgridientType);
        if (!Name.Contains("with")) { Name += " with " + name; }
        else { Name += ", " + name; }

        if (idgridientType == Ingridient.Water) {
            Color = new Color(Color.r, Color.g, Color.b, 0.5f);
        }
    }
}

public enum Ingridient
{
    Lemon,
    Strawberry,
    Mango,
    Tomato,
    Pineapple,
    Salt,
    Sugar,
    Pepper,
    Ice,
    Water
}
