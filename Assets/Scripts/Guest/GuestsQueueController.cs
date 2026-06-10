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
                new string[]{"Hello!", "Are that really 'Fruits' in your bar?", "I thought they were lost long time ago, when humanity entered the era of cyberspace...", "I want to try some of that... like lemon"},
                new string[]{"Ew? What's that?", "I wonder if way back tastes used to be completely different...", ""},
                new string[] { "Wow, it's delicious! Thank you!",""},
                new Ingridient[]{ Ingridient.Lemon, Ingridient.Sugar },
                new Ingridient[]{Ingridient.Lemon, Ingridient.Sugar, Ingridient.Water, Ingridient.Ice }
            ),

            new Guest(
                new string[]{ "What an interesting place", "I've heard from some of my rusty old friends that there used to be more inaccessible tropical fruits and from which very tasty cocktails were made ", "By the way, this round red fruit looks unusual, almost tropical"},
                new string[]{ "To be honest, I feel disappointed.", "I don't know where are you from, but I want to give you some advice as a successful businesswoman", "Catering to customers is an outdated strategy", "People appreciate the idea and the truth more",""},
                new string[] { "Wow, haha, I didn't choose the right color", "It's really a very harmonious blend of flavours. Tropical...", "One day I will return. Good luck with your business!",""},
                new Ingridient[]{ Ingridient.Pineapple, Ingridient.Mango },
                new Ingridient[]{ Ingridient.Pineapple, Ingridient.Mango, Ingridient.Water, Ingridient.Ice }
            ),

            new Guest(
                new string[]{ "Hi, I see they sell antiquities here", "I want to taste ancient blood, ancient blue blood!"},
                new string[]{ "It doesn't seems like blood", "Bye",""},
                new string[]{ "It seems like blood", "Interesting...",""},
                new Ingridient[]{ Ingridient.Tomato, Ingridient.Salt },
                new Ingridient[]{ Ingridient.Tomato, Ingridient.Salt }
            ),

            new Guest(
                new string[]{ "Hi, I have a pet, and it's organic too. My parents said that it's like ancient pets — you know, cats, dogs, that kind of thing.", "But he's much more sensitive to food. It's very hot today, and he's very thirsty. Maybe some organic drink wouldn't hurt?"},
                new string[]{ "I hope it doesn't hurt him",""},
                new string[] { "I hope it doesn't hurt him",""},
                new Ingridient[]{ Ingridient.Water },
                new Ingridient[]{ Ingridient.Water, Ingridient.Ice }
            ),
            new Guest(
                new string[]{ "And here we have another strange cafe!","Look at all this weird things on shelves, that they call 'Fruits'!","I wonder if these are just cheap, nasty substitutes like they feed us in all those other places.","Hey, you here! Make me a drink with that little red whatever-it-is.", "I bet it will be as sour, bittery and burning spicy as everywhere.", ""},
                new string[]{ "I knew that would happen! And they actually have the nerve to serve this crap to customers.", ""},
                new string[] { "Wow, now this is a pleasant drink — never had one like it. Not like in those other bars.", "Thanks!",""},
                new Ingridient[]{ Ingridient.Strawberry},
                new Ingridient[]{ Ingridient.Water, Ingridient.Ice, Ingridient.Strawberry, Ingridient.Sugar }
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
