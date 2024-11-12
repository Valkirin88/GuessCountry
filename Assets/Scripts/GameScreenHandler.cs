using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private Button _restartButton;
    [SerializeField]
    private GameObject _gameOverObject;
    [SerializeField]
    private GameObject _correctVersionObject;

    [SerializeField]
    private Image _flagImage;
    [SerializeField]
    private TMP_Text _resultText;
    [SerializeField]
    private TMP_Text _resultScoreGameOverScreen;
    [SerializeField]
    private TMP_Text _resultScoreMainScreenText;

    private int _rightButtonNumber;

    private int _attemptsNumber = 20;
    private int _currentsAttemptNumber;
    private int _rightAnswersNumber;

    private List<int> _countriesConfigsNumbers;

    [SerializeField]
    private List<TMP_Text> _buttonsTexts;

    private List<CountriesConfig> _countriesConfig;

    public void Initialize(List<CountriesConfig> countriesConfigs)
    {
        _countriesConfig = countriesConfigs;
        _countriesConfigsNumbers = new List<int>();
        _firstButton.onClick.AddListener(() => ChooseAnswer(0));
        _secondButton.onClick.AddListener(() => ChooseAnswer(1));
        _thirdButton.onClick.AddListener(() => ChooseAnswer(2));
        _fourthButton.onClick.AddListener(() => ChooseAnswer(3));
        _nextQuestionButton.onClick.AddListener(CreateNewQuestion);
        _restartButton.onClick.AddListener(Restart);
        CreateNewQuestion();
    }

    private void CreateNewQuestion()
    {
        if (_currentsAttemptNumber < _attemptsNumber)
        {
            _correctVersionObject.SetActive(false);
            _currentsAttemptNumber++;
            _resultText.text = null;
            var countryConfigNumber = CreateNewConfigNumber();
            _flagImage.sprite = _countriesConfig[countryConfigNumber].FlagSprite;
            _rightButtonNumber = UnityEngine.Random.Range(0, _buttons.Count);

            var text = _buttons[_rightButtonNumber].GetComponentInChildren<TMP_Text>();
            text.text = _countriesConfig[countryConfigNumber].Country.ToString();
            CrateOtherButtonsText();
            SetActiveButtons(true);
        }
        else
            ShowGameOver();
    }

    private int CreateNewConfigNumber()
    {
        var countryConfigNumber = UnityEngine.Random.Range(0, _countriesConfig.Count);
        while (_countriesConfigsNumbers.Contains(countryConfigNumber))
        {
            countryConfigNumber = UnityEngine.Random.Range(0, _countriesConfig.Count);
        }
        _countriesConfigsNumbers.Add(countryConfigNumber);
        return countryConfigNumber;
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
        var text = _countriesConfig[CreateNewConfigNumber()].Country.ToString();
        return text;
    }

    private void ChooseAnswer(int answerNumber)
    {
        if (answerNumber == _rightButtonNumber)
        {
            _resultText.text = "Правильно";
            _rightAnswersNumber++;
            _resultScoreMainScreenText.text = _rightAnswersNumber.ToString();
        }
        else
        {
            _resultText.text = "Неправильно";
        }
        SetActiveButtons(false);
        ShowCorrectVersion(_rightButtonNumber);
    }

    private void ShowCorrectVersion(int rightButtonNumber)
    {
        var pos = _buttons[_rightButtonNumber].transform.position;
        _correctVersionObject.transform.position = pos;  
        _correctVersionObject.SetActive(true);
    }

    private void SetActiveButtons(bool IsActive)
    {
        _firstButton.enabled = IsActive;
        _secondButton.enabled = IsActive;
        _thirdButton.enabled = IsActive;
        _fourthButton.enabled = IsActive;
    }

    private void ShowGameOver()
    {
        _gameOverObject.SetActive(true);
        Debug.Log(_resultScoreGameOverScreen);
        _resultScoreGameOverScreen.text = _rightAnswersNumber.ToString();
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        _firstButton.onClick.RemoveListener(() => ChooseAnswer(0));
        _secondButton.onClick.RemoveListener(() => ChooseAnswer(1));
        _thirdButton.onClick.RemoveListener(() => ChooseAnswer(2));
        _fourthButton.onClick.RemoveListener(() => ChooseAnswer(3));
        _nextQuestionButton.onClick.RemoveListener(CreateNewQuestion);
        _restartButton.onClick.RemoveListener(Restart);
    }

}
