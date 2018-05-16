namespace VRTK.OculusUtilities.Input
{
    /// <summary>
    /// Denotes containing a <see cref="OVRInput.Controller"/> Type.
    /// </summary>
    public interface IOculusInputControllable
    {
        OVRInput.Controller Controller { get; set; }
    }
}