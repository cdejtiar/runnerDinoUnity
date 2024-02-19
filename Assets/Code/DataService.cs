using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService
{

    private SQLiteConnection _connection;

    public DataService(string DatabaseName)
    {

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
            var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                                                                                     // then save to Application.persistentDataPath
            File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);

    }
    public void CreateDB()
    {
        //_connection.DropTable<ScoreManager2>();
        _connection.CreateTable<ScoreManager2>();
        /*_connection.InsertAll(new[]{
                new ScoreManager2{
                    HighScore = ScoreManager.Instance.HighScore
            }
        });*/

        //insert highscore into table in sql query
        _connection.Execute("INSERT INTO ScoreManager2 (HighScore) VALUES (?)", ScoreManager.Instance.HighScore);
    }
    /*public IEnumerable<ScoreManager2> GetHighscore()
    {
        return _connection.Table<ScoreManager2>();
    }*/

    public int GetHighscore()
{
    var highestScoreRecord = _connection.Table<ScoreManager2>()
                                        .OrderByDescending(s => s.HighScore)
                                        .FirstOrDefault();
    
    return highestScoreRecord != null ? highestScoreRecord.HighScore : 0;
}


    public void UpdateHighscore(int newHighscore)
    {
        var existingRecord = _connection.Table<ScoreManager2>().FirstOrDefault();

        if (existingRecord != null)
        {
            existingRecord.HighScore = newHighscore;
            _connection.Execute("UPDATE ScoreManager2 SET HighScore = ? ", existingRecord.HighScore);
        }
        else
        {
            _connection.Insert(new ScoreManager2 { HighScore = newHighscore });
        }
    }
}