using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    /**
     * TODO:
     * done 1. Найти примеры полиморфизма в уже написанном коде и в том, что будет написан вами.
     * done 2. Реализовать удаление объектов из коллекции _spawnedObjects.
     * done 3. Заменить тип коллекции на более подходящий к данному случаю. Объяснить, если замена не требуется.
     */
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private int _totalAmount;

        [SerializeField]
        private float _spawnDelay;

        [SerializeField]
        private float _destroyDelay;

        [SerializeField]
        [Range(0f, 100f)]
        private float _destroyChance;

        [SerializeField]
        private List<GameObject> _objectsToSpawn;

        private readonly List<GameObject> _spawnedObjects = new List<GameObject>();


        void Start()
        {
            StartCoroutine(SpawnNext());
            StartCoroutine(DestroyNext());
        }

        private IEnumerator SpawnNext()
        {
            var random = new System.Random();
            int i;

            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);

                if (_spawnedObjects.Count < _totalAmount)
                {
                    random.SetRandomIndex(_objectsToSpawn.Count, out i);

                    var spawnedObject = Instantiate(_objectsToSpawn[i], transform);

                    _spawnedObjects.Add(spawnedObject);
                }
            }
        }

        private IEnumerator DestroyNext()
        {
            var random = new System.Random();
            int i;

            while (true)
            {
                yield return new WaitForSeconds(_destroyDelay);

                if (random.NextDouble() * 100 <= _destroyChance)
                {
                    random.SetRandomIndex(_spawnedObjects.Count, out i);
                    RemoveRandomSpawnedObject(i);
                }
            }
        }

        private void RemoveRandomSpawnedObject(int number)
        {
            if (_spawnedObjects.Count == 0)
                return;

            if (_spawnedObjects.Count <= number || number < 0)
            {
                Debug.LogError($"Invalied argument: spawned object count: {_spawnedObjects.Count}, input count: {number}");
                return;
            }

            var objectToRemove = _spawnedObjects[number];
            _spawnedObjects.RemoveAt(number);
            Destroy(objectToRemove);
        }
    }
}