using System;
using UnityEngine;
using TMPro;

public enum ArrayType
{
    Int,
    Float
}

public class InputData : MonoBehaviour
{
    [SerializeField] private TMP_InputField _countField;
    [SerializeField] private TMP_InputField _valueField;
    [SerializeField] private ArrayTask _arrayTask;

    private ArrayType _state = ArrayType.Int;

    public void ChangeStateToFloat(bool isActive)
    {
        if (isActive)
            _state = ArrayType.Float;
    }

    public void ChangeStateToInt(bool isActive)
    {
        if (isActive)
            _state = ArrayType.Int;
    }

    public void StartArrayGenerating()
    {
        try
        {
            int count = int.Parse(_countField.text);
            if (_state == ArrayType.Int)
            {
                int value = int.Parse(_valueField.text);
                _arrayTask.CreateArray(value, count);
            }
            else if (_state == ArrayType.Float)
            {
                float value = float.Parse(_valueField.text);
                _arrayTask.CreateArray(value, count);
            }
            else
            {
                Debug.LogError("Uninitialized type");
            }
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
        
    }
}
