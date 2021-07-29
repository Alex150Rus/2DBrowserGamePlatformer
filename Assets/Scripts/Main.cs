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
        private PlayerMoveController _playerMoveController;
        private MuzzleController _muzzleController;

        private void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerMoveController = new PlayerMoveController(_playerView, _playerAnimator);
            _muzzleController = new MuzzleController(_muzzleView, _playerView);
        }

        void Update()
        {
            _playerMoveController.Update();
            _muzzleController.Update();
        }

        private void FixedUpdate()
        {
        }
    }
}