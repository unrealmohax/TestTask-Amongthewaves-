using Assets.Character.Configs;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private AirborneStateConfig _airborneStateConfig;
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private SlideWallStateConfig _slideWallStateConfig;
    [SerializeField] private TackleStateConfig _tackleStateConfig;
    [SerializeField] private JumpingOnWallStateConfig _jumpingOnWallStateConfig;
    [SerializeField] private HardLandingStateConfig _hardLandingStateConfig;
    [SerializeField] private DashStateConfig _dashStateConfig;
    [SerializeField] private CharacteristicsConfig _characteristicsConfig;
    [SerializeField] private PushingStateConfig _pushingStateConfig;
    
    internal CharacteristicsConfig CharacteristicsConfig => _characteristicsConfig;
    internal AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    internal RunningStateConfig RunningStateConfig => _runningStateConfig;
    internal WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    internal SlideWallStateConfig SlideWallStateConfig => _slideWallStateConfig;
    internal TackleStateConfig TackleStateConfig => _tackleStateConfig;
    internal JumpingOnWallStateConfig JumpingOnWallStateConfig => _jumpingOnWallStateConfig;
    internal HardLandingStateConfig HardLandingStateConfig => _hardLandingStateConfig;
    internal DashStateConfig DashStateConfig => _dashStateConfig;
    internal PushingStateConfig PushingStateConfig => _pushingStateConfig;
}