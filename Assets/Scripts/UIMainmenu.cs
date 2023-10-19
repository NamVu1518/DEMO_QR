using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIMainmenu : UICanvas
{
    [SerializeField] private TMP_InputField inputFieldLine;
    [SerializeField] private TMP_InputField inputFieldMachine;

    public void fillInputField(string[] arrStr)
    {
        inputFieldLine.text = arrStr[0];
        inputFieldMachine.text = arrStr[1];
    }
}
