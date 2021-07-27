using UnityEngine;

namespace PlatformerMVC.Controllers
{
    public class CameraController
    {
        private float _x;
        private float _y;

        private float _offsetY = 1.5f;
        private float _offsetX = 1.5f;

        private int _camSpeed = 150;

        private Transform _playerTransform;
        private Transform _cameraTransform;
        
        public CameraController(Transform player, Transform camera)
        {
            _playerTransform = player;
            _cameraTransform = camera;
        }
        
        public void Update()
        {
            _x = _playerTransform.position.x;
            _y = _playerTransform.position.y;

            _cameraTransform.position = Vector3.Lerp(
                _cameraTransform.position, 
                new Vector3(_x + _offsetX, _y + _offsetY, _cameraTransform.position.z),
                Time.deltaTime * _camSpeed
                );
        }
    }
}