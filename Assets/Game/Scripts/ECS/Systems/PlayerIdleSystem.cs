using Leopotam.Ecs;

sealed class PlayerIdleSystem : IEcsRunSystem
{
    private EcsFilter<Player, IdleState> _playerFilter;

    void IEcsRunSystem.Run()
    {
        foreach (var playerIndex in _playerFilter)
        {
            if (UIData.Instance.Joystick.IsTriggered())
            {
                StateManager.Instance.SetMoveState();
            }
        }
    }
}

