using UnityEngine;

[CreateAssetMenu]
public class MiniGameBase : ScriptableObject
{
    /*
        All Mini-Games must inherit from this script
        These functions must be used in every Mini-Game
        
        -Brandon
    */
    public virtual void StartMiniGame()
    {
        
    }

    public virtual void CloseMiniGame()
    {
        
    }

    public virtual void Objective()
    {
        
    }

    public virtual void Success()
    {
        
    }

    public virtual void Difficulty()
    {
        
    }
}