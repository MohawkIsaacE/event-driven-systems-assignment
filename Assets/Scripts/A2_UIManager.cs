using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class A2_UIManager : MonoBehaviour
{
    public Character character;
    public TextMeshProUGUI currentColourText;

    private void Start()
    {
        currentColourText.text = $"Current Colour: {character.PlayerColour}";
    }

    public void UpdateColourUI()
    {
        currentColourText.text = $"Current Colour: {character.PlayerColour}";
    }
}
