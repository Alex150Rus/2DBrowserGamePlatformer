using UnityEngine;

namespace PlatformerMVC.Interface
{
    public interface IProtector
    {
        void StartProtection(GameObject invader);
        void FinishProtection(GameObject invader);

    }
}