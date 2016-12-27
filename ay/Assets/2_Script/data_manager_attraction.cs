using UnityEngine;
using System.Collections;

public partial class data_manager {

    public void download_attraction_ver()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_attraction_ver(delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_attraction_ver(data);
            }

        }));
    }

    public void load_attraction_ver(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out attraction_ver);
        set_download_state(DownLoadState.DOWNLOAD_ATTRACTION);
    }

    public void download_attraction()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_attraction(attraction_ver, delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_attraction(data);
            }
        }));
    }

    public void load_attraction(byte[] data)
    {
        int nSize = 0;
        ResetReadBuffer();
        Read(data, out nSize);
        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Attraction_Object temp = new Attraction_Object();
            Read(data, out temp.id);
            Read(data, out temp.group_id);
            Read(data, out temp.name);
            Read(data, out temp.latitude);
            Read(data, out temp.longitude);
            Read(data, out temp.explanation);
            attraction_obj_List.Add(temp);
        }
        set_download_state(DownLoadState.DOWNLOAD_GATE_VERSION);
    }
}
