using UnityEngine;

[System.Serializable]
public class ChefTask
{
    public IInteractable Target { get; private set; }
    public Sprite Icon { get; private set; }

    public ChefTask(IInteractable target, Sprite icon)
    {
        Target = target;
        Icon = icon;
    }
}
