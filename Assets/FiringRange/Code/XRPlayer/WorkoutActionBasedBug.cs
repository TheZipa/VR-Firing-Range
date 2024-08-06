using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Management;

namespace FiringRange.Code.XRPlayer
{
    public class WorkoutActionBasedBug : MonoBehaviour
    {
        [SerializeField] private ActionBasedController[] _actionBasedControllers;
        private IEnumerator _waitForXRSystemRoutine;

        private void OnEnable()
        {
            bool isXRSystemActive = IsXRSystemActive();
            
            if (isXRSystemActive)
            {
                EnableActionBased();
            }
            else
            {
                foreach (ActionBasedController actionBasedController in _actionBasedControllers)
                    actionBasedController.enabled = false;
                if (_waitForXRSystemRoutine != null) return;
                _waitForXRSystemRoutine = WaitForXRSystem(EnableActionBased);
                StartCoroutine(_waitForXRSystemRoutine);
            }
        }

        private void EnableActionBased()
        {
            foreach (ActionBasedController actionBasedController in _actionBasedControllers)
                actionBasedController.enabled = true;
        }

        private bool IsXRSystemActive()
        {
            if (XRGeneralSettings.Instance == null || XRGeneralSettings.Instance.Manager == null)
                return false;
            return XRGeneralSettings.Instance.Manager.isInitializationComplete;
        }

        IEnumerator WaitForXRSystem(Action onInitComplete)
        {
            while (XRGeneralSettings.Instance == null || XRGeneralSettings.Instance.Manager == null)
            {
                yield return null;
            }
            while (!XRGeneralSettings.Instance.Manager.isInitializationComplete)
            {
                yield return null;
            }
            
            onInitComplete?.Invoke();
        }
    }
}