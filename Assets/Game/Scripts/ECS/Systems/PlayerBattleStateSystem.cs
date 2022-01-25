using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

sealed class PlayerBattleStateSystem : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
{
    private LayerMask _layer;
    private Camera _camera;
    private EcsFilter<Player, BattleState> _battlePlayerFilter;
    private EcsFilter<Enemy> _enemyFilter;

    public void Init()
    {
        _layer = LayerMask.GetMask("Hitable");
        _camera = Camera.main;

    }
    public void Destroy()
    {

    }

    public void Run()
    {
        if (_battlePlayerFilter.GetEntitiesCount() == 0 || !Input.GetMouseButtonDown(0)) return;
        RaycastHit hit;
        Ray mouseRay = _camera.ScreenPointToRay(Input.mousePosition);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(mouseRay, out hit, _layer))
        {
            ref var player = ref _battlePlayerFilter.Get1(0);

            player.Data.Weapon.Shoot(hit.point);
            player.Data.Animator.SetTrigger("shoot");
        }
    }



    /*bool EnemiesIsDead()
    {
        ref var player = ref _battlePlayerFilter.Get1(0);

        foreach (var enemyEntityIndex in _enemyFilter)
        {
            ref var enemy = ref _enemyFilter.Get1(enemyEntityIndex);
            float distanceToEnemy = (enemy.enemyData.transform.position - player.playerGO.transform.position).magnitude;

            if (enemy.enemyData.isAlive && distanceToEnemy < ENEMY_SCAN_RADIUS)
            {
                return false;
            }
        }
        return true;
    }*/

}
