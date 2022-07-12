using System;
using UnityEngine;

namespace Assets.Components
{
    [Serializable]
    public struct GroundCheckSphereComponent
    {
        [HideInInspector] public bool isGrounded;
        public Transform groundCheckSphere;
        public float groundDistance;
        public LayerMask groundMask;
    }
}
