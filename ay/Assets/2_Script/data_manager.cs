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
    DOWNLOAD_GROUP_VERSION,
    DOWNLOAD_GROUP,
    DOWNLOAD_ATTRACTION_VERSION,
    DOWNLOAD_ATTRACTION,
    DOWNLOAD_GATE_VERSION,
    DOWNLOAD_GATE,
    DOWNLOAD_FACILITIES_CODE_VERSION,
    DOWNLOAD_FACILITIES_CODE,
    DOWNLOAD_FACILITIES_VERSION,
    DOWNLOAD_FACILITIES,
    DOWNLOAD_EVENT_GATE_VERSION,
    DOWNLOAD_EVENT_GATE,
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

public class Attraction_Object
{
    public int id;
    public int group_id;
    public string name;
    public string latitude;
    public string longitude;
    public string explanation;
}

public class Group_Object
{
    public int id;
    public string name;
}

public class Main_Gate_Object
{
    public int id;
    public int attraction_id;
    public string start_time;
    public string end_time;
}

public class Facilities_Code_Object
{
    public int id;
    public string name;
}

public class Facilities_Object
{
    public int id;
    public int group_id;
    public int code_id;
    public string latitude;
    public string longitude;
}


public class Gate_Monster_Object
{
    public int id;
    public string name;
    public int rating;
    public double per;
    public int _event;
}

public class Gate_Object
{
    public int id;
    public int group_id;
    public int main_gate_id; //안씀
    public int attraction_id; //안씀
    public string name;
    public string latitude;
    public string longitude;
    public int max_monster;
    public int gen_time;
    public int radius;
    public int density; //안씀
    public int respawn; //안씀
    public double rating_1_per;
    public double rating_2_per;
    public double rating_3_per;
    public double rating_4_per;
    public double rating_5_per;
    public bool Enabled;
    public List<Gate_Monster_Object> rating_1_List = new List<Gate_Monster_Object>();
    public List<Gate_Monster_Object> rating_2_List = new List<Gate_Monster_Object>();
    public List<Gate_Monster_Object> rating_3_List = new List<Gate_Monster_Object>();
    public List<Gate_Monster_Object> rating_4_List = new List<Gate_Monster_Object>();
    public List<Gate_Monster_Object> rating_5_List = new List<Gate_Monster_Object>();
}

public class Event_Gate_Object
{
    public int id;
    public int group_id;
    public string name;
    public string latitude;
    public string longitude;
    public string s_time;
    public string e_time;
    public int gen_time;
    public int radius;
    public double per;
    public bool Enabled;
    public int end;
    public int monster_id;
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
    public int group_ver = -1;
    public int attraction_ver = -1;
    public int gate_ver = -1;
    public int facilities_code_ver = -1;
    public int facilities_ver = -1;
    public int event_gate_ver = -1;


    public List<Monster_Object> monster_obj_List = new List<Monster_Object>();
    public List<Pattern_Object> pattern_obj_List = new List<Pattern_Object>();
    public List<Rating_Object> rating_obj_List = new List<Rating_Object>();
    public List<Group_Object> group_obj_List = new List<Group_Object>();
    public List<Attraction_Object> attraction_obj_List = new List<Attraction_Object>();
    //public List<Main_Gate_Object> main_gate_obj_List = new List<Main_Gate_Object>();
    public List<Facilities_Code_Object> facilities_code_obj_List = new List<Facilities_Code_Object>();
    public List<Facilities_Object> facilities_obj_List = new List<Facilities_Object>();
    public List<Gate_Object> gate_obj_List = new List<Gate_Object>();
    public List<Event_Gate_Object> event_gate_obj_List = new List<Event_Gate_Object>();
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
            case DownLoadState.DOWNLOAD_GROUP_VERSION:
                download_group_ver();
                break;
            case DownLoadState.DOWNLOAD_GROUP:
                download_group();
                break;

            case DownLoadState.DOWNLOAD_ATTRACTION_VERSION:
                download_attraction_ver();
                break;

            case DownLoadState.DOWNLOAD_ATTRACTION:
                download_attraction();
                break;

            case DownLoadState.DOWNLOAD_GATE_VERSION:
                download_gate_ver();
                break;

            case DownLoadState.DOWNLOAD_GATE:
                download_gate();
                break;

            case DownLoadState.DOWNLOAD_FACILITIES_CODE_VERSION:
                download_facilities_code_ver();
                break;

            case DownLoadState.DOWNLOAD_FACILITIES_CODE:
                download_facilities_code();
                break;

            case DownLoadState.DOWNLOAD_FACILITIES_VERSION:
                download_facilities_ver();
                break;

            case DownLoadState.DOWNLOAD_FACILITIES:
                download_facilities();
                break;

            case DownLoadState.DOWNLOAD_EVENT_GATE_VERSION:
                download_event_gate_ver();
                break;

            case DownLoadState.DOWNLOAD_EVENT_GATE:
                download_event_gate();
                break;

            case DownLoadState.DOWNLOAD_FINISH:
                Debug.Log("asdf");
                break;
        }
    }
}
