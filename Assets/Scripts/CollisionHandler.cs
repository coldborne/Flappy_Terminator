using System;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionHandled;
    
    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            CollisionHandled?.Invoke(interactable);
        }
    }
}