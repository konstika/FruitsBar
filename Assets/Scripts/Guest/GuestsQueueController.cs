using UnityEngine;

public class GuestsQueueController : MonoBehaviour
{
    [SerializeField] private GameObject _guest;
    private GuestController _guestController;
    private Guest[] _queue;
    private int _currentGuestNumber = 0;

    void Start()
    {
        _queue = new Guest[]{ 
            new Guest(
                new string[]{"Hello, is this really fruit? Is it the result of some new genetic technology?", "I want a fruit... lemon"},
                new string[]{"Eerr? What is it?", "Apparently, the tastes used to be completely different...", ""},
                new string[] {"Wow, it's delicious", "Thank you",""},
                new Ingridient[]{ Ingridient.Lemon, Ingridient.Sugar },
                new Ingridient[]{Ingridient.Lemon, Ingridient.Sugar, Ingridient.Water, Ingridient.Ice }
            ),
            new Guest(
                new string[]{ "What an interesting place", "I've heard from some of my extremely ancient friends that there were less accessible tropical fruits", "By the way, those red fruits look unusual, almost tropical"},
                new string[]{ "Oh, to be honest, I feel disappointed", "I don't know where you came from, but I want to give you some advice as a successful businesswoman", "Catering to customers is an outdated strategy", "People appreciate the idea and the truth more",""},
                new string[] { "Wow, haha, I didn't choose the right color", "It's really a very harmonious drink. Tropical...", "I'll be back, and good luck with your business",""},
                new Ingridient[]{ Ingridient.Pineapple, Ingridient.Mango },
                new Ingridient[]{ Ingridient.Pineapple, Ingridient.Mango, Ingridient.Water, Ingridient.Ice, Ingridient.Lemon }
            ),
            new Guest(
                new string[]{ "Hi, I see they sell antiquities here", "I want to taste ancient blood, ancient blue blood"},
                new string[]{ "It doesn't look like blood", "Bye",""},
                new string[] { "It looks like blood", "It is interesting",""},
                new Ingridient[]{ Ingridient.Tomato, Ingridient.Salt },
                new Ingridient[]{ Ingridient.Tomato, Ingridient.Salt }
            ),
            new Guest(
                new string[]{ "Hi, I have a pet, and it's organic too. They say he looks like an ancient cat or dog", "But he's much more sensitive to food. It's hot, and he's very thirsty. Maybe organic food wouldn't hurt him?"},
                new string[]{ "I hope it doesn't hurt him",""},
                new string[] { "I hope it doesn't hurt him",""},
                new Ingridient[]{ Ingridient.Water },
                new Ingridient[]{ Ingridient.Water, Ingridient.Ice }
            )
        };
        _guestController = _guest.GetComponent<GuestController>();
        _guestController.OnGuestEscaped += ToNextGuest;
        ToNextGuest();
    }

    public void ToNextGuest() {
        if (_currentGuestNumber < _queue.Length)
        {
            _guestController.Guest = _queue[_currentGuestNumber];
            _currentGuestNumber++;
        }
    }
}
