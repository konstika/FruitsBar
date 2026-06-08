using UnityEngine;

public class DrinkController : MonoBehaviour
{
    private Drink _drink = null;
    [SerializeField] private Renderer _drinkRender;

    public void PourDrink(Drink drink) { 
        _drink = drink;
        _drink.SetMaterial(_drinkRender);
    }
}
