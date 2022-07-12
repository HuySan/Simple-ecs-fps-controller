using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;
using Assets.Systems;
using Assets.Events;
namespace Assets
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld _world;//C������� ��� ������(�������,����������,����, �������)
        private EcsSystems _systems;//C������� ����� ������ ��� ������ ���� ������

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();//��� ������ uniLeo

            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems.Init();//������������ ���� ������

        }

        private void AddInjections()
        {

        }

//����� ������� �� �������� ������ ������        
        private void AddSystems()
        {
            _systems.
                Add(new JumpBlockSystem()).
                Add(new CursorLockSystems()).
                Add(new PlayerInputSystem()).
                Add(new GroundCheckSystem()).
                Add(new PlayerJumpSendEventSystem()).
                Add(new JumpSystem()).
                Add(new PlayerMouseInputSystem()).
                Add(new PlayerMouseLookSystem()).
                Add(new MovementSystem())
                ;
        }

        private void AddOneFrames()
        {
            //OneFrame ��������� ���������� ���� �������� ������ �����
            _systems.OneFrame<JumpEvent>();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null) return;
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }

}