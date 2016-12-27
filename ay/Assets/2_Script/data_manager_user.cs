using UnityEngine;
using System.Collections;

public partial class data_manager {
    public void download_user()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_user(delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_user(data);
            }
        }));
    }

    public void load_user(byte[] data)
    {
        ResetReadBuffer();
        User_Object temp = new User_Object();
        Read(data, out temp.exp);
        Read(data, out temp.exp_max_lev);
        Read(data, out temp.atk);
        set_download_state(DownLoadState.DOWNLOAD_GROUP_VERSION);
    }
}
