using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarriationTest : MonoBehaviour
{
    public List<string> text = new List<string>();
    public List<AudioClip> sources = new List<AudioClip>();

    public Narriation narriation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //narriation.PlayNarriation(text, sources);
        }
    }
}
