using UnityEngine;
using Leopotam.Ecs;
using Assets.Components;
namespace Assets.Systems
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        //Для системы управление нужен сам объект(находим по тегу) и направление движения
        //Эти данные добавляются в филтр для дальнейшей обработки
        //Это работает для всех систем
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;

        private float _moveX;
        private float _moveZ;
        public void Run()
        {
            Move();
            Jump();
        }

        private void Jump()
        {

        }

        private void Move()
        {
            SetDirection();

            //Обработка данных
            foreach (var i in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get2(i);
                ref var direction = ref directionComponent.direction;

                //При нажатии кнопок управления эти данные будут передаваться в систему движения
                //А та, в свою очередь добавит направление в свою модель движения, добавить там скорость transform.translate...
                direction.x = _moveX;
                direction.z = _moveZ;
            }
        }

        private void SetDirection()
        {
            _moveX = Input.GetAxis("Horizontal");
            _moveZ = Input.GetAxis("Vertical");
        }

    }
}
