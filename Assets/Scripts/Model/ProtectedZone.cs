using System;
using System.Collections.Generic;
using PlatformerMVC.Interface;
using PlatformerMVC.Utilits;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC.Model
{
    public class ProtectedZone
    {
        private readonly List<IProtector> _protectors;
        private readonly LevelObjectTrigger _view;

        public ProtectedZone(LevelObjectTrigger view, List<IProtector> protectors)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _protectors = protectors != null ? protectors : throw new ArgumentNullException(nameof(protectors));;
        }
  
        public void Init()
        {
            _view.TriggerEnter += OnContact;
            _view.TriggerExit += OnExit;
        }

        public void Deinit()
        {
            _view.TriggerEnter -= OnContact;
            _view.TriggerExit -= OnExit;
        }
        
        private void OnContact(object sender, GameObject gameObject)
        {
            if(gameObject.CompareTag(NamesManager.PLAYER_TAG)) {
            foreach (var protector in _protectors)
                {
                    protector.StartProtection(gameObject);
                }       
            }
        }

        private void OnExit(object sender, GameObject gameObject)
        {
            if(gameObject.CompareTag(NamesManager.PLAYER_TAG)) {
            foreach (var protector in _protectors)
                {
                    protector.FinishProtection(gameObject);
                } 
            }
        }
    }
}