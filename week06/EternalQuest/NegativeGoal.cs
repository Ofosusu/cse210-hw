
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        return -Points;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description}) - " +
               $"Lose {Points} points when recorded";
    }

    public override string GetSaveString()
    {
        return $"Negative|{Name}|{Description}|{Points}";
    }
}
