using SQLite4Unity3d;

public class ScoreManager2
{

    [PrimaryKey, AutoIncrement]
    public int HighScore { get; set; }

    public override string ToString()
    {
        return string.Format("", HighScore);
    }
}