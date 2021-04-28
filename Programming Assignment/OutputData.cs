using System;
using System.Collections.Generic;
using System.Text;

namespace Programming_Assignment
{
    /// <summary>
    /// This is a class that holds the response data from uploading the file
    /// </summary>
    public class UploadData
    {
        public string data_id { get; set; }
        public string status { get; set; }
        public int in_queue { get; set; }
        public string queue_priority { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
    }

    /// <summary>
    /// NOT IMPLEMENTED
    /// This holds response data from the API if they wish to do so, this is not used anywhere and can be removed if desired
    /// </summary>
    public class Data
    {
        public int scan_result_history_length { get; set; }
        public string file_id { get; set; }
        public string data_id { get; set; }
        public Sanitized sanitized { get; set; }
        public Process_Info process_info { get; set; }
        public Scan_Results scan_results { get; set; }
        public File_Info file_info { get; set; }
        public int share_file { get; set; }
        public string rest_version { get; set; }
        public object[] additional_info { get; set; }
        public Votes votes { get; set; }
    }

    public class Sanitized
    {
        public string result { get; set; }
        public int progress_percentage { get; set; }
        public string data_id { get; set; }
        public string reason { get; set; }
    }

    public class Process_Info
    {
        public string result { get; set; }
        public string profile { get; set; }
        public Post_Processing post_processing { get; set; }
        public bool file_type_skipped_scan { get; set; }
        public string blocked_reason { get; set; }
    }

    public class Post_Processing
    {
        public string copy_move_destination { get; set; }
        public string converted_to { get; set; }
        public string converted_destination { get; set; }
        public string actions_ran { get; set; }
        public string actions_failed { get; set; }
    }

    public class Scan_Results
    {
        public Scan_Details scan_details { get; set; }
        public bool rescan_available { get; set; }
        public int scan_all_result_i { get; set; }
        public DateTime start_time { get; set; }
        public int total_time { get; set; }
        public int total_avs { get; set; }
        public int total_detected_avs { get; set; }
        public int progress_percentage { get; set; }
        public string scan_all_result_a { get; set; }
    }

    public class Scan_Details
    {
        public Zillya Zillya { get; set; }
        public XvirusPersonalGuard XvirusPersonalGuard { get; set; }
        public Virusblokada VirusBlokAda { get; set; }
        public TrendmicroHouseCall TrendMicroHouseCall { get; set; }
        public Trendmicro TrendMicro { get; set; }
        public TotalDefense TotalDefense { get; set; }
        public Threattrack ThreatTrack { get; set; }
        public TACHYON TACHYON { get; set; }
        public Sophos Sophos { get; set; }
        public Superantispyware SUPERAntiSpyware { get; set; }
        public QuickHeal QuickHeal { get; set; }
        public Preventon Preventon { get; set; }
        public NANOAV NANOAV { get; set; }
        public Mcafee McAfee { get; set; }
        public K7 K7 { get; set; }
        public Jiangmin Jiangmin { get; set; }
        public Ikarus Ikarus { get; set; }
        public Huorong Huorong { get; set; }
        public Hauri Hauri { get; set; }
        public Fortinet Fortinet { get; set; }
        public Filseclab Filseclab { get; set; }
        public FSecure Fsecure { get; set; }
        public FProt Fprot { get; set; }
        public Emsisoft Emsisoft { get; set; }
        public ESET ESET { get; set; }
        public Cyren Cyren { get; set; }
        public Clamav ClamAV { get; set; }
        public Bytehero ByteHero { get; set; }
        public Bitdefender BitDefender { get; set; }
        public Baidu Baidu { get; set; }
        public Avira Avira { get; set; }
        public Antiy Antiy { get; set; }
        public Ahnlab Ahnlab { get; set; }
        public Agnitum Agnitum { get; set; }
        public VirITExplorer VirITeXplorer { get; set; }
        public VirITML VirITML { get; set; }
    }

    public class Zillya
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class XvirusPersonalGuard
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Virusblokada
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class TrendmicroHouseCall
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Trendmicro
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class TotalDefense
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Threattrack
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class TACHYON
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Sophos
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Superantispyware
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class QuickHeal
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Preventon
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class NANOAV
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Mcafee
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class K7
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Jiangmin
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Ikarus
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Huorong
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Hauri
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Fortinet
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Filseclab
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class FSecure
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class FProt
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Emsisoft
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class ESET
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Cyren
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Clamav
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Bytehero
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Bitdefender
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Baidu
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Avira
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Antiy
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Ahnlab
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class Agnitum
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class VirITExplorer
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class VirITML
    {
        public string threat_found { get; set; }
        public int scan_time { get; set; }
        public int scan_result_i { get; set; }
        public DateTime def_time { get; set; }
    }

    public class File_Info
    {
        public int file_size { get; set; }
        public DateTime upload_timestamp { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
        public string file_type_category { get; set; }
        public string file_type_description { get; set; }
        public string file_type_extension { get; set; }
        public string display_name { get; set; }
    }

    public class Votes
    {
        public int up { get; set; }
        public int down { get; set; }
    }

}
