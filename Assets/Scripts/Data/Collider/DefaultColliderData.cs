using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{   
    [Serializable]
    
    public class DefaultColliderData
    {
        [field: SerializeField] public float Height { get; private set; } = 1.6f;
        [field: SerializeField] public float CenterY { get; private set; } = 0.8f;
        [field: SerializeField] public float Radius { get; private set; } = 0.2f;
    }
}
