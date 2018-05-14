namespace VRTK.OculusUtilities.Input
{
    using UnityEngine;
    using VRTK.Core.Action;

    /// <summary>
    /// The OculusButtonAction listens for the specified button state and emits the appropriate action.
    /// </summary>
    public class OculusButtonAction : BooleanAction, IOculusInputControllable
    {
        [Tooltip("The controller to listen for the state change on.")]
        public OVRInput.Controller controller = OVRInput.Controller.Active;
        [Tooltip("The button to listen for state changes on.")]
        public OVRInput.Button button;

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
            Value = OVRInput.Get(button, controller);
            if (OVRInput.GetDown(button, controller))
            {
                OnActivated(true);
            }

            if (HasChanged())
            {
                OnChanged(Value);
            }

            if (OVRInput.GetUp(button, controller))
            {
                OnDeactivated(false);
            }
            previousValue = Value;
        }
    }
}