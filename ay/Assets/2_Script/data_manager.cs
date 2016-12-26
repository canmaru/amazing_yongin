using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum DownLoadState
{
    DOWNLOAD_MONSTER_VERSION,
    DOWNLOAD_MONSTER,
    DOWNLOAD_RATING_VERSION,
    DOWNLOAD_RATING,
    DOWNLOAD_PATTERN_SIZE,
    DOWNLOAD_PATTERN,
    DOWNLOAD_USER,
    DOWNLOAD_FINISH,
}


public class Monster_Object
{
    public int id;
    public string name;
    public int rating;
    public int pattern_id;
    public int hp;
    public int play_time;
    public int _event;
}

public class Rating_Object
{
    public int rating;
    public int exp;
    //public int play_time;
}

public class Pattern_Info_Object
{
    public Vector2 vec;
    public float x;
    public float y;
    public int delay;
    public int speed;
    public bool bIsEnd;
}

public class Pattern_Object
{
    public int id;
    public string name;
    public int rotation;
    public List<Pattern_Info_Object> Pattern_List = new List<Pattern_Info_Object>();
}

public class User_Object
{
    public int exp;
    public int exp_max_lev;
    public int atk;
}

public sealed partial class data_manager : MonoBehaviour
{

    private static volatile data_manager _instance = null;
    public static data_manager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType(typeof(data_manager)) as data_manager;
                if (null == _instance)
                {
                    GameObject container = new GameObject();
                    container.name = "data_manager";
                    _instance = container.AddComponent(typeof(data_manager)) as data_manager;
                    DontDestroyOnLoad(_instance);
                }
            }
            return _instance;
        }
    }

    public int monster_ver = -1;
    public int rating_ver = -1;
    public int patter_size = -1;

    public List<Monster_Object> monster_obj_List = new List<Monster_Object>();
    public List<Pattern_Object> pattern_obj_List = new List<Pattern_Object>();
    public List<Rating_Object> rating_obj_List = new List<Rating_Object>();
    public User_Object user_obj;

    private Camera current_Camera;

    GameObject _Download_Manager;
    public void init_data()
    {
        if(null == _Download_Manager)
        {
            _Download_Manager = new GameObject("Download_Manager");
            _Download_Manager.AddComponent<CDownload_Manager>();
        }

        set_download_state(DownLoadState.DOWNLOAD_MONSTER_VERSION);
    }

    public void set_download_state(DownLoadState state)
    {
        switch (state)
        {
            case DownLoadState.DOWNLOAD_MONSTER_VERSION:
                download_monster_ver();
                break;
            case DownLoadState.DOWNLOAD_MONSTER:
                download_monster();
                break;
            case DownLoadState.DOWNLOAD_RATING_VERSION:
                download_rating_ver();
                break;
            case DownLoadState.DOWNLOAD_RATING:
                download_rating();
                break;
            case DownLoadState.DOWNLOAD_PATTERN_SIZE:
                download_pattern_size();
                break;
            case DownLoadState.DOWNLOAD_PATTERN:
                download_pattern();
                break;
            case DownLoadState.DOWNLOAD_USER:
                download_user();
                break;
            case DownLoadState.DOWNLOAD_FINISH:
                Debug.Log("asdf");
                break;
        }
    }
}
