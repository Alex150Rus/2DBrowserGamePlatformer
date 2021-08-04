using System;
using PlatformerMVC.Model;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC.Controllers
{
    public class SimplePatrolAIController
    {
        
        private readonly LevelObjectView _view;
        private readonly SimplePatrolAIModel _model;

        public SimplePatrolAIController(LevelObjectView view, SimplePatrolAIModel model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view._transform.position) * Time.fixedDeltaTime;
            _view._rigidbody.velocity = newVelocity;
        }
    }
}