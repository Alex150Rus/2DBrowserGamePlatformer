using System;
using System.Collections.Generic;
using PlatformerMVC.Config;
using PlatformerMVC.Controllers;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC
{
    public class EnemiesConfigurator: MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private List<PatrollingEnemy> _patrollingEnemies;
        private PatrollingEnemiesCompositeController _patrollingEnemiesCompositeController;

        public void Init()
        {
            _patrollingEnemiesCompositeController = new PatrollingEnemiesCompositeController(_patrollingEnemies);
        }

        public void Run() {
            _patrollingEnemiesCompositeController.FixedUpdate();
        }    
    }
    
    [Serializable]
    public struct PatrollingEnemy
    {
        public AIConfig confif;
        public LevelObjectView patrollingEnemyView;
    }
    
}