using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal _exitPoint;
    [SerializeField] private float _loadSpeed = 2;

    private List<Unit> _objectsToTeleport = new List<Unit>();

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out Unit unit))
        {
            _objectsToTeleport.Add(unit);
            StartCoroutine(TeleportUnit(unit));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out Unit unit))
        {
            _objectsToTeleport.Remove(unit);
        }
    }

    private IEnumerator TeleportUnit(Unit unit)
    {
        yield return new WaitForSeconds(_loadSpeed);

        if (_objectsToTeleport.Contains(unit))
        {
            unit.transform.position = _exitPoint.transform.position;
            _objectsToTeleport.Remove(unit);
        }
    }
}
