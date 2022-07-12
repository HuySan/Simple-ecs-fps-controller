using Leopotam.Ecs;
using Assets.Components;
using Assets.Events;
using UnityEngine;
namespace Assets.Systems
{
    sealed class PlayerJumpSendEventSystem : IEcsRunSystem
    {
        //Реализация прыжка
        //Ивент на игрока добавляется автоматически
        private readonly EcsFilter<PlayerTag, JumpComponent> _playerFilter = null;
        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            foreach(var i in _playerFilter)
            {
                ref var entity = ref _playerFilter.GetEntity(i);
                entity.Get<JumpEvent>();
            }
        }
    }
}
