using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private List<CountriesConfig> _countriesConfig;

    [SerializeField]
    private GameScreenHandler _gameScreenHandler;

    private void Awake()
    {
        _gameScreenHandler.Initialize(_countriesConfig);
    }
}
