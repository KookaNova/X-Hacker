using UnityEngine;

[CreateAssetMenu]
public abstract class MiniGameBase : ScriptableObject
{
    /*
        All Mini-Games must inherit from this script
        These functions must be used in every Mini-Game
        
        -Brandon
    */
    
    //Function should be called to start the mini-game. Think of it as Start() but you have to call it
    public abstract void StartMiniGame();

    public abstract void Success();

    public abstract void Difficulty();

    public abstract void ResetMiniGame();
}