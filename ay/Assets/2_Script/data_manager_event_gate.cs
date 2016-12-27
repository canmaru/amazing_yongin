using UnityEngine;
using System.Collections;

public partial class data_manager {

    public void download_event_gate_ver()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_event_gate_ver(delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_event_gate_ver(data);
            }

        }));
    }

    public void load_event_gate_ver(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out event_gate_ver);
        set_download_state(DownLoadState.DOWNLOAD_EVENT_GATE);
    }

    public void download_event_gate()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_event_gate(event_gate_ver, delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_event_gate(data);
            }
        }));
    }

    public void load_event_gate(byte[] data)
    {
        int nSize = 0;
        ResetReadBuffer();
        Read(data, out nSize);
        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Event_Gate_Object temp = new Event_Gate_Object();
            Read(data, out temp.id);
            Read(data, out temp.group_id);
            Read(data, out temp.name);
            Read(data, out temp.latitude);
            Read(data, out temp.longitude);
            Read(data, out temp.s_time);
            Read(data, out temp.e_time);
            Read(data, out temp.gen_time);
            Read(data, out temp.radius);
            Read(data, out temp.per);
            Read(data, out temp.Enabled);
            Read(data, out temp.monster_id);
            event_gate_obj_List.Add(temp);
        }
        set_download_state(DownLoadState.DOWNLOAD_FINISH);
    }
}
