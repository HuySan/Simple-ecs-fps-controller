using Leopotam.Ecs;
using UnityEngine;
namespace Assets.Systems
{
    sealed class JumpBlockSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockJumpDuration> _blockFilter = null;
        public void Run()
        {
            foreach(var i in _blockFilter)
            {
                ref var entity = ref _blockFilter.GetEntity(i);
                ref var block = ref _blockFilter.Get1(i);

                block.timer -= Time.deltaTime;
                if(block.timer <= 0)
                {
                    entity.Del<BlockJumpDuration>();
                }
            }
        }
    }
}
