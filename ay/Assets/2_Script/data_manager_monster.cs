using UnityEngine;
using System.Collections;

public partial class data_manager
{ 

	public void download_monster_ver()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_monster_ver(delegate (bool _Finish, byte[] data)
        {
            if(_Finish)
            {
                load_monster_ver(data);
            }

        }));
    }

    public void load_monster_ver(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out monster_ver);
        set_download_state(DownLoadState.DOWNLOAD_MONSTER);
    }

    public void download_monster()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_monster(monster_ver, delegate (bool _Finish, byte[] data)
        {
            if(_Finish)
            {
                load_monster(data);
            }
        }));
    }

    public void load_monster(byte[] data)
    {
        int nMonster_Ver = -1;
        int nSize = 0;
        ResetReadBuffer();
        Read(data, out nMonster_Ver);
        Read(data, out nSize);

        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Monster_Object temp = new Monster_Object();
            Read(data, out temp.id);
            Read(data, out temp.name);
            Read(data, out temp.rating);
            Read(data, out temp.pattern_id);
            Read(data, out temp.hp);
            Read(data, out temp.play_time);
            Read(data, out temp._event);
            monster_obj_List.Add(temp);
        }
        set_download_state(DownLoadState.DOWNLOAD_RATING_VERSION);
    }

    public Monster_Object get_monster_for_id(int _id)
    {
        Monster_Object temp = null;
        for(int count_i=0; count_i<monster_obj_List.Count; ++count_i)
        {
            if (_id == monster_obj_List[count_i].id)
            {
                temp = monster_obj_List[count_i];
                break;
            }
        }

        return temp;
    }
}
