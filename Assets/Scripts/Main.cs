using System;
using System.Collections.Generic;
using PlatformerMVC.Config;
using PlatformerMVC.Controllers;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _muzzleView;

        [SerializeField] private List<PatrollingEnemy> _patrollingEnemies;

        private SpriteAnimatorController _playerAnimator;
        private PlayerMovePhysicsController _playerMoveController;
        private MuzzleAimController _muzzleAimController;
        private CameraController _cameraController;
        private BulletEmitterController _bulletEmitterController;
        private PatrollingEnemiesCompositeController _patrollingEnemiesCompositeController;

        private void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerMoveController = new PlayerMovePhysicsController(_playerView, _playerAnimator);
            _muzzleAimController = new MuzzleAimController(_muzzleView, _playerView);
            _cameraController = new CameraController(_playerView.transform, Camera.main.transform);
            _bulletEmitterController = new BulletEmitterController(_muzzleView.bullets,_muzzleView.EmitterTransform);
            _patrollingEnemiesCompositeController = new PatrollingEnemiesCompositeController(_patrollingEnemies);
        }

        void Update()
        {
            _playerMoveController.Update();
            _muzzleAimController.Update();
            
            _cameraController.Update();
        }

        private void FixedUpdate()
        {
            _bulletEmitterController.Update();
            _patrollingEnemiesCompositeController.FixedUpdate();
        }

        [Serializable]
        public struct PatrollingEnemy
        {
            public AIConfig confif;
            public LevelObjectView patrollingEnemyView;
        }
    }
}