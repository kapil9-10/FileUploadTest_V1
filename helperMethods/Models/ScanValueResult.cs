using System;
using System.Collections.Generic;
using System.Text;

namespace helperMethods.Models
{
    public class ScanValueResult
    {
        public int response_code { get; set; }
        public string verbose_msg { get; set; }
        public string resource { get; set; }
        public string scan_id { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
        public string scan_date { get; set; }
        public string permalink { get; set; }
        public int positives { get; set; }
        public int total { get; set; }
        public Dictionary<String, ScanObject> scans { get; set; }
    }
    public class ScanObject
    {
        public bool detected { get; set; }
        public string version { get; set; }
        public string result { get; set; }
        public string update { get; set; }
    }
    public class ScanObject_2
    {
        public string scan { get; set; }
        public bool detected { get; set; }
        public string version { get; set; }
        public string result { get; set; }
        public string update { get; set; }
    }
}
