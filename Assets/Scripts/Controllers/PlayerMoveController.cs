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
            _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
        }

        private void MoveTowards()
        {
            _view.transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _view.transform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }

        public bool IsGrounded()
        {
            return _view.transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
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

            if (IsGrounded())
            {
               
                _spriteAnimator.StartAnimation(_view._spriteRenderer, _isMoving ? AnimState.Run : AnimState.Idle,
                    true, _animationSpeed);

                if (_isJump && _yVelocity <= 0)
                {
                    _yVelocity = _jumpSpeed;
                }
                else if(_yVelocity < 0)
                {
                    _yVelocity = float.Epsilon;
                    _view.transform.position = _view.transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity) > _jumpThreshold)
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer,AnimState.Jump,true, _animationSpeed);
                }

                _yVelocity += _g * Time.deltaTime;
                _view.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }
    }
}