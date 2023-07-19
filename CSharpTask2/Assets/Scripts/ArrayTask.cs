using System;
using System.IO;
using System.Text;
using UnityEngine;

public struct TestArray<T>
{
    private T[] array;

    public void FillArray(T startValue, int count)
    {
        array = new T[count];
        array[0] = startValue;

        try
        {
            for (int i = 1; i < count; i++)
            {

                if (i % 3 == 0)
                {
                    array[i] = GenerateValue(array[i - 1]);
                }
                else if (i % 3 == 1)
                {
                    GenerateValue(out array[i], array[i - 1]);
                }
                else
                {
                    array[i] = array[i - 1];
                    GenerateValue(ref array[i]);
                }

            }
        }
        catch (OverflowException e)
        {
            Debug.LogError(e.Message);
        }
        catch
        {
            Debug.LogError("Other Exception.");
        }
    }

    private T GenerateValue(T value)
    {
        checked
        {
            return (dynamic)value * (dynamic)value;
        }
    }

    private void GenerateValue(out T newValue, T value)
    {
        checked
        {
            newValue = (dynamic)value * (dynamic)value;
        }
    }

    private void GenerateValue(ref T value)
    {
        checked
        {
            value = (dynamic)value * (dynamic)value;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < array.Length; i++)
        {
            result.Append(array[i].ToString());
            result.Append(" ");
        }

        return result.ToString();
    }
}
public class ArrayTask : MonoBehaviour
{
    public void CreateArray<T>(T startValue, int count)
    {
        TestArray<T> array = new TestArray<T>();
        array.FillArray(startValue, count);

        File.WriteAllText(".\\Assets\\File.txt", array.ToString());
    }
}
