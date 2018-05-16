﻿namespace VRTK.OculusUtilities.Input
{
    using UnityEngine;
    using VRTK.Core.Action;

    /// <summary>
    /// Listens for the specified near touch state and emits the appropriate action.
    /// </summary>
    public class OculusNearTouchAction : BooleanAction, IOculusInputControllable
    {
        /// <summary>
        /// The controller to listen for the state change on.
        /// </summary>
        [Tooltip("The controller to listen for the state change on.")]
        public OVRInput.Controller controller = OVRInput.Controller.Active;
        /// <summary>
        /// The near touch to listen for state changes on.
        /// </summary>
        [Tooltip("The near touch to listen for state changes on.")]
        public OVRInput.NearTouch nearTouch;

        /// <summary>
        /// The implementation of the interface to access the inherited <see cref="Controller"/> field.
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