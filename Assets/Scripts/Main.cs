using System;
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
        [SerializeField] private LevelObjectView _muzzleView;

        private SpriteAnimatorController _playerAnimator;
        private PlayerMovePhysicsController _playerMoveController;
        private MuzzleController _muzzleController;
        private CameraController _cameraController;

        private void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerMoveController = new PlayerMovePhysicsController(_playerView, _playerAnimator);
            _muzzleController = new MuzzleController(_muzzleView, _playerView);
            _cameraController = new CameraController(_playerView.transform, Camera.main.transform);
        }

        void Update()
        {
            _playerMoveController.Update();
            _muzzleController.Update();
            _cameraController.Update();
        }

        private void FixedUpdate()
        {
        }
    }
}