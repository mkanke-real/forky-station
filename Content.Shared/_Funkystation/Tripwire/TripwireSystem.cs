using Content.Shared.Armable;
using Content.Shared.Item.ItemToggle.Components;
using Content.Shared.StepTrigger.Systems;
using Content.Shared.Trigger.Systems;
using Content.Server.DeviceLinking.Components;

namespace Content.Shared._Funkystation.Tripwire;

public sealed partial class TripwireSystem : EntitySystem
{
    [Dependency] private TriggerSystem _trigger = default!;
    [Dependency] private DeviceLinkSystem _link = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<TripwireComponent, ComponentInit>(OnInit);
        SubscribeLocalEvent<TripwireComponent, StepTriggeredOnEvent>(StepTriggerAttemptEvent);
    }

    private void OnInit(EntityUid uid, TripwireComponent component, ComponentInit args)
    {
        _link.EnsureSourcePorts(uid, component.Port);
    }

    private void

    private void HandleStepTriggerAttempt(EntityUid uid, TripwireComponent component, ref StepTriggerAttemptEvent args)
    {
        args.Continue = true;

        if (HasComp<ArmableComponent>(uid) && TryComp<ItemToggleComponent>(uid, out var itemToggle))
            args.Continue = itemToggle.Activated;
    }
}
