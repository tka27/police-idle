using Leopotam.Ecs;
using UnityEngine;


sealed class OfficeEcsStartup : MonoBehaviour
{
    private EcsWorld _officeWorld;
    private EcsSystems _systems;
    private EcsSystems _fixedSystems;

    void Start()
    {
        _officeWorld = new EcsWorld();
        _systems = new EcsSystems(_officeWorld);
        _fixedSystems = new EcsSystems(_officeWorld);

#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_officeWorld);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedSystems);
#endif
        _systems
        .Add(new StateManager())
        .Add(new PlayerInitSystem())



        .Init();



        _fixedSystems
        .Add(new PlayerIdleSystem())
        .Add(new PlayerMoveSystem())

        .Init();

    }

    private void Update()
    {
        _systems?.Run();
    }
    private void FixedUpdate()
    {
        _fixedSystems?.Run();
    }

    void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
            _officeWorld.Destroy();
            _officeWorld = null;
        }
    }
}
