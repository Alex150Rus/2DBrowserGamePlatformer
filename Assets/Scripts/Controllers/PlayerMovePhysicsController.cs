using PlatformerMVC.Config;
using PlatformerMVC.Utilits;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC.Controllers
{
    public class PlayerMovePhysicsController
    {
        private float _xAxisInput;
        private bool _isJump;

        private float _walkSpeed = 150f;
        private float _animationSpeed = 10f;
        private float _movingThreshold = 0.1f;
        
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        
        private bool _isMoving;

        private float _jumpForce = 9f;
        private float _jumpThreshold = 1f;
        private float _g = -9.8f;
        private float _groundLevel = 0.5f;
        private float _yVelocity = 0f;
        private float _xVelocity = 0f;

        private LevelObjectView _view;
        private SpriteAnimatorController _spriteAnimator;
        private readonly ContactPoller _contactPoller;

        public PlayerMovePhysicsController(LevelObjectView player, SpriteAnimatorController animator)
        {
            _view = player;
            _spriteAnimator = animator;
            _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            _contactPoller = new ContactPoller(_view._collider);
        }

        private void MoveTowards()
        {
            _xVelocity = (_xAxisInput < 0 ? -1 : 1) * Time.fixedDeltaTime * _walkSpeed;
            _view._rigidbody.velocity = _view._rigidbody.velocity.Change(x: _xVelocity);
            _view.transform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
        }

        public void Update()
        {
            _spriteAnimator.Update();
            _contactPoller.Update();
            _xAxisInput = Input.GetAxis(NamesManager.INPUT_HORIZONTAL);
            _isJump = Input.GetAxis(NamesManager.INPUT_VERTICAL) > 0;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingThreshold;
            

            if (_isMoving)
            {
                MoveTowards();
            }

            if (_contactPoller.IsGrounded)
            {
               
                _spriteAnimator.StartAnimation(_view._spriteRenderer, _isMoving ? AnimState.Run : AnimState.Idle,
                    true, _animationSpeed);

                if (_isJump && Mathf.Abs(_view._rigidbody.velocity.y) <= _jumpThreshold)
                {
                    _view._rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_view._rigidbody.velocity.y) > _jumpThreshold)
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer,AnimState.Jump,true, _animationSpeed);
                }

               
            }
        }
    }
}