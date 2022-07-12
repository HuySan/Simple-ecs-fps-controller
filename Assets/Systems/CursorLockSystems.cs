using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Systems
{
    sealed class CursorLockSystems : IEcsInitSystem
    {
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
