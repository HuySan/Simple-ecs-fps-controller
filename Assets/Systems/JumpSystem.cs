using Leopotam.Ecs;
using Assets.Events;
using Assets.Components;
using UnityEngine;

namespace Assets.Systems
{
    sealed class JumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GroundCheckSphereComponent, JumpComponent, JumpEvent>.
        Exclude<BlockJumpDuration> _jumpFilter = null;//Исключим блок из поиска филтров, чтобы игрок не смог выполнить прыжок, когда стоит таймер
        public void Run()
        {
            foreach(var i in _jumpFilter)
            {
                ref var entity = ref _jumpFilter.GetEntity(i);
                ref var groundCheck = ref _jumpFilter.Get2(i);
                ref var jumpComponent = ref _jumpFilter.Get3(i);
                ref var movable = ref entity.Get<MovableComponent>();
                ref var velocity = ref movable.velocity;

                if (!groundCheck.isGrounded) continue;
                //прыжок
                Debug.Log("Прыжок");
                velocity.y = Mathf.Sqrt(jumpComponent.force * -2f * Physics.gravity.y);
                entity.Get<BlockJumpDuration>().timer = 3f;//накидываем блок на прыжок
            }
        }
    }
}
