using UnityEngine;
using System.Collections;

public partial class data_manager {

    public void download_facilities_code_ver()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_facilities_code_ver(delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_facilities_code_ver(data);
            }

        }));
    }

    public void load_facilities_code_ver(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out facilities_code_ver);
        set_download_state(DownLoadState.DOWNLOAD_FACILITIES_CODE);
    }

    public void download_facilities_code()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_facilities_code(facilities_code_ver, delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_facilities_code(data);
            }
        }));
    }

    public void load_facilities_code(byte[] data)
    {
        int nSize = 0;
        ResetReadBuffer();
        Read(data, out nSize);
        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Facilities_Code_Object temp = new Facilities_Code_Object();
            Read(data, out temp.id);
            Read(data, out temp.name);
            facilities_code_obj_List.Add(temp);
        }
        set_download_state(DownLoadState.DOWNLOAD_FACILITIES_VERSION);
    }
}
