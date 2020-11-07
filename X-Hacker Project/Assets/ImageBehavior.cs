using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageBehavior : MonoBehaviour
{
    private Image image;
    private bool increaseFill;
    public float fillSpeed = 0;
    public UnityEvent startEvent, maxFillAmountEvent;
    
    public void OnEnable()
    {
        image = GetComponent<Image>();
        startEvent.Invoke();
    }

    private void Update()
    {
        if (image.fillAmount != 1 && increaseFill)
        {
            image.fillAmount += fillSpeed * Time.deltaTime;
        } 
        else if (image.fillAmount == 1)
        {
            maxFillAmountEvent.Invoke();
        }
    }

    public void ChangeColor(Color32 color)
    {
        image.color = color;
    }

    public void ChangeAlpha(float value)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, value);
    }

    public void StartFillBool(bool value)
    {
        increaseFill = value;
    }
}