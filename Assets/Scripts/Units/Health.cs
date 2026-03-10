using System;

public class Health
{
    private readonly int _minValue;
    private readonly int _maxValue;

    private int _value;

    public event Action Died;

    public Health()
    {
        _minValue = 0;
        _maxValue = 100;

        _value = _maxValue;
    }

    public bool TryGetDamage(int damage)
    {
        if (damage <= 0)
        {
            return false;
        }

        int newValue = _value - damage;

        if (newValue <= 0)
        {
            _value = 0;
            Died?.Invoke();
        }
        else
        {
            _value = newValue;
        }

        return true;
    }
}