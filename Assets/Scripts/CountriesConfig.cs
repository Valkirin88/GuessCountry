using UnityEngine;

[CreateAssetMenu(fileName = "Countries config", menuName = "ScriptableObjects/Country Config")]
public class CountriesConfig : ScriptableObject
{
    [SerializeField]
    private Sprite _flagSprite;
    [SerializeField]
    private CountriesNames _country;

    public Sprite FlagSprite  => _flagSprite; 
    public CountriesNames Country => _country; 
}
