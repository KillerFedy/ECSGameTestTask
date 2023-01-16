using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(PlayerInitializerSystem))]
public sealed class PlayerInitializerSystem : Initializer {

    [SerializeField] private float _playerMovementSpeed;
    [SerializeField] private float _speedCoefficient;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private Vector3 _initializePlayerPoint;

    public override void OnAwake() {
        var playerEntity = World.CreateEntity();
        playerEntity.AddComponent<PlayerMovementComponent>();
        playerEntity.AddComponent<PlayerInputComponent>();
        var playerGameObject = Instantiate(_playerGameObject, _initializePlayerPoint, _playerGameObject.transform.rotation);
        InitPlayerMovement(playerEntity, playerGameObject.transform);
    }

    private void InitPlayerMovement(Entity playerEntity, Transform playerTransform)
    {
        ref var playerMovementComponent = ref playerEntity.GetComponent<PlayerMovementComponent>();
        playerMovementComponent.movementSpeed = _playerMovementSpeed;
        playerMovementComponent.speedCoefficient = _speedCoefficient;
        playerMovementComponent.playerTransform = playerTransform;
    }
}