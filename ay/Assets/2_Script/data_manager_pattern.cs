using UnityEngine;
using System.Collections;

public partial class data_manager{
    
    public void download_pattern_size()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_pattern_size(delegate (bool _Finish, byte[] data)
        {
            if(_Finish)
            {
                load_pattern_size(data);
            }
        }));
    }

    public void load_pattern_size(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out patter_size);

        set_download_state(DownLoadState.DOWNLOAD_PATTERN);
    }

    public void download_pattern()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_pattern(patter_size, delegate (bool _Finish, byte[] data)
        {
            if(_Finish)
            {
                set_download_state(DownLoadState.DOWNLOAD_USER);
            }
        }));
    }

    public void load_pattern(byte[] data)
    {
        ResetReadBuffer();
        int nSize = 0;
        int x = 0;
        int y = 0;
        Pattern_Object temp = new Pattern_Object();
        Read(data, out temp.id);
        Read(data, out temp.rotation);
        Read(data, out temp.name);
        Read(data, out nSize);
        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Pattern_Info_Object info = new Pattern_Info_Object();
            info.bIsEnd = false;
            Read(data, out x);
            Read(data, out y);
            info.x = (float)x / DATA_MULTI;
            info.y = (float)y / DATA_MULTI;
            info.vec = new Vector2(info.x, info.y);
            Read(data, out info.delay);
            Read(data, out info.speed);
            temp.Pattern_List.Add(info);
        }
        pattern_obj_List.Add(temp);
    }

}
