using System;
using UnityEngine;

public class GuestController : MonoBehaviour
{
    private Guest _guest;
    public Guest Guest {
        get { return _guest; }
        set {
            _guest = value;
            Order();
        }
    }
    private GameObject _drink;
    [SerializeField] private Transform _drinkPlace;
    [SerializeField] private GuestDialogController _guestDialogController;
    private AchievementManager _achievementManager = AchievementManager.Instance;
    public StateGuest State { get; private set; }
    public enum StateGuest
    {
        OrderDialog,
        WaitingOrder,
        EndDialog,
        Escaped
    }

    public event Action OnGuestEscaped;

    private void Start()
    {
        _guestDialogController.OnDialogEnd += EndDialog;
    }
    public void Order() {
        _guestDialogController.CreateDialog(Guest.OrderDialog);
        State = StateGuest.OrderDialog;
    }
    public void Wait() {
        State = StateGuest.WaitingOrder;
    }

    public void TakeDrink(GameObject drink) {
        _drink = drink;
        _drink.transform.position = _drinkPlace.position;
        State = StateGuest.EndDialog;
        if (Guest.CheckDrink(_drink.GetComponent<DrinkController>().Drink))
        {
            _guestDialogController.CreateDialog(Guest.RightOrderDialog);
            _achievementManager.SetAchievementState(Guest.Achievement, true);
        }
        else {
            _guestDialogController.CreateDialog(Guest.FailOrderDialog);
            _achievementManager.SetAchievementState(Guest.Achievement, true);
        }
    }
    public void Escape() {
        Destroy(_drink);
        _drink = null;
        State = StateGuest.Escaped;
        OnGuestEscaped.Invoke();
    }
    public void EndDialog() {
        if (State == StateGuest.OrderDialog) {
            Wait();
        } else if (State == StateGuest.EndDialog) {
            Escape();
        }
    }
}
