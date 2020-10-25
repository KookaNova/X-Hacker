using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
   public GameObject textBox;
   public Animator textani;
   public TMP_Text Dialogtext;

   public void Dialog(string text)
   {
      textBox.SetActive(true);
      Dialogtext.text = text;
      textani.SetTrigger("pop");
   }

}
