using System;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType
{
    normal,
    health,
    speed
} 

public class PlayerManager : MonoBehaviour
{
    [SerializeField]private CharacterType _currentChracter = CharacterType.normal;
    public CharacterType CurrentCharacter {  get { return _currentChracter; } }

    public string PlayerName { get; set; }

    [SerializeField] private Image _characterImage;

    [SerializeField]private Color[] _color;
    private static PlayerManager _i;
    private void Awake()
    {
        if (_i == null)
        {
            _i = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeCharacterRightButtonClick()
    {
        CharacterType[] characterValues = (CharacterType[])Enum.GetValues(typeof(CharacterType));
        int currentIndex = Array.IndexOf(characterValues, _currentChracter);
        int nextIndex = (currentIndex + 1) % characterValues.Length;
        _currentChracter = characterValues[nextIndex];
        _characterImage.color = _color[(int)_currentChracter];
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
    }
    public void ChangeCharacterLeftButtonClick()
    {
        CharacterType[] characterValues = (CharacterType[])Enum.GetValues(typeof(CharacterType));
        int currentIndex = Array.IndexOf(characterValues, _currentChracter);
        int nextIndex = (currentIndex - 1) % characterValues.Length;
        if(nextIndex < 0)
        {
            nextIndex = characterValues.Length - 1;
        }
        _characterImage.color = _color[nextIndex];
        _currentChracter = characterValues[nextIndex];
        GameManager.I.AudioManager.SFXPlay(SFX.UI_SELECT);
    }

}
