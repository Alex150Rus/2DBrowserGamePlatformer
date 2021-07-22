using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC.Config
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2,
    }
    
    [CreateAssetMenu(fileName = "SpriteAnimationCfg", menuName = "Configs/ Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequences = new List<SpriteSequence>();
    }
}