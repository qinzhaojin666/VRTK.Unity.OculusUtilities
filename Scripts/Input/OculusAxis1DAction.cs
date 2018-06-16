namespace VRTK.OculusUtilities.Input
{
    using UnityEngine;
    using VRTK.Core.Action;

    /// <summary>
    /// Listens for the specified axis and emits the appropriate action.
    /// </summary>
    public class OculusAxis1DAction : FloatAction, IOculusInputControllable
    {
        /// <summary>
        /// The controller to listen for the state change on.
        /// </summary>
        [Tooltip("The controller to listen for the state change on.")]
        public OVRInput.Controller controller = OVRInput.Controller.Active;
        /// <summary>
        /// The axis to listen for state changes on.
        /// </summary>
        [Tooltip("The axis to listen for state changes on.")]
        public OVRInput.Axis1D axis;

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
            Receive(OVRInput.Get(axis, controller));
        }
    }
}