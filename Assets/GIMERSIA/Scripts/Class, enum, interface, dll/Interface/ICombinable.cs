using UnityEngine;

public interface ICombinable
{
    bool CanCombine(ICombinable combinable);
    ICombinable CombineWith(ICombinable combinable);
}
