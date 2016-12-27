using UnityEngine;
using System.Collections;

public partial class data_manager {

    public void download_gate_ver()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_gate_ver(delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_gate_ver(data);
            }

        }));
    }

    public void load_gate_ver(byte[] data)
    {
        ResetReadBuffer();
        Read(data, out gate_ver);
        set_download_state(DownLoadState.DOWNLOAD_GATE);
    }

    public void download_gate()
    {
        StartCoroutine(_Download_Manager.GetComponent<CDownload_Manager>().download_gate(gate_ver, delegate (bool _Finish, byte[] data)
        {
            if (_Finish)
            {
                load_gate(data);
            }
        }));
    }

    public void load_gate(byte[] data)
    {
        int nSize = 0;
        ResetReadBuffer();
        Read(data, out nSize);
        for (int count_i = 0; count_i < nSize; ++count_i)
        {
            Gate_Object temp = new Gate_Object();
            Read(data, out temp.id);
            Read(data, out temp.group_id);
            Read(data, out temp.name);
            Read(data, out temp.latitude);
            Read(data, out temp.longitude);
            Read(data, out temp.max_monster);
            Read(data, out temp.gen_time);
            Read(data, out temp.radius);
            Read(data, out temp.rating_1_per);
            Read(data, out temp.rating_2_per);
            Read(data, out temp.rating_3_per);
            Read(data, out temp.rating_4_per);
            Read(data, out temp.rating_5_per);
            Read(data, out temp.Enabled);
            int count_1 = 0;
            Read(data, out count_1);
            for (int count_j = 0; count_i < count_1; ++count_j)
            {
                Gate_Monster_Object gate_temp = new Gate_Monster_Object();
                Read(data, out gate_temp.id);
                Read(data, out gate_temp.name);
                Read(data, out gate_temp.rating);
                Read(data, out gate_temp.per);
                temp.rating_1_List.Add(gate_temp);
            }

            int count_2 = 0;
            Read(data, out count_2);
            for (int count_j = 0; count_i < count_2; ++count_j)
            {
                Gate_Monster_Object gate_temp = new Gate_Monster_Object();
                Read(data, out gate_temp.id);
                Read(data, out gate_temp.name);
                Read(data, out gate_temp.rating);
                Read(data, out gate_temp.per);
                temp.rating_2_List.Add(gate_temp);
            }

            int count_3 = 0;
            Read(data, out count_3);
            for (int count_j = 0; count_i < count_3; ++count_j)
            {
                Gate_Monster_Object gate_temp = new Gate_Monster_Object();
                Read(data, out gate_temp.id);
                Read(data, out gate_temp.name);
                Read(data, out gate_temp.rating);
                Read(data, out gate_temp.per);
                temp.rating_3_List.Add(gate_temp);
            }

            int count_4 = 0;
            Read(data, out count_4);
            for (int count_j = 0; count_i < count_4; ++count_j)
            {
                Gate_Monster_Object gate_temp = new Gate_Monster_Object();
                Read(data, out gate_temp.id);
                Read(data, out gate_temp.name);
                Read(data, out gate_temp.rating);
                Read(data, out gate_temp.per);
                temp.rating_4_List.Add(gate_temp);
            }

            int count_5 = 0;
            Read(data, out count_5);
            for (int count_j = 0; count_i < count_5; ++count_j)
            {
                Gate_Monster_Object gate_temp = new Gate_Monster_Object();
                Read(data, out gate_temp.id);
                Read(data, out gate_temp.name);
                Read(data, out gate_temp.rating);
                Read(data, out gate_temp.per);
                temp.rating_5_List.Add(gate_temp);
            }

            gate_obj_List.Add(temp);
        }
        set_download_state(DownLoadState.DOWNLOAD_FACILITIES_CODE_VERSION);
    }
}
