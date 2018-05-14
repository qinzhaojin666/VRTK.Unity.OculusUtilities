namespace VRTK.OculusUtilities.Tracking.Velocity
{
    using UnityEngine;
    using VRTK.Core.Tracking.Velocity;

    /// <summary>
    /// Retrieves the velocity and angular velocity from the specific named OVRCameraRig tracked anchor (CenterEyeAnchor, LeftHandAnchor, RightHandAnchor).
    /// </summary>
    public class VelocityEstimator : VelocityTracker
    {
        /// <summary>
        /// The <see cref="GameObject"/> anchor from the OVRCameraRig to track velocity for.
        /// </summary>
        [Tooltip("The GameObject anchor from the OVRCameraRig to track velocity for.")]
        public GameObject trackedGameObject;

        /// <inheritdoc />
        public override bool IsActive()
        {
            return (trackedGameObject != null && trackedGameObject.activeInHierarchy && isActiveAndEnabled);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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