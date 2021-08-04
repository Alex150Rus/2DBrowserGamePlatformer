using System;
using UnityEngine;

namespace PlatformerMVC.Config
{
    [Serializable]
    public struct AIConfig
    {
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;

    }
}