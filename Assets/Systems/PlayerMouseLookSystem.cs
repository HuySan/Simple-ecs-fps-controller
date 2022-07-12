using System;
using UnityEngine;
using Leopotam.Ecs;
using Assets.Components;

namespace Assets.Systems
{
    //Вращает камеру игрока и задаёт напарвление движения
    sealed class PlayerMouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag> _playerFilter = null;
        private readonly EcsFilter<PlayerTag, ModelComponent, MouselookDirectionComponent> _mouseLookFilter = null;

        private Quaternion _startTransformRotation;

        public void Init()//Аналог Start()
        {
            foreach(var i in _playerFilter)
            {
                ref var entity = ref _playerFilter.GetEntity(i);
                ref var model = ref entity.Get<ModelComponent>();

                _startTransformRotation = model.modelTransform.rotation;
            }

            //Таким образом без цикла можем получить нужный компонент, т.к. игрок один
            //_startTransformRotation = _mouseLookFilter.GetEntity(0).Get<ModelComponent>().modelTransform.rotation;
        }

        public void Run()
        {
            foreach (var i in _mouseLookFilter)
            {
                ref var model = ref _mouseLookFilter.Get2(i);
                ref var lookComponent = ref _mouseLookFilter.Get3(i);

                var axisX = lookComponent.direction.x;
                var axisY = lookComponent.direction.y;

                var rotateX = Quaternion.AngleAxis(axisX, Vector3.up * Time.deltaTime * lookComponent.mouseSensitivity);
                var rotateY = Quaternion.AngleAxis(axisY, Vector3.right * Time.deltaTime * lookComponent.mouseSensitivity);

                model.modelTransform.rotation = _startTransformRotation * rotateX;
                lookComponent.cameraTransform.rotation = model.modelTransform.rotation * rotateY;
            }
        }
    }
}
