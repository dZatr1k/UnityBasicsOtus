using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Scripts.Player;

public class InputReader : MonoBehaviour
{
    private readonly Dictionary<KeyCode, Vector3> _moveInputs = new Dictionary<KeyCode, Vector3>
    {
        {KeyCode.W, Vector3.forward },
        {KeyCode.A, Vector3.left },
        {KeyCode.S, Vector3.back },
        {KeyCode.D, Vector3.right }
    };

    [SerializeField] private Player _player;

    private List<KeyCode> _pressedKeys = new List<KeyCode>();

    private void Update()
    {
        CheckMouseButtonDown();
        
        ReadKeys();

        ProcessMoveKeys();


        _pressedKeys.Clear();
    }

    private void ReadKeys()
    {
        CheckKey(KeyCode.W);
        CheckKey(KeyCode.S);
        CheckKey(KeyCode.A);
        CheckKey(KeyCode.D);
    }

    private void CheckKey(KeyCode key)
    {
        if (Input.GetKey(key))
            _pressedKeys.Add(key);
    }

    private void CheckMouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _player.PlayAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _player.Die();
        }
    }

    private void ProcessMoveKeys()
    {
        Vector3 moveDirection = Vector3.zero;
        foreach (var key in _pressedKeys)
        {
            if (_moveInputs.ContainsKey(key))
            {
                moveDirection += _moveInputs[key];
            }
        }
        _player.Move(moveDirection);
    }
}
