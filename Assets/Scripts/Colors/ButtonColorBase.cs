using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorBase : MonoBehaviour
{
    public Color UnselectColor;

    public Color SelectColor;

    public Image UiImage;

    public static List<ButtonColorBase> ListOfButtons = new List<ButtonColorBase>();

    public bool IsSelected;

    public Player Player;

    private void OnValidate()
    {
        UiImage = gameObject.GetComponent<Image>();

        ListOfButtons.Add(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        UiImage.color = UnselectColor;
    }

    public void OnClick()
    {
        foreach (var item in ListOfButtons)
        {
            if (item.IsSelected)
            {
                if(item.transform.parent == gameObject.transform.parent)
                {
                    IsSelected = false;
                    item.UiImage.color = item.UnselectColor;
                }
            }
        }

        UiImage.color = SelectColor;
        IsSelected = true;

        Player.ChangeColor(SelectColor);
    }
}
