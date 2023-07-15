using UnityEngine;

public class DataTypes : MonoBehaviour
{
    //Логический тип данных
    public bool boolData = true;

    //Целочисленные типы данных
    public byte byteData = 1;
    public sbyte sbyteData = 2;
    public short shortData = 3;
    public ushort ushortData = 4;
    public int intData = 5;
    public uint uintData = 6;
    public long longData = 7;
    public ulong ulongData = 8;
    public float floatData = 9.92f;
    public double doubleData = 10.123;
    public decimal decimalData = 11.21m;

    //Символный тип данных
    public char charData = (char)12;

    //Строковый тип данных
    public string stringData = "13 is terrible number";

    public int CastToInt(char symbol) => (int)symbol;
    public int CastToChar(ushort number) => (ushort)number;
    public int CastToInt(short number) => (int)number;
    public double CastToDouble(float number) => (double)number;
    public int CastToInt(float number) => (int)number;

    public void IncrementInt() {intData++;}
    public void IncrementFloat() {floatData++;}
    public void IncrementDouble() {doubleData++;}
    public void IncrementShort() {shortData++;}
    public void IncrementLong() {longData++;}

    public override string ToString()
    {
        return string.Format($"boolData - {boolData}\n" +
            $"byteData - {byteData}\n" +
            $"sbyteData - {sbyteData}\n" +
            $"shortData - {shortData}\n" +
            $"ushortData - {ushortData}\n" +
            $"intData - {intData}\n" +
            $"uintData - {uintData}\n" +
            $"longData - {longData}\n" +
            $"ulongData - {ulongData}\n" +
            $"floatData - {floatData}\n" +
            $"doubleData - {doubleData}\n" +
            $"decimalData - {decimalData}\n" +
            $"charData - {charData}\n" +
            $"stringData - {stringData}\n");
    }
}
