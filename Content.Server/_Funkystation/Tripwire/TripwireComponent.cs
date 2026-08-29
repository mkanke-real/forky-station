using Content.Shared.DeviceLinking;

namespace Content.Server._Funkystation.Tripwire;

[RegisterComponent]
public sealed partial class TripwireComponent : Component
{
    /// <summary>
    ///     The port that gets signaled when the switch turns on.
    /// </summary>
    [DataField]
    public ProtoId<SourcePortPrototype> Port = "Pressed";

}
