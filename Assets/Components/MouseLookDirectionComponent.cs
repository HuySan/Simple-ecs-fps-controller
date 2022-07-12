using Voody.UniLeo;
using System;
using UnityEngine;
namespace Assets.Components
{
    [Serializable]
    public struct MouselookDirectionComponent
    {
       [HideInInspector] public Vector3 direction;
       [Range(0, 7)] public float mouseSensitivity;
        public Transform cameraTransform;

        public float minRotateDegrees;
        public float maxRotateDegrees;
    }
}
