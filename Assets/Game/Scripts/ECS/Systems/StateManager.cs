using Leopotam.Ecs;
using UnityEngine;

sealed class StateManager : IEcsInitSystem
{
    public static StateManager Instance { get; private set; }

    private EcsFilter<Player> _playerFilter;
    public void Init()
    {
        Instance = this;
    }

    public void SetIdleState()
    {
        ClearStates();
        _playerFilter.GetEntity(0).Get<IdleState>();
        _playerFilter.Get1(0).Data.Animator.SetTrigger("idle");
    }

    public void SetMoveState()
    {
        ClearStates();
        _playerFilter.GetEntity(0).Get<MoveState>();
        _playerFilter.Get1(0).Data.Animator.SetTrigger("walk");
    }

    void ClearStates()
    {
        ref var playerEntity = ref _playerFilter.GetEntity(0);

        if (playerEntity.Has<IdleState>())
        {
            playerEntity.Del<IdleState>();
        }

        if (playerEntity.Has<MoveState>())
        {
            playerEntity.Del<MoveState>();
        }
    }
}
