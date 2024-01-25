using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    normal,
    health,
    speed
} 

public class PlayerManager : MonoBehaviour
{
   public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    }

    private Character currentCharacter;
    public Character CurrentCharacter {  get { return currentCharacter; } }

    public void ChangeCharacterRightButtonClick()
    {
        Character[] characterValues = (Character[])Enum.GetValues(typeof(Character));
        int currentIndex = Array.IndexOf(characterValues, currentCharacter);
        int nextIndex = (currentIndex + 1) % characterValues.Length;
        currentCharacter = characterValues[nextIndex];
    }
    public void ChangeCharacterLeftButtonClick()
    {
        Character[] characterValues = (Character[])Enum.GetValues(typeof(Character));
        int currentIndex = Array.IndexOf(characterValues, currentCharacter);
        int nextIndex = (currentIndex - 1) % characterValues.Length;
        currentCharacter = characterValues[nextIndex];
    }

}
