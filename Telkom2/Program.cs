using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telkom2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("                                 Nama : Ageng Septian Prasetio");
                Console.WriteLine("                                  TASK FOR BACKEND DEVELOPER ");
                Console.WriteLine("                             Tools yang digunakan untuk mengambil File log ");
                Console.WriteLine("===================================================================================================== ");
                Console.WriteLine("Anda dapat memasukan Path File dan Flag  dan Anda juga dapat menampilkan petunjuk Penggunaan dengan -h");
            RetryLabel:
                Console.WriteLine("");
                Console.WriteLine("Mulai : ");

                string input = Console.ReadLine();

                if (input.ToLower().Trim() == "-h")
                {

                    Console.WriteLine("Contoh Path File dan Flag : ");
                    Console.WriteLine("/var/log/nginx/error.log -o /User/johnmayer/Desktop/nginxlog.txt ");
                    Console.WriteLine("Atau ");
                    Console.WriteLine("/var/log/nginx/error.log -t json -o /User/johnmayer/Desktop/nginxlog.json ");
                    Console.WriteLine("============================================================================= ");
                    Console.WriteLine("Penjelasan :  ");
                    Console.WriteLine("Anda dapat mengkonversikan file dengan -t json atau -t txt");
                    Console.WriteLine("-t json : digunakan untuk mengkonversikan file menjadi File json");
                    Console.WriteLine("-t txt : digunakan untuk mengkonversikan file menjadi File txt");
                    Console.WriteLine("-o : digunakan untuk Meletakan File Output");
                    Console.WriteLine("/var/log/nginx/error.log : Path yang digunakan untuk mengambil Source File ");
                    Console.WriteLine("/User/johnmayer/Desktop/nginxlog.json : Path yang digunakan untuk Menaruh File ");
                    goto RetryLabel;
                }
                else
                {
                    if (!string.IsNullOrEmpty(input) && (input.Contains(@"\") || input.Contains(@"/")) && input.ToLower().Contains("-o"))
                    {
                        if (input.ToLower().Contains("-t") && input.ToLower().Contains("-o"))
                        {
                            string[] arr = input.Split(new string[] { "-t", "-o" }, StringSplitOptions.None);

                            FileInfo fi = new FileInfo(arr[0]);
                            // File Exists ?  
                           
                            if (!fi.Exists)
                            {
                                Console.WriteLine("Source File Tidak di temukan");
                                goto RetryLabel;
                            }
                            FileInfo fiDestination = new FileInfo(arr[2]);
                            // File Exists ?  
                            if (fiDestination.Exists)
                            {
                                Console.WriteLine("Nama File di Destination sudah ada, Harap ubah nama file");
                                goto RetryLabel;
                            }

                            if (arr[1].Trim() == "json")
                            {
                                File.Copy(arr[0], Path.ChangeExtension(arr[2], ".json"));

                            }
                            else 
                            {
                                File.Copy(arr[0], Path.ChangeExtension(arr[2], ".txt"));
                            }
                        }
                        else if (input.ToLower().Contains("-o"))
                        {
                            string[] arr = input.Split(new string[] { "-o" }, StringSplitOptions.None);
                            FileInfo fi = new FileInfo(arr[0]);
                            if (!fi.Exists)
                            {
                                Console.WriteLine("File Tidak di temukan");
                                goto RetryLabel;
                            }
                            FileInfo fiDestination = new FileInfo(arr[1]);
                            if (fiDestination.Exists)
                            {
                                Console.WriteLine("Nama File di Destination sudah ada, Harap ubah nama file");
                                goto RetryLabel;
                            }
                            File.Copy(arr[0], Path.ChangeExtension(arr[1], ".log"));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Inputan yang anda masukan tidak sesuai Format, untuk melihat Petunjuk Penggunaan anda dapat mengetikan -h");
                        goto RetryLabel;
                    }
                    Console.WriteLine("Selesai");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);
              
            }

        }

    }
}
