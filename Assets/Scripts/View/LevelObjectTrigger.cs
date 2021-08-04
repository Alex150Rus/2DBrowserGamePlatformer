using System;
using UnityEngine;

namespace PlatformerMVC.View
{
    public class LevelObjectTrigger: MonoBehaviour
    {
        public event EventHandler<GameObject> TriggerEnter;
        public event EventHandler<GameObject> TriggerExit;

        #region Unity methods

        private void OnTriggerEnter2D(Collider2D other)
        {
            TriggerEnter?.Invoke(this, other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            TriggerExit?.Invoke(this, other.gameObject);
        }

        #endregion

    }
}