using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    #region Fields    
    public TextMeshProUGUI InputText;
    public Model model;
    public View view;    
    private string _input = "";
    private double _input1 = 0;
    private double _input2 = 0;
    private string _operator = "";
    private int _OpCount = 0;    
    #endregion Fields

    #region Methods
    public void OnNumClick(string num)
    {        
        Debug.Log($"number clicked: {num}");
        _input = view.UpdateView(num);
        Debug.Log(_input);        
    }

    public void OnPeriodClick(string val)
    {
        _input = view.UpdateView(val);
    }

    public void OnOperatorClick(string val)
    {
        if(_OpCount < 1)
        {
            Debug.Log(val);
            _input1 = double.Parse(_input);            
            view.Clear(); //clear Display
            _operator = val;
            _OpCount++;
        }
        else //account for multiple calculations between = press
        {
            view.Clear();
            Debug.Log("op pressed > 1");           
            _input2 = double.Parse(_input);            
            view.Clear();                        
            _input1 = double.Parse(model.Calculate(_input1, _input2, _operator));
            _operator = val;
            _OpCount++;
            view.Clear();
        }
    }

    public void OnPercentClick(string val)
    {
        Debug.Log($"percentage clicked");
        _input1 = double.Parse(_input);
        view.Clear();       
        _OpCount++;
        model.Calculate(_input1, _input2, val);
    }

    public void OnEqualClick()
    {               
        _input2 = double.Parse(_input);        
        view.Clear();
        Debug.Log($"1: {_input1} /2: {_input2} /3:{_operator} /4: {_OpCount}");                            
        _input1 = double.Parse(model.Calculate(_input1, _input2, _operator));    
    }

    public void OnAllClearClick()
    {
        _input = "";
        _input1 = 0;
        _input2 = 0;
        _operator = "";
        _OpCount = 0;
        view.Clear();
    }

    public void OnNegative()
    {
        _input = view.Negative();
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
    #endregion Methods
}
