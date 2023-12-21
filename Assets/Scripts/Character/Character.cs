using UnityEngine;
using StateMachine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterView))]
public class Character : MonoBehaviour, IDamagable
{
    public Rigidbody Rigidbody => _rigidbody;
    public CharacterView View => _view;
    public CharacterConfig Config => _config;
    public GroundChecker GroundChecker => _groundChecker;
    public WallChecker WallChecker => _wallChecker;
    public BoxChecker BoxChecker => _boxChecker;

    [SerializeField] private CharacterView _view;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private WallChecker _wallChecker;
    [SerializeField] private BoxChecker _boxChecker;
    [SerializeField] private CharacterConfig _config;

    [SerializeField] private Rigidbody _rigidbody;

    private CharacterStateMachine _stateMachine;
    private Vector3 _spawnPoint;


    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _view = GetComponent<CharacterView>();
    }

    private void Awake()
    {
        _view.Initialize();
        _rigidbody = _rigidbody != null ? _rigidbody: GetComponent<Rigidbody>();
        _view = _view != null ? _view : GetComponent<CharacterView>();

        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    public void Damage(float damage)
    {
        if (TryDamage(damage, out float maxPossibleDamage))
        {
            _stateMachine.Data.Health -= damage;
        }
        else 
        {
            _stateMachine.Data.Health -= maxPossibleDamage;
        }
    }

    private bool TryDamage(float damage, out float maxPossibleDamage) 
    {
        maxPossibleDamage = _stateMachine.Data.Health;
        return _stateMachine.Data.Health - damage >= 0;
    }

    internal void SetSpawnPoint(Vector3 spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void ResetCharacter() 
    {
        transform.position = _spawnPoint;
        _stateMachine.Data.Health = Config.CharacteristicsConfig.Health;
    }
}