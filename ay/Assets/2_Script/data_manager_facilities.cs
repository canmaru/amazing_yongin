using UnityEngine;
using System.Collections;

public partial class data_manager{

    public void download_facilities_ver()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_facilities_ver(delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_facilities_ver(data);
            }

        }));
    }

    public void load_facilities_ver(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out facilities_ver);
        set_download_state(DownLoadState.DOWNLOAD_FACILITIES);
    }

    public void download_facilities()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_facilities(facilities_ver, delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_facilities(data);
            }
        }));
    }

    public void load_facilities(byte[] data)
    {
        int nSize = 0;
        ResetReadBuffer();
        Read(data, out nSize);
        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Facilities_Object temp = new Facilities_Object();
            Read(data, out temp.id);
            Read(data, out temp.group_id);
            Read(data, out temp.code_id);
            Read(data, out temp.latitude);
            Read(data, out temp.longitude);
            facilities_obj_List.Add(temp);
        }
        set_download_state(DownLoadState.DOWNLOAD_EVENT_GATE_VERSION);
    }
}
