using UnityEngine;

namespace Jolt
{
    /// Enum used in BodyCreationSettings to indicate how mass and inertia should be calculated
    public enum OverrideMassProperties : uint
    {
        /// Tells the system to calculate the mass and inertia based on density
        CalculateMassAndInertia = 0,
        /// Tells the system to take the mass from mMassPropertiesOverride and to calculate the inertia based on density of the shapes and to scale it to the provided mass
        CalculateInertia,
        /// Tells the system to take the mass and inertia from mMassPropertiesOverride
        MassAndInertiaProvided,
    }
}