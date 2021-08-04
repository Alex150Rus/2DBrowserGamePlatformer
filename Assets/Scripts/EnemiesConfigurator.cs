using System;
using System.Collections.Generic;
using Pathfinding;
using PlatformerMVC.Config;
using PlatformerMVC.Controllers;
using PlatformerMVC.Interface;
using PlatformerMVC.Model;
using PlatformerMVC.Utilits;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC
{
    public class EnemiesConfigurator: MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private List<PatrollingEnemy> _patrollingEnemies;

        [Header("ProtectorAI")] [SerializeField]
        private List<ProtectingEnemies> _protectingEnemies;
        
        [SerializeField]
        public LevelObjectTrigger _protectedZoneTrigger;
        
        private PatrollingEnemiesCompositeController _patrollingEnemiesCompositeController;
        private ProtectorEnemiesCompositeController _protectorEnemiesCompositeController;
        private ProtectedZone _protectedZone;

        public void Init()
        {
            _patrollingEnemiesCompositeController = new PatrollingEnemiesCompositeController(_patrollingEnemies);
            _protectorEnemiesCompositeController = new ProtectorEnemiesCompositeController(_protectingEnemies);
            _protectedZone = new ProtectedZone(_protectedZoneTrigger, 
                _protectorEnemiesCompositeController.GetProtectors());
            _protectedZone.Init();

        }

        public void Run() {
            _patrollingEnemiesCompositeController.FixedUpdate();
        }

        public void Destroy()
        {
            _protectorEnemiesCompositeController.OnDestroy();
            _protectedZone.Deinit();
        }
    }
    
    [Serializable]
    public struct PatrollingEnemy
    {
        public AIConfig config;
        public LevelObjectView patrollingEnemyView;
    }
    
    [Serializable]
    public struct ProtectingEnemies {
        public LevelObjectView _protectorAIView;
        public AIDestinationSetter _protectorAIDestinationSetter;
        public AIPatrolPath _protectorAIPatrolPath;
        public Transform[] _protectorWaypoints;
    }
    
}