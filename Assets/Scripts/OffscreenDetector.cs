using System;
using UnityEngine;

public class OffscreenDetector : MonoBehaviour
{
    private readonly float _minPositionValue = 0f;
    private readonly float _maxPositionValue = 1f;

    private Camera _camera;

    private bool _hasEnteredInViewPort;
    private bool _hasGoneOfViewPort;

    public event Action WentOffscreen;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_camera != null && _hasGoneOfViewPort == false)
        {
            bool isOffscreen = IsOffscreen();

            if (_hasEnteredInViewPort == false)
            {
                if (isOffscreen == false)
                {
                    _hasEnteredInViewPort = true;
                }
            }
            else
            {
                if (isOffscreen)
                {
                    WentOffscreen?.Invoke();
                    _hasGoneOfViewPort = true;
                }
            }
        }
    }

    private bool IsOffscreen()
    {
        Vector3 viewPort = _camera.WorldToViewportPoint(transform.position);

        return viewPort.x < _minPositionValue ||
               viewPort.x > _maxPositionValue ||
               viewPort.y < _minPositionValue ||
               viewPort.y > _maxPositionValue;
    }
}