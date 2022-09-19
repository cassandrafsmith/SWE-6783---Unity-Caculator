using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class View : MonoBehaviour
{
    #region Fields
    public TextMeshProUGUI InputText;
    #endregion Fields

    #region Methods
    public string UpdateView(string input)
    {
        InputText.text += $"{input}";
        return InputText.text;
    }

    public string Negative()
    {        
        double num = double.Parse(InputText.text);        
        InputText.text = (num * -1).ToString();
        return InputText.text;
    }

    public void Clear()
    {
        InputText.text = "";
    }
    #endregion Methods
}
