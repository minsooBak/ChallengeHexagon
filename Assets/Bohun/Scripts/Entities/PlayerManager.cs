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
    private static PlayerManager _instance = null;
   public static PlayerManager Instance
    {
        get
        {
            if(null == _instance)
            {
                return null;
            }
            else
            {
                return _instance;
            }
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]private Character _currentChracter = Character.health;
    public Character CurrentCharacter {  get { return _currentChracter; } }


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
