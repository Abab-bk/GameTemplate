using System;
using cfg.Stats;
using FlowerRpg.Stats;

namespace Game.Stats;

public class ActorStats
{
    private Stat[] Stats { get; } = new Stat[Enum.GetValues<StatType>().Length];
    private Vital[] Vitals { get; } = new Vital[Enum.GetValues<VitalType>().Length];
    
    public Stat this[StatType type]
    {
        get => Stats[(int)type];
        set => Stats[(int)type] = value;
    }

    public Vital this[VitalType type]
    {
        get => Vitals[(int)type];
        set => Vitals[(int)type] = value;
    }
}