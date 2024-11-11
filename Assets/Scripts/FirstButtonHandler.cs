using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstButtonHandler : MonoBehaviour
{
    public event Action<int> OnButtonPushed;

    [SerializeField]
    private Button _button;

    private int _buttonNumber = 1;

    public int ButtonNumber => _buttonNumber;

    private void Start()
    {
        _button.onClick.AddListener(PushButton);
    }

    private void PushButton()
    {
        OnButtonPushed?.Invoke(_buttonNumber);
    }
}
