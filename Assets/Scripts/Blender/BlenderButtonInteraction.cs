using UnityEngine;

public class BlenderButtonInteraction : Interaction
{
    [SerializeField] private BlenderController _blenderController;
    [SerializeField] private string _tooltip = "Turn on the blender";
    protected override bool CheckAction()
    {
        return _blenderController.WithFruits();
    }

    protected override void ChooseMessage()
    {
        tooltipMessage = _tooltip;
    }

    protected override void TakeAction()
    {
        _blenderController.MakeDrink();
    }
}
