using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    public FloatDataSO score;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = "" + score.value;
    }
}