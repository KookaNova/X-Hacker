using UnityEngine;
using UnityEngine.UI;

public class ChangeFillUI : MonoBehaviour
{
    [Header("Fill Input")]
    [Tooltip("Data input for that determines the current fill. Input any Float Data")]
    public FloatDataSO inputFillReference;

    private Image _barFill;

    private float _startValue;

    private void Start()
    {
        _barFill = GetComponent<Image>();
        _barFill.color = new Color(.4f,.8f,.5f,1);
        _startValue = inputFillReference.value;
    }

    private void Update()
    {
        _barFill.fillAmount = inputFillReference.value / _startValue;

        if (_barFill.fillAmount <= 0.25f)
        {
            _barFill.color = new Color(1f,.35f,.3f,1);
        }
    }
}
