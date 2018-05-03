namespace VRTK.OculusUtilities.Tracking.Velocity
{
    using UnityEngine;
    using VRTK.Core.Tracking.Velocity;

    /// <summary>
    /// The VelocityEstimator retrieves the velocity and angular velocity from the specific named OVRCameraRig tracked anchor (CenterEyeAnchor, LeftHandAnchor, RightHandAnchor).
    /// </summary>
    public class VelocityEstimator : VelocityTracker
    {
        [Tooltip("The GameObject anchor from the OVRCameraRig to track velocity for.")]
        public GameObject trackedGameObject;

        /// <summary>
        /// The IsActive method returns the state of whether the component is active.
        /// </summary>
        /// <returns>Returns `true` if the component is considered active.</returns>
        public override bool IsActive()
        {
            return (trackedGameObject != null && trackedGameObject.activeInHierarchy && isActiveAndEnabled);
        }

        /// <summary>
        /// The GetVelocity method returns the velocity of the tracked object.
        /// </summary>
        /// <returns>A Vector3 of the current tracked velocity.</returns>
        public override Vector3 GetVelocity()
        {
            switch (trackedGameObject.name)
            {
                case "CenterEyeAnchor":
                    return (OVRManager.isHmdPresent ? OVRPlugin.GetNodeVelocity(OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render).FromFlippedZVector3f() : Vector3.zero);
                case "LeftHandAnchor":
                    return OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
                case "RightHandAnchor":
                    return OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            }
            return Vector3.zero;
        }

        /// <summary>
        /// The GetAngularVelocityMethod returns the angular velocity of the tracked object.
        /// </summary>
        /// <returns>A Vector3 of the current tracked angular velocity.</returns>
        public override Vector3 GetAngularVelocity()
        {
            switch (trackedGameObject.name)
            {
                case "CenterEyeAnchor":
                    return (OVRManager.isHmdPresent ? OVRPlugin.GetNodeAngularVelocity(OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render).FromFlippedZVector3f() : Vector3.zero);
                case "LeftHandAnchor":
                    return OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch);
                case "RightHandAnchor":
                    return OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
            }
            return Vector3.zero;
        }
    }
}