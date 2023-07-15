using System.IO;
using UnityEngine;

public class FileCreator : MonoBehaviour
{
    [SerializeField] private DataTypes _dataTypes;

    public void WriteData()
    {
        File.WriteAllText(".\\Assets\\File.txt", _dataTypes.ToString());
    }
}
