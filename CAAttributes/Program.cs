using System.Reflection;

List<Player> players = new List<Player> {
    new Player { Name = "Player1", BallControl = 5, Dribbling = 10, Passing = 4, Speed = 99, Power = 999 }, // ✅
    new Player { Name = "Player2", BallControl = 0, Dribbling = 21, Passing = 4, Speed = 101, Power = 800 }, // ❌
    new Player { Name = "Player3", BallControl = 8, Dribbling = 18, Passing = 4, Speed = 88, Power = 950 }, // ✅
};

var errors = new List<Error>();

// Reflection:
foreach (var player in players)
{
    var properties = player.GetType().GetProperties();
    foreach (var prop in properties)
    {
        var skillAttribute = prop.GetCustomAttributes<SkillAttribute>().FirstOrDefault();
        if (skillAttribute is not null)
        {
            var value = prop.GetValue(player);
            if (!skillAttribute.IsValid(value))
            {
                errors.Add(new Error(
                    player.Name,
                    prop.Name,
                    $"Invalid VALUE Accepted Range is {skillAttribute.Minimum}-{skillAttribute.Maximum}"
                ));
            }
        }
    }
}

if (errors.Count > 0)
{
    foreach (var e in errors)
    {
        Console.WriteLine(e);
    }
}
else
{
    Console.WriteLine("Player info are valid");
}


// ======== Classes =========

public class Player
{
    public string Name { get; set; }

    [Skill(nameof(BallControl), 1, 10)]// attribute
    public int BallControl { get; set; }

    [Skill(nameof(Dribbling), 1, 20)]
    public int Dribbling { get; set; }

    [Skill(nameof(Power), 1, 1000)]
    public int Power { get; set; }

    [Skill(nameof(Speed), 1, 100)]
    public int Speed { get; set; }

    [Skill(nameof(Passing), 1, 4)]
    public int Passing { get; set; }
}

public class SkillAttribute : Attribute
{
    public SkillAttribute(string name, int minimum, int maximum)
    {
        Name = name;
        Minimum = minimum;
        Maximum = maximum;
    }

    public string Name { get; private set; }
    public int Minimum { get; private set; }
    public int Maximum { get; private set; }

    public bool IsValid(object obj)
    {
        var value = (int)obj;
        return value >= Minimum && value <= Maximum;
    }
}

public class Error
{
    private string playerName;
    private string field;
    private string details;

    public Error(string playerName, string field, string details)
    {
        this.playerName = playerName;
        this.field = field;
        this.details = details;
    }

    public override string ToString()
    {
        return $"Player: {playerName} => {{\"{field}\": \"{details}\"}}";
    }
}