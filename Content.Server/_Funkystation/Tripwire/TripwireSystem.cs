using Content.Shared.StepTrigger.Systems;
using Content.Shared.Trigger.Systems;
using Content.Server.DeviceLinking.Systems;

namespace Content.Server._Funkystation.Tripwire;

public sealed partial class TripwireSystem : EntitySystem
{
    [Dependency] private TriggerSystem _trigger = default!;
    [Dependency] private DeviceLinkSystem _link = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TripwireComponent, ComponentInit>(OnInit);
        SubscribeLocalEvent<TripwireComponent, StepTriggeredOnEvent>(HandleStepOnTriggered);
    }

    private void OnInit(EntityUid uid, TripwireComponent component, ComponentInit args)
    {
        _link.EnsureSourcePorts(uid, component.Port);
    }

    private void HandleStepOnTriggered(EntityUid uid, TripwireComponent component, ref StepTriggeredOnEvent args)
    {
        _trigger.Trigger(uid, args.Tripper, TriggerSystem.DefaultTriggerKey);
    }
}
