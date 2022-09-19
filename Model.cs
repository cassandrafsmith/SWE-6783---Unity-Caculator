using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Model : MonoBehaviour
{
    #region Fields    
    public View view;
    public double _answer = 0;
    #endregion Fields    

    #region Methods
    public void test()
    {
        Debug.Log("This one works...."); //******************** remove
    }

    public string Calculate(double value1, double value2, string operat)
    {
        Debug.Log("in Calculate class!!");
        switch (operat)
        {
            case "+":
                _answer = value1 + value2;
                break;
            case "-":
                _answer = value1 - value2;
                break;
            case "*":
                _answer = value1 * value2;
                break;
            case "/":
                _answer = value1 / value2;                       
                break;
            case "%":
                _answer = value1 / 100; 
                break;            
        }
        view.UpdateView(_answer.ToString());        
        return _answer.ToString();        
    }
    #endregion Methods
}
