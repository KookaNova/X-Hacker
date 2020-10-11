using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    public FloatData score;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = "" + score.value;
    }
}