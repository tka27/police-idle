using Leopotam.Ecs;
using UnityEngine;

sealed class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<Player, MoveState> _playerFilter;

    void IEcsRunSystem.Run()
    {
        foreach (var playerIndex in _playerFilter)
        {
            ref var player = ref _playerFilter.Get1(playerIndex);


            Vector3 moveDirrection = new Vector3(UIData.Instance.Joystick.Horizontal, 0, UIData.Instance.Joystick.Vertical).normalized * player.MoveSpeed;

            player.Data.Controller.SimpleMove(moveDirrection);

            Vector3 velocity = new Vector3(player.Data.Controller.velocity.x, 0, player.Data.Controller.velocity.z);
            if (velocity.magnitude > 0)
            {
                player.Data.transform.rotation = Quaternion.LookRotation(-velocity.normalized);
            }


            if (!UIData.Instance.Joystick.IsTriggered())
            {
                StateManager.Instance.SetIdleState();
            }
        }
    }
}

