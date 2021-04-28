using System;
using System.IO;
using System.Security.Cryptography;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace Programming_Assignment
{


    class Program
    {
        //Place API key here
        public static readonly string ApiKey = "INSERT KEY HERE";

        
        static void Main(string[] args)
        {
            //Not nessasary to type "upload_file", can be anything, but is required to seperate the user input with a space.
            Console.WriteLine("Type \"upload_file\" and the file you would like to upload.");
            string Command = Console.ReadLine();
            string[] arguments = Command.Split(' ');

            //Initizlize the file control that handles getting its hash value
            FileControl file = new FileControl(arguments[1]);

            //runs the first task that looks up the file by Hash
            var t1 = Task.Run(() => HashLookUpAsync(file));

            //if it doesnt find it, then this enters and attempts to upload the fille
            if (!t1.Result)
            {
                Console.WriteLine("\nAttempting to Upload and Scan File\n");
                var t2 = Task.Run(() => FileUploadAsync(file));
                //enters if the file is uploaded and retrieves the data with a call by its ID
                if (t2.Result)
                {
                    Console.WriteLine("Printing Scan Details");
                    var t3 = Task.Run(() => FileScanDataIdAsync(file));
                }
            }

            //prevents the console from closing and waits for tasks to finish
            Console.ReadLine();
        }

        /// <summary>
        /// Gets the Hash from the file, and attempts to look it up, returns false if the file can not be found
        /// or true and prints out the previous scan results
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<bool> HashLookUpAsync(FileControl file)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.metadefender.com/v4/hash/" + file.Hash)) //Starts the Get Command
                {
                    request.Headers.TryAddWithoutValidation("apikey", ApiKey); //adds the api key as a header for access

                    var response = await httpClient.SendAsync(request); //Sends command
                    string responseString = await response.Content.ReadAsStringAsync(); //retrieves response from API
                    dynamic data1 = JsonConvert.DeserializeObject(responseString); // gets a dynamic data type of the string that is returned
                    
                    if (!responseString.Contains("error")) //Simply checks if the message is either an error or not, not the best use, can be improved
                    {
                        Console.WriteLine("\nAlready Chached File\n");
                        foreach (object d in data1)
                        {
                            Console.WriteLine(d); //prints every line of the dynamic data
                        }
                        return true;
                    }
                    else
                    {
                        return false; //returns false if there is NOT a file already in the system
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to upload the file and gets the data_ID to pull the scan results
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<bool> FileUploadAsync(FileControl file)
        {
            using var httpClient = new HttpClient();
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.metadefender.com/v4/file")) //Post command, similar to the above statement
            {
                request.Headers.TryAddWithoutValidation("apikey", ApiKey);
                request.Headers.TryAddWithoutValidation("sandbox", "windows10");

                request.Content = new StringContent(Regex.Replace(File.ReadAllText(file.DocPath + "\\" + file.FileName), "(?:\\r\\n|\\n|\\r)", string.Empty));
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");

                var response = await httpClient.SendAsync(request);


                string responseString = await response.Content.ReadAsStringAsync();
                UploadData data = System.Text.Json.JsonSerializer.Deserialize<UploadData>(responseString); //This is wasted space, but does initilize everything in the Output data file
                //Could be implemented to neatly print out everything
                
                if (!responseString.Contains("error"))
                {
                    file.Data_Id = data.data_id;
                    return true;
                }
                else
                {
                    Console.WriteLine("\nERROR, failed to upload File\n");
                    return false;
                }
                
            }
        }

        /// <summary>
        /// Pulls Scan results by data ID, very similar to the HashLookUp method above
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<bool> FileScanDataIdAsync(FileControl file)
        {
            using var httpClient = new HttpClient();
            using var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.metadefender.com/v4/file/" + file.Data_Id);
            request.Headers.TryAddWithoutValidation("apikey", ApiKey);
            var response = await httpClient.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(responseString);
            
            if (!responseString.Contains("error"))
            {
                foreach (object d in data)
                {
                    Console.WriteLine(d);
                }
                return true;
            }
            else
            {
                Console.WriteLine("ERROR");
                return false;
            }
        }
    }
   




    /// <summary>
    /// Holds relevents data based off the file the user entered. Is required for the file to be in documents
    /// Or the user can modify the code to look for something more specific without moving the data around
    /// </summary>
    class FileControl
    {
        public string FileName;
        public string DocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string AnyPath = "C:\\Users\\stavi\\Desktop";
        public string Hash;
        public string Data_Id;

        //Constuctor that calls the hashing method
        public FileControl(string FileName)
        {
            this.FileName = FileName;
            Hash = GetHash(this.FileName);
        }

        //Simple Hashing
        private string GetHash(string FileName)
        {
            using MD5 md5 = MD5.Create();
            using Stream stream = File.OpenRead(DocPath + "\\" + FileName);
            byte[] hashBit = md5.ComputeHash(stream);
            return BitConverter.ToString(hashBit).Replace("-", "").ToLowerInvariant();
        }
    }
}
