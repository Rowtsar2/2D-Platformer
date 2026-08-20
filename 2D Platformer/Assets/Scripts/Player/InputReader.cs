using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    public event Action<float> Moved;
    public event Action<bool> Jumped;

    private void Update()
    {
        Moved?.Invoke(Input.GetAxisRaw(Horizontal));

        if (Input.GetButtonDown(Jump))
        {
            Jumped?.Invoke(true);
        }
        else if (Input.GetButtonUp(Jump))
        {
            Jumped?.Invoke(false);
        }
    }
}