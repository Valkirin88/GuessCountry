using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenHandler : MonoBehaviour
{
    [SerializeField]
    private Button _firstButton;
    [SerializeField]
    private Button _secondButton;
    [SerializeField]
    private Button _thirdButton;
    [SerializeField]
    private Button _fourthButton;
    [SerializeField]
    private List<Button> _buttons;
    [SerializeField]
    private Button _nextQuestionButton;

    [SerializeField]
    private Image _flagImage;
    [SerializeField]
    private TMP_Text _resultText;

    private int _rightButtonNumber;
    private int _countryConfigNumber;

    [SerializeField]
    private List<TMP_Text> _buttonsTexts;

    private List<CountriesConfig> _countriesConfig;

    public void Initialize(List<CountriesConfig> countriesConfigs)
    {
        _countriesConfig = countriesConfigs;
        _firstButton.onClick.AddListener(() => ChooseAnswer(0));
        _secondButton.onClick.AddListener(() => ChooseAnswer(1));
        _thirdButton.onClick.AddListener(() => ChooseAnswer(2));
        _fourthButton.onClick.AddListener(() => ChooseAnswer(3));
        _nextQuestionButton.onClick.AddListener(CreateNewQuestion);
        CreateNewQuestion();
    }

    private void CreateNewQuestion()
    {
        _resultText.text = null;
        _countryConfigNumber = UnityEngine.Random.Range(0, _countriesConfig.Count);
        _flagImage.sprite = _countriesConfig[_countryConfigNumber].FlagSprite;
        _rightButtonNumber = UnityEngine.Random.Range(0, _buttons.Count);

        var text = _buttons[_rightButtonNumber].GetComponentInChildren<TMP_Text>();
        text.text = _countriesConfig[_countryConfigNumber].Country.ToString();
        CrateOtherButtonsText();
    }

    private void CrateOtherButtonsText()
    {
        foreach (var button in _buttons) 
        {
            if(button != _buttons[_rightButtonNumber]) 
            {
                Debug.Log("GetNewCountry");
                var text = button.GetComponentInChildren<TMP_Text>();
                text.text = GetNewCountryText();
            }
        }
    }

    private String GetNewCountryText()
    {
        var text = _countriesConfig[UnityEngine.Random.Range(0, _countriesConfig.Count)].Country.ToString();
        return text;
    }

    private void ChooseAnswer(int answerNumber)
    {
        if (answerNumber == _rightButtonNumber)
        {
            _resultText.text = "Правильно";
        }
        else
            _resultText.text = "Неправильно";
    }
    
}
