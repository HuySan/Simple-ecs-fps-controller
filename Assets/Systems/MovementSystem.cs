using UnityEngine;
using Leopotam.Ecs;
using Assets.Components;
namespace Assets.Systems
{
    //sealed - значит нельзя наследоваться от этого класса
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> _movableFilter = null;
        public void Run()//Аналог update
        {
            foreach(var i in _movableFilter)
            {
                ref var modelComponent = ref _movableFilter.Get1(i);
                ref var movableComponent = ref _movableFilter.Get2(i);
                ref var directionComponent = ref _movableFilter.Get3(i);

                ref var direction = ref directionComponent.direction;
                ref var transform = ref modelComponent.modelTransform;

                ref var characterController = ref movableComponent.characterController;
                ref var speed = ref movableComponent.speed;

                var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);

                //Сила притяжения(Перенести в отдельную систему GravitySystem)
                ref var velocity = ref movableComponent.velocity;
                velocity.y += Physics.gravity.y * Time.deltaTime;

                characterController.Move(rawDirection * speed * Time.deltaTime);
                characterController.Move(velocity * Time.deltaTime);
            }
        }
    }
}
