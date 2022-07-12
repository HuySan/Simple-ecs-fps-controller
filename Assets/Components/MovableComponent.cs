using UnityEngine;
using System;
namespace Assets.Components
{
    [Serializable]//Зачем?
    public struct MovableComponent//Нужен только для хранения ссылки на конттроллер и переменную скорости
    {
        public CharacterController characterController;
        public float speed;
        public Vector3 velocity;
        
    }
}
