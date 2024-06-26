﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDoc.DAL.ViewModels.Records
{
    public class BlockRequestvm
    {
        public List<blockedRequest>? blockrequestList { get; set; }
        public string? searchRecordOne { get; set; }
        public string? searchRecordTwo { get; set; }
        public string? searchRecordThree { get; set; }
        public string? searchRecordFour { get; set; }
    }

    public class blockedRequest
    {
        public int? requestid { get; set; }
        public string? patientname { get; set; }
        public string? contact { get; set; }
        public string? email { get; set; }
        public DateTime? createddate { get; set; }
        public string? notes { get; set; }
        public bool isactive { get; set; }
    }

}
