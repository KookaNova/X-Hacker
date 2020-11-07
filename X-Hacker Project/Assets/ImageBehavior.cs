using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageBehavior : MonoBehaviour
{
    private Image image;
    public UnityEvent startEvent;
    
    public void OnEnable()
    {
        image = GetComponent<Image>();
        startEvent.Invoke();
    }

    public void ChangeColor(Color32 color)
    {
        image.color = color;
    }

    public void ChangeAlpha(float value)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, value);
    }
}