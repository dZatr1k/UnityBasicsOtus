using System.IO;
using UnityEngine;

public class FileCreator : MonoBehaviour
{
    private void Awake()
    {
        DataTypes dataTypes = new DataTypes();
        File.WriteAllText(".\\Assets\\File.txt", dataTypes.ToString());
    }
}
