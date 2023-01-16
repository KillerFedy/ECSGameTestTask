using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerInputSystem))]
public sealed class PlayerInputSystem : UpdateSystem {

    private Filter _playerInputSystemFilter;

    public override void OnAwake() {
        _playerInputSystemFilter = this.World.Filter.With<PlayerInputComponent>();
    }

    public override void OnUpdate(float deltaTime) {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");
        foreach (var entity in _playerInputSystemFilter)
        {
            ref var playerInputComponent = ref entity.GetComponent<PlayerInputComponent>();
            playerInputComponent.direction = new Vector2(dx, dy);
        }
    }
}