using SQLite4Unity3d;


public class HighscoreTable
{
    [PrimaryKey, AutoIncrement]
    public int HighScore { get; set; }

    public override string ToString()
    {
        return string.Format("", HighScore);
    }
}