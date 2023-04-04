using Models;
using Services;
using UnityEngine;
using UnityEngine.UI;

public class IncomeController : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private BusinessModel _businessModel;
    private float _currentBusinessLevel;

    public void Initialize(BusinessModel businessModel)
    {
        _businessModel = businessModel;
        _currentBusinessLevel = _businessModel.CurrentLevel;
    }

    private void Update()
    {
        if (_businessModel.CurrentLevel > 0)
        {
            UpdateSlider();
        }
    }

    private void UpdateSlider()
    {
        _slider.value += Time.deltaTime / _businessModel.IncomeDelay;

        if (_currentBusinessLevel < _businessModel.CurrentLevel)
        {
            _slider.value = _slider.minValue;
            _currentBusinessLevel = _businessModel.CurrentLevel;
        }
        if (_slider.value >= _slider.maxValue)
        {
            _slider.value = _slider.minValue;
            UpdateIncome();
        }
    }

    private void UpdateIncome()
    {
        var balanceService = ServiceLocator.Instance.GetSingle<IBalanceService>();
        balanceService.Receive(_businessModel.CurrentIncome);
    }
}