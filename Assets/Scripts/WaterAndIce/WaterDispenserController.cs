using UnityEngine;

public class WaterDispenserController : DispenserController
{
    public override void AddIngridient()
    {
        DrinkController drinkController = item.GetComponent<DrinkController>();
        if (drinkController.IsEmpty())
        {
            drinkController.PourDrink(new Drink());
        }
        else {
            drinkController.AddIngridient(Ingridient.Water, "water");
        }
    }
}
