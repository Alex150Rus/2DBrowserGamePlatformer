using PlatformerMVC.View;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace PlatformerMVC.Controllers
{
    public class MuzzleController
    {
        private CannonView _muzzle;
        private LevelObjectView _player;

        public MuzzleController(CannonView muzzle, LevelObjectView player)
        {
            _muzzle = muzzle;
            _player = player;
        }

        public void Update()
        {
            var dir = _player.transform.position - _muzzle.transform.position;
            var angle = Vector3.Angle(Vector3.down, dir);
            var axis = Vector3.Cross(Vector3.down, dir);
            _muzzle.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
}