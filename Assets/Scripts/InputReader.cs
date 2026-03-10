using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpKeyPressed;
    public event Action ShootKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpKeyPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
    }
}
