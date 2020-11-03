using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarriationTrigger : MonoBehaviour
{
    public List<string> text = new List<string>();
    public List<AudioClip> sources = new List<AudioClip>();

    public Narriation narriation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            narriation.PlayNarriation(text);
        }
    }
}
