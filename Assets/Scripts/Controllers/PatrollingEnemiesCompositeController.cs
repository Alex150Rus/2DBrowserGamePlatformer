using System.Collections.Generic;
using PlatformerMVC.Model;

namespace PlatformerMVC.Controllers
{
    public class PatrollingEnemiesCompositeController
    {
        private List<PatrollingEnemy> _patrollingEnemies;
        private List<SimplePatrolAIController> _simplePatrolAIControllers;
        
        public PatrollingEnemiesCompositeController(List<PatrollingEnemy> patrollingEnemies)
        {
            _patrollingEnemies = patrollingEnemies;
            Init();
        }

        private void Init()
        {
            _simplePatrolAIControllers = new List<SimplePatrolAIController>();
            for (int i = 0; i < _patrollingEnemies.Count; i++)
            {
                _simplePatrolAIControllers.Add(
                    new SimplePatrolAIController(_patrollingEnemies[i].patrollingEnemyView,
                        new SimplePatrolAIModel(_patrollingEnemies[i].confif)));
            }
        }

        public void FixedUpdate()
        {
            if(_simplePatrolAIControllers.Count > 0) {
                foreach (var aiController in _simplePatrolAIControllers)
                {
                    aiController.FixedUpdate();
                }
            }
        }
    }
}