using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC.View
{
    public class CannonView : MonoBehaviour
    {
        public Transform muzzleTransform;
        public Transform EmitterTransform;
        public List<LevelObjectView> bullets;
    }
}