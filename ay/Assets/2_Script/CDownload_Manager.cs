using UnityEngine;
using System.Collections;

public class CDownload_Manager : MonoBehaviour {

    /// <summary>
    /// 다운로드 완료시 사용되는 델리게이트
    /// </summary>
    /// <param name="finish"></param>
    /// <param name="data"></param>
    public delegate void finish_download(bool finish, byte[] data);

    /// <summary>
    /// 이재성
    /// 2016-12-26
    /// 몬스터 버전을 다운로드 받는다.
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_monster_ver(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_monster_ver.dat"))
        {
            while(!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if(null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
            

    }

    /// <summary>
    /// 이재성
    /// 2016-12-26
    /// 몬스터 리스트 다운로드
    /// </summary>
    /// <param name="_Ver"></param>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_monster(int _Ver, finish_download _FinishDownload)
    {
        string _FileName = string.Format("http://lu01-vz3647.ktics.co.kr/ay_monster_{0:0000000}.dat", _Ver);
        using (WWW www = new WWW(_FileName))
        {
            while(!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if(null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-26
    /// 등급 버전 다운로드
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_rating_ver(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_rating_version.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-26
    /// 등급 다운로드
    /// </summary>
    /// <param name="_Ver"></param>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_rating(int _Ver, finish_download _FinishDownload)
    {
        string _FileName = string.Format("http://lu01-vz3647.ktics.co.kr/ay_rating_{0:0000000}.dat", _Ver);
        using (WWW www = new WWW(_FileName))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-26
    /// 패턴 사이즈 다운로드
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_pattern_size(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_pattern_size.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-26
    /// 패턴 다운로드
    /// </summary>
    /// <param name="_Ver"></param>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_pattern(int _Ver, finish_download _FinishDownload)
    {
        for(int count_i=0; count_i< data_manager.Instance.patter_size; ++count_i)
        {
            using (WWW www = new WWW(string.Format("http://lu01-vz3647.ktics.co.kr/monster_pattern_{0:0000000}.dat", count_i + 1)))
            {
                while(!www.isDone)
                {
                    yield return null;
                }

                yield return www;
                if(null != www.error)
                {
                    throw new System.Exception("WWW download:" + www.error);
                }
                byte[] data = www.bytes;
                data_manager.Instance.load_pattern(data);
            }
        }
        _FinishDownload(true, null);
    }

    /// <summary>
    /// 이재성
    /// 2016-12-26
    /// 유저 정보를 다운로드
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_user(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_user.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 그룹 버전 다운로드
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_group_ver(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_group_ver.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 그룹 다운로드
    /// </summary>
    /// <param name="_Ver"></param>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_group(int _Ver, finish_download _FinishDownload)
    {
        string _FileName = string.Format("http://lu01-vz3647.ktics.co.kr/ay_group_{0:0000000}.dat", _Ver);
        using (WWW www = new WWW(_FileName))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 명소 버전 다운로드
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_attraction_ver(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_attraction_ver.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 명소 다운로드
    /// </summary>
    /// <param name="_Ver"></param>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_attraction(int _Ver, finish_download _FinishDownload)
    {
        string _FileName = string.Format("http://lu01-vz3647.ktics.co.kr/ay_attraction_{0:0000000}.dat", _Ver);
        using (WWW www = new WWW(_FileName))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 게이트 버전 다운로드
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_gate_ver(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_gate_ver.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 게이트 다운로드
    /// </summary>
    /// <param name="_Ver"></param>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_gate(int _Ver, finish_download _FinishDownload)
    {
        string _FileName = string.Format("http://lu01-vz3647.ktics.co.kr/ay_gate_{0:0000000}.dat", _Ver);
        using (WWW www = new WWW(_FileName))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    public IEnumerator download_facilities_code_ver(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_facilities_code_ver.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    public IEnumerator download_facilities_code(int _Ver, finish_download _FinishDownload)
    {
        string _FileName = string.Format("http://lu01-vz3647.ktics.co.kr/ay_facilities_code_{0:0000000}.dat", _Ver);
        using (WWW www = new WWW(_FileName))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }


    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 편의시설 버전 다운로드
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_facilities_ver(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_facilities_ver.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 편의시설 다운로드
    /// </summary>
    /// <param name="_Ver"></param>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_facilities(int _Ver, finish_download _FinishDownload)
    {
        string _FileName = string.Format("http://lu01-vz3647.ktics.co.kr/ay_facilities_{0:0000000}.dat", _Ver);
        using (WWW www = new WWW(_FileName))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 이벤트 게이트 버전 다운로드
    /// </summary>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_event_gate_ver(finish_download _FinishDownload)
    {
        using (WWW www = new WWW("http://lu01-vz3647.ktics.co.kr/ay_event_gate_ver.dat"))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }

    /// <summary>
    /// 이재성
    /// 2016-12-27
    /// 이벤트 게이트 다운로드
    /// </summary>
    /// <param name="_Ver"></param>
    /// <param name="_FinishDownload"></param>
    /// <returns></returns>
    public IEnumerator download_event_gate(int _Ver, finish_download _FinishDownload)
    {
        string _FileName = string.Format("http://lu01-vz3647.ktics.co.kr/ay_event_gate_{0:0000000}.dat", _Ver);
        using (WWW www = new WWW(_FileName))
        {
            while (!www.isDone)
            {
                yield return null;
            }
            yield return www;
            if (null != www.error)
            {
                throw new System.Exception("WWW download:" + www.error);
            }
            byte[] data = www.bytes;
            _FinishDownload(true, data);
        }
    }
}
