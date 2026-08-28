using Content.Shared.DeviceLinking;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server._Funkystation.Tripwire;

[RegisterComponent, NetworkedComponent]
public sealed partial class TripwireComponent : Component
{
    /// <summary>
    ///     The port that gets signaled when the switch turns on.
    /// </summary>
    [DataField("port", customTypeSerializer: typeof(PrototypeIdSerializer<SourcePortPrototype>))]
    public string Port = "Pressed";

}
