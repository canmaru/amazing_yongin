using UnityEngine;
using System.Collections;

public partial class data_manager {

    public void download_group_ver()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_group_ver(delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_group_ver(data);
            }

        }));
    }

    public void load_group_ver(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out group_ver);
        set_download_state(DownLoadState.DOWNLOAD_GROUP);
    }

    public void download_group()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_group(group_ver, delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_group(data);
            }
        }));
    }

    public void load_group(byte[] data)
    {
        int nSize = 0;
        ResetReadBuffer();
        Read(data, out nSize);
        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Group_Object temp = new Group_Object();
            Read(data, out temp.id);
            Read(data, out temp.name);
            group_obj_List.Add(temp);
        }
        set_download_state(DownLoadState.DOWNLOAD_ATTRACTION_VERSION);
    }

}
