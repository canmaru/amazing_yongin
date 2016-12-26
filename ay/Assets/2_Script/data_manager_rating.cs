using UnityEngine;
using System.Collections;

public partial class data_manager{

    public void download_rating_ver()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_rating_ver(delegate (bool _Finish, byte[] data)
        {
            if(_Finish)
            {
                load_rating_ver(data);
            }
        }));
    }

    public void load_rating_ver(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out rating_ver);

        set_download_state(DownLoadState.DOWNLOAD_RATING);
    }

    public void download_rating()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_rating(rating_ver, delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_rating(data);
            }
        }));
    }
	
    public void load_rating(byte[] data)
    {
        int nRating_Ver = -1;
        int nSize = 0;
        ResetReadBuffer();
        Read(data, out nRating_Ver);
        Read(data, out nSize);
        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Rating_Object temp = new Rating_Object();
            Read(data, out temp.rating);
            Read(data, out temp.exp);
            rating_obj_List.Add(temp);
        }
        set_download_state(DownLoadState.DOWNLOAD_PATTERN_SIZE);
    }
}
