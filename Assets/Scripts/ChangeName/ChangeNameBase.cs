using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeNameBase : MonoBehaviour
{
    public TextMeshProUGUI TextPlayerName;
    public TMP_InputField InputPlayerName;
    public TextMeshProUGUI TextPlayerNameGame;
    public Player Player;

    public void ChangeName()
    {
        TextPlayerName.text = InputPlayerName.text;
        TextPlayerNameGame.text = InputPlayerName.text;
        Player.ChangeName(InputPlayerName.text);
    }
}
