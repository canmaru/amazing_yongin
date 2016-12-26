using UnityEngine;
using System.Collections;
using System;
using System.Text;

public partial class data_manager
{

    public const int BUFFER_SIZE = 20000;
    public const int DATA_MULTI = 10000;
    private Byte[] SendBuffer = new Byte[BUFFER_SIZE];
    private int mv_wr_pos = 0;
    private int wr_size = 0;

    //private Byte[] RecvBuffer = new Byte[BUFFER_SIZE];
    private int mv_rd_pos = 0;

    //쓰기
    private void Write(Byte[] _Data)
    {

        Array.Copy(_Data, 0, SendBuffer, mv_wr_pos, _Data.Length);
        mv_wr_pos += _Data.Length;
        wr_size += _Data.Length; ;
    }

    public void Write(string v)
    {
        if (string.IsNullOrEmpty(v))
        {
            v = "";
        }
        Byte[] Data = Encoding.UTF8.GetBytes(v);
        Byte[] DataSize = BitConverter.GetBytes(Data.Length);

        Write(DataSize);
        Write(Data);
    }

    public void Write(int v)
    {
        Byte[] Data = BitConverter.GetBytes((int)v);
        Write(Data);
    }

    public void Write(bool v)
    {
        Byte[] Data = BitConverter.GetBytes((bool)v);
        Write(Data);
    }

    public void Write(double v)
    {
        Byte[] Data = BitConverter.GetBytes((double)v);
        Write(Data);
    }

    public void GetSendBuffer(out Byte[] _Data)
    {
        _Data = new Byte[wr_size];
        Array.Copy(SendBuffer, 0, _Data, 0, wr_size);
    }

    public void ResetSendBuffer()
    {
        Array.Clear(SendBuffer, 0, BUFFER_SIZE);
        wr_size = 0;
        mv_wr_pos = 0;
    }

    //읽기
    void Read(int _nSize) { mv_rd_pos += _nSize; }
    public void Read(Byte[] RecvData, out string v)
    {
        int nSize = BitConverter.ToInt32(RecvData, mv_rd_pos);
        Read(sizeof(int));
        v = Encoding.UTF8.GetString(RecvData, mv_rd_pos, nSize);
        Read(nSize);
    }

    public void Read(Byte[] RecvData, out string v, int size)
    {
        v = Encoding.UTF8.GetString(RecvData, mv_rd_pos, size);
        Read(size);
    }

    public void Read(Byte[] RecvData, out int v)
    {
        v = BitConverter.ToInt32(RecvData, mv_rd_pos);
        Read(sizeof(int));
    }

    public void Read(Byte[] RecvData, out bool v)
    {
        v = BitConverter.ToBoolean(RecvData, mv_rd_pos);
        Read(sizeof(bool));
    }

    public void Read(Byte[] RecvData, out double v)
    {
        v = BitConverter.ToDouble(RecvData, mv_rd_pos);
        Read(sizeof(double));
    }

    public void ResetReadBuffer()
    {
        //Array.Clear( RecvBuffer, 0, 4096 * 2 );
        mv_rd_pos = 0;
    }
}
