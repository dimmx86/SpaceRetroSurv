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
        joystick.OnEndInput.AddListener(mover.StopForce);
        joystick.OnBeginInput.AddListener(mover.StartForce);
    }

    private void InputDisable()
    {
        joystick.OnInput.RemoveListener(mover.AddDirection);
        joystick.OnEndInput.RemoveListener(mover.StopForce);
        joystick.OnBeginInput.RemoveListener(mover.StartForce);

    }

    private void OnDestroy()
    {
        InputDisable();
    }
}
