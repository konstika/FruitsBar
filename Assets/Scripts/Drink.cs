using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Drink
{
    public string Name { get; private set; }
    private string _structureName = "";
    private List<Ingridient> _ingridients = new List<Ingridient>();
    public Color Color { get; private set; }

    private Renderer _render;

    public Drink(List<Fruit> fruits, Renderer render, float filling = 0.8f)
    {
        for (int i = 0; i < fruits.Count; i++)
        {
            Fruit fruit = fruits[i];
            _ingridients.Add(fruit.FruitType);

            if (i == 0) { Color = fruit.Color; }
            else { Color = Color.Lerp(Color, fruit.Color, 1f / (i + 1)); }

            if (i == fruits.Count - 1) { _structureName += fruit.Name; }
            else { _structureName += fruit.Name + "-"; }
        }
        Name = _structureName + " drink";
        SetMaterial(render, filling);
    }

    public void SetMaterial(Renderer render, float filling = 0.8f) {
        _render = render;
        _render.material.SetColor("_ColorSide", Color);
        _render.material.SetColor("_ColorTop", Color.Lerp(Color, Color.black, 0.5f));
        _render.material.SetFloat("_Filling", filling); 
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
