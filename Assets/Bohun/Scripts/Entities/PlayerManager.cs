using System;
using UnityEngine;

public enum Character
{
    normal,
    health,
    speed
} 

public class PlayerManager : MonoBehaviour
{
    [SerializeField]private Character _currentChracter = Character.health;
    public Character CurrentCharacter {  get { return _currentChracter; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void ChangeCharacterRightButtonClick()
    {
        Character[] characterValues = (Character[])Enum.GetValues(typeof(Character));
        int currentIndex = Array.IndexOf(characterValues, _currentChracter);
        int nextIndex = (currentIndex + 1) % characterValues.Length;
        _currentChracter = characterValues[nextIndex];
    }
    public void ChangeCharacterLeftButtonClick()
    {
        Character[] characterValues = (Character[])Enum.GetValues(typeof(Character));
        int currentIndex = Array.IndexOf(characterValues, _currentChracter);
        int nextIndex = (currentIndex - 1) % characterValues.Length;
        if(nextIndex < 0)
        {
            nextIndex = characterValues.Length - 1;
        }
        _currentChracter = characterValues[nextIndex];
    }

}
