
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description}) - Eternal Goal";
    }

    public override string GetSaveString()
    {
        return $"Eternal|{Name}|{Description}|{Points}";
    }
}
