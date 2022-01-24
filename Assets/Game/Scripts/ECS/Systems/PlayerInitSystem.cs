using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld _officeWorld;
    public void Init()
    {
        var playerEntity = _officeWorld.NewEntity();

        ref var player = ref playerEntity.Get<Player>();
        player.Data = LevelData.Instance.Player.GetComponent<PlayerData>();
        player.MoveSpeed = 3;

        StateManager.Instance.SetIdleState();
    }
}

