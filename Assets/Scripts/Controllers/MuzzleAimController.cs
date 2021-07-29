using PlatformerMVC.View;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace PlatformerMVC.Controllers
{
    public class MuzzleAimController
    {
        private CannonView _muzzle;
        private LevelObjectView _player;

        private Vector3 _dir;
        private float _angle;
        private Vector3 _axis;
        

        public MuzzleAimController(CannonView muzzle, LevelObjectView player)
        {
            _muzzle = muzzle;
            _player = player;
        }

        public void Update()
        {
            _dir = _player.transform.position - _muzzle.transform.position;
            _angle = Vector3.Angle(Vector3.down, _dir);
            _axis = Vector3.Cross(Vector3.down, _dir);
            _muzzle.transform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }
    }
}