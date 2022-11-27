using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CharacterCustomization : MonoBehaviour
{
    public Renderer rend;

    private Dictionary<string, string> colors =
        new Dictionary<string, string>()
        {
            {"Black", "#1A1A1A"},
            {"Green", "27D491" },
            {"Blue", "#4C3CE7" },
            {"Yellow", "FFFF00" }

        };

    private int faceColorID;
    private int bodyColorID;

    [SerializeField] private TextMeshProUGUI faceColorText;
    [SerializeField] private TextMeshProUGUI bodyColorText;


    public void SelectFaceColor(bool isForward)
    {
        if (isForward)
        {
            if(faceColorID == colors.Count - 1)
            {
                faceColorID = 0;
            }
            else
            {
                faceColorID++;
            }
        }
        else
        {
            if(faceColorID == 0)
            {
                faceColorID = colors.Count - 1;
            }
            else
            {
                faceColorID--;
            }
        }
        SetItem("faceColor");
    }

    public void SelectBodyColor(bool isForward)
    {
        if (isForward)
        {
            if (bodyColorID == colors.Count - 1)
            {
                bodyColorID = 0;
            }
            else
            {
                bodyColorID++;
            }
        }
        else
        {
            if (bodyColorID == 0)
            {
                bodyColorID = colors.Count - 1;
            }
            else
            {
                bodyColorID--;
            }
        }
        SetItem("bodyColor");
    }

    private void SetItem(string type)
    {
        switch (type)
        {
            case "faceColor":
                string faceColorName = colors.Keys.ElementAt(faceColorID);
                faceColorText.text = faceColorName.ToLower();
                if(ColorUtility.TryParseHtmlString(colors.Values.ElementAt(faceColorID), out Color faceColor))
                {
                    rend.materials[0].SetColor("_BaseColor", faceColor);
                }
                break;
            case "bodyColor":
                break;
        }
    }
}
