using System;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private PlayerMover mover;
    [SerializeField] private Rigidbody2D rigidbody;

    private void Awake()
    {
        mover.Init(rigidbody);
        InitInput();
    }

    private void InitInput()
    {
        joystick.OnInput.AddListener(mover.AddDirection);
    }

    private void InputDisable()
    {
        joystick.OnInput.RemoveListener(mover.AddDirection);

    }

    private void OnDestroy()
    {
        InputDisable();
    }
}
