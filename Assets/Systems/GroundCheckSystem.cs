using UnityEngine;
using Leopotam.Ecs;
using Assets.Components;

namespace Assets.Systems
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GroundCheckSphereComponent> _groundFilter = null;
        public void Run()
        {
            foreach(var i in _groundFilter)
            {
                ref var groundCheck = ref _groundFilter.Get1(i);

                groundCheck.isGrounded = Physics.CheckSphere(groundCheck.groundCheckSphere.position, groundCheck.groundDistance, groundCheck.groundMask);
            }
        }
    }
}
