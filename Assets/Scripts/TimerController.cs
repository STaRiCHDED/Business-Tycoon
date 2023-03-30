
using Models;
using Services;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private BusinessData _businessData;

    public void Initialize(BusinessData businessData)
    {
        _businessData = businessData;
    }

    private void Update()
    {
        if (_businessData.Level > 0)
        {
            UpdateSlider();
        }
    }

    private void UpdateSlider()
    {
        _slider.value += Time.deltaTime / _businessData.IncomeDelay;

        if (_slider.value >= _slider.maxValue)
        {
            _slider.value = _slider.minValue;
            UpdateIncome();
        }
    }

    private void UpdateIncome()
    {
        var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
        balanceService.Receive(_businessData.Income);
    }
}