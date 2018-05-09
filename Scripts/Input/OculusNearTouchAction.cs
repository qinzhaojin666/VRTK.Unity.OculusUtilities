﻿namespace VRTK.OculusUtilities.Input
{
    using UnityEngine;
    using VRTK.Core.Action;

    /// <summary>
    /// The OculusNearTouchAction listens for the specified near touch state and emits the appropriate action.
    /// </summary>
    public class OculusNearTouchAction : BooleanAction, IOculusInputControllable
    {
        [Tooltip("The controller to listen for the state change on.")]
        public OVRInput.Controller controller = OVRInput.Controller.Active;
        [Tooltip("The near touch to listen for state changes on.")]
        public OVRInput.NearTouch nearTouch;

        /// <summary>
        /// Controller is the implementation of the interface to access the inherited `controller` field.
        /// </summary>
        public OVRInput.Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        protected virtual void Update()
        {
            Value = OVRInput.Get(nearTouch, controller);
            if (OVRInput.GetDown(nearTouch, controller))
            {
                OnActivated(true);
            }

            if (HasChanged())
            {
                OnChanged(Value);
            }

            if (OVRInput.GetUp(nearTouch, controller))
            {
                OnDeactivated(false);
            }
            previousValue = Value;
        }
    }
}