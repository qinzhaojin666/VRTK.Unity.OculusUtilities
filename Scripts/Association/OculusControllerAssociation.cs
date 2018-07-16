namespace VRTK.OculusUtilities.Association
{
    using UnityEngine;
    using VRTK.Core.Association;

    /// <summary>
    /// Holds <see cref="GameObject"/>s to (de)activate based on a <see cref="OVRInput.Controller"/>.
    /// </summary>
    public class OculusControllerAssociation : BaseGameObjectsAssociation
    {
        /// <summary>
        /// The <see cref="OVRInput.Controller"/> that needs to be connected.
        /// </summary>
        [Tooltip("The OVRInput.Controller that needs to be connected.")]
        public OVRInput.Controller controller = OVRInput.Controller.None;

        /// <summary>
        /// Whether the <see cref="controller"/> needs to be active.
        /// </summary>
        [Tooltip("Whether the controller needs to be active.")]
        public bool needsToBeActive;

        /// <inheritdoc />
        public override bool ShouldBeActive()
        {
            return OVRInput.IsControllerConnected(controller)
                && ((OVRInput.GetActiveController() == controller) == needsToBeActive);
        }
    }
}