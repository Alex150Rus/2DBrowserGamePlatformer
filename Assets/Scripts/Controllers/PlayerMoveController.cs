using PlatformerMVC.Config;
using PlatformerMVC.Utilits;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC.Controllers
{
    public class PlayerMoveController
    {
        private float _xAxisInput;
        private bool _isJump;

        private float _walkSpeed = 3f;
        private float _animationSpeed = 10f;
        private float _movingThreshold = 0.1f;
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private bool _isMoving;

        private float _jumpSpeed = 9f;
        private float _jumpThreshold = 1f;
        private float _g = -9.8f;
        private float _groundLevel = 0.5f;
        private float _yVelocity = 0f;

        private LevelObjectView _view;
        private SpriteAnimatorController _spriteAnimator;

        public PlayerMoveController(LevelObjectView player, SpriteAnimatorController animator)
        {
            _view = player;
            _spriteAnimator = animator;
            _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Run, true, _animationSpeed);
        }

        private void MoveTowards()
        {
            _view.transform.position += Vector3.right * Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
            _view.transform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }
        
        public void Update()
        {
            _spriteAnimator.Update();
            _xAxisInput = Input.GetAxis(NamesManager.INPUT_HORIZONTAL);
            _isJump = Input.GetAxis(NamesManager.INPUT_VERTICAL) > 0;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingThreshold;
            
            if (_isMoving)
            {
                MoveTowards();
            }
        }
    }
}