using UnityEngine;
using System;
namespace Assets.Components
{
    [Serializable]
    public struct DirectionComponent
    {
       [HideInInspector] public Vector3 direction;
    }
}
