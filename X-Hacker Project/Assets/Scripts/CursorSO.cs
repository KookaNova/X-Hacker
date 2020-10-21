using UnityEngine;

[CreateAssetMenu]
public class CursorSO : ScriptableObject
{
    public Texture2D handTexture, computerTexture, defaultTexture;

    public void DefaultCursor()
    {
        Cursor.SetCursor(defaultTexture, Vector2.zero, CursorMode.Auto);
    }
    
    public void HandCursor()
    {
        Cursor.SetCursor(handTexture, Vector2.zero, CursorMode.Auto);
    }

    public void ComputerCursor()
    {
        Cursor.SetCursor(computerTexture, Vector2.zero, CursorMode.Auto);
    }
}