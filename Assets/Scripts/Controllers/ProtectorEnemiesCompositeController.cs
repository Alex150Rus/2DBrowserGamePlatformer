using System.Collections.Generic;
using PlatformerMVC.Interface;
using PlatformerMVC.Model;

namespace PlatformerMVC.Controllers
{
    public class ProtectorEnemiesCompositeController
    {
        private List<ProtectingEnemies> _protectingEnemies;
        private List<IProtector> _protectors;

        public ProtectorEnemiesCompositeController(List<ProtectingEnemies> protectingEnemies)
        {
            _protectingEnemies = protectingEnemies;
            Init();
        }

        private void Init()
        {
            _protectors = new List<IProtector>();
            for (int i = 0; i < _protectingEnemies.Count; i++)
            {
                var protecorEnemy = _protectingEnemies[i];
                var protector = new ProtectorAIModel(
                    protecorEnemy._protectorAIView, new PatrolAIModel(protecorEnemy._protectorWaypoints), 
                    protecorEnemy._protectorAIDestinationSetter, protecorEnemy._protectorAIPatrolPath
                    );
                _protectors.Add(protector);
                protector.Init();
            }
        }

        public void OnDestroy()
        {
            for (int i = 0; i < _protectors.Count; i++)
            {
                if(_protectors[i] is ProtectorAIModel protector)
                    protector.Deinit();
            }
        }

        public List<IProtector> GetProtectors()
        {
            return _protectors;
        }
    }
}