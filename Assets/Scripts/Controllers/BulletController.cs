using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC.Controllers
{
    public class BulletController
    {

        private Vector3 _velocity;
        public BulletView _view;
        
        public BulletController(BulletView bulletView)
        {
            _view = bulletView;
            Active(false);
            ActiveTrailRenderers(false);
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            Active(true);
            SetVelocity(velocity);
            _view._transform.position = position;
            _view._rigidbody.velocity = Vector2.zero;
            _view._rigidbody.angularVelocity = 0f;
            _view._rigidbody.AddForce(_velocity, ForceMode2D.Impulse);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _view.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public void Active(bool val)
        {
            _view.gameObject.SetActive(val);
        }

        public void ActiveTrailRenderers(bool val)
        {
            _view._trailRenderers.ForEach(tr => tr.emitting = val);
        }
    }
}