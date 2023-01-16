using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerMovementSystem))]
public sealed class PlayerMovementSystem : UpdateSystem {

    private Filter _playerFilter;

    public override void OnAwake() {
        _playerFilter = this.World.Filter.With<PlayerMovementComponent>().With<PlayerInputComponent>();
    }

    public override void OnUpdate(float deltaTime) {
        foreach (var entity in _playerFilter)
        {
            ref var playerMovementComponent = ref entity.GetComponent<PlayerMovementComponent>();
            var playerInputComponent = entity.GetComponent<PlayerInputComponent>();;
            playerMovementComponent.playerTransform.Translate(new Vector3(playerInputComponent.direction.x, 0, 
                playerInputComponent.direction.y) * deltaTime * playerMovementComponent.speedCoefficient);
        }
    }
}