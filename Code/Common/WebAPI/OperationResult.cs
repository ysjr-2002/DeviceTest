﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.WebAPI
{
    /// <summary>
    /// 登录 
    /// </summary>
    public class KoalaLogin
    {
        public int code { get; set; }

        public LoginData data { get; set; }
    }

    /// <summary>
    /// 登录数据
    /// </summary>
    public class LoginData
    {
        public string company { get; set; }

        public string contact { get; set; }

        public string email { get; set; }

        public int id { get; set; }

        public bool password_reseted { get; set; }

        public string phone { get; set; }

        public int role_id { get; set; }

        public string username { get; set; }
    }

    /// <summary>
    /// 用户
    /// </summary>
    public class SubjectData
    {
        public string remark { get; set; }

        public int subject_type { get; set; }

        public string description { get; set; }

        public string title { get; set; }

        public long timestamp { get; set; }

        public int start_time { get; set; }

        public int end_time { get; set; }

        public string avatar { get; set; }

        public string job_number { get; set; }

        public object birthday { get; set; }

        public object entry_date { get; set; }

        public string department { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public string[] photo_ids { get; set; }

        public photo[] photos { get; set; }
    }

    public class photo
    {
        public int company_id { get; set; }

        public int id { get; set; }

        public float quality { get; set; }

        public int subject_id { get; set; }

        public string url { get; set; }

        public int version { get; set; }
    }

    public class Subject
    {
        public int code { get; set; }

        public SubjectData data { get; set; }
    }

    public class UploadPhoto
    {
        public int code { get; set; }
        public UpdatePhotoData data { get; set; }
    }

    public class UpdatePhotoData
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public int subject_id { get; set; }
        public string url { get; set; }
        public float code { get; set; }

    }

    public class SubjectList
    {
        public int code { get; set; }

        public List<SubjectData> data { get; set; }
    }
}
