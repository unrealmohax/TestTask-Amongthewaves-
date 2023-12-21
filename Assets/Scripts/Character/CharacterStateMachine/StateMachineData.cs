using System;

public class StateMachineData
{
    public StateMachineData(CharacterConfig config)
    {
        _health = config.CharacteristicsConfig.Health;
    }

    public float Health
    {
        get => _health;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _health = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }

    public float TimeLastJump { get; set; }
    public float TackleTime { get; set; }
    public float DashTime { get; set; }

    public float CurrentSpeed { get; set; }

    private float _health;
    private float _speed;
}