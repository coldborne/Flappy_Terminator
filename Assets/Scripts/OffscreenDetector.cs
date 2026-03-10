using System;
using UnityEngine;

public class OffscreenDetector : MonoBehaviour
{
    private readonly float _minPositionValue = 0f;
    private readonly float _maxPositionValue = 1f;

    [SerializeField, Min(0.1f)] private float _delay = 3f;

    private Camera _camera;

    public event Action WentOffscreen;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_camera != null)
        {
            Vector3 viewPort = _camera.WorldToViewportPoint(transform.position);

            bool isOffscreen = viewPort.x < _minPositionValue ||
                               viewPort.x > _maxPositionValue ||
                               viewPort.y < _minPositionValue ||
                               viewPort.y > _maxPositionValue;

            if (isOffscreen)
            {
                WentOffscreen?.Invoke();
            }
        }
    }
}