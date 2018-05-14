namespace VRTK.OculusUtilities.Input
{
    using UnityEngine;
    using VRTK.Core.Action;

    /// <summary>
    /// The OculusAxis1DAction listens for the specified axis and emits the appropriate action.
    /// </summary>
    public class OculusAxis1DAction : FloatAction, IOculusInputControllable
    {
        [Tooltip("The controller to listen for the state change on.")]
        public OVRInput.Controller controller = OVRInput.Controller.Active;
        [Tooltip("The axis to listen for state changes on.")]
        public OVRInput.Axis1D axis;

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
            Value = OVRInput.Get(axis, controller);
            EmitEvents();
            State = IsActive();
            previousValue = Value;
        }
    }
}