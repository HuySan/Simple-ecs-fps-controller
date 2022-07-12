using UnityEngine;
using Leopotam.Ecs;
using Assets.Components;
namespace Assets.Systems
{
    //Cчитывает значения с мышки
     sealed class PlayerMouseInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<PlayerTag> _playerFilter = null;
        private readonly EcsFilter<PlayerTag, MouselookDirectionComponent> _mouseFilter = null;

        private float _axisX;
        private float _axisY;

        public float _minRotateDegrees;
        public float _maxRotateDegrees;

        public void Init()
        {
            foreach(var i in _playerFilter)
            {
                ref var entity = ref _playerFilter.GetEntity(i);
                ref var mouseLook = ref entity.Get<MouselookDirectionComponent>();

                _minRotateDegrees = mouseLook.minRotateDegrees;
                _maxRotateDegrees = mouseLook.maxRotateDegrees;
            }
        }

        public void Run()
        {
            foreach(var i in _mouseFilter)
            {
                GetAxis();
                ClampAxis();

                ref var lookComponent = ref _mouseFilter.Get2(i);

                lookComponent.direction.x = _axisX;
                lookComponent.direction.y = _axisY;
            }
        }

        private void GetAxis()
        {
            _axisX += Input.GetAxis("Mouse X");
            _axisY -= Input.GetAxis("Mouse Y");
        }

        private void ClampAxis()
        {
            //_axisX = Mathf.Clamp(_axisX, _minRotateDegrees, _maxRotateDegrees);
           _axisY = Mathf.Clamp(_axisY, _minRotateDegrees, _maxRotateDegrees);
        }
    }
}
