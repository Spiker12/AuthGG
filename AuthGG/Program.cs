using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthGG;
using System.Drawing;
using System.Threading;
using System.Windows;

namespace AuthGG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hello, spiker here! this is a authGG login that saves user username and password in a file and auto-logs in!
            Console.Title = "AuthGG Advanced Auth | By Spiker";
            string path = Environment.CurrentDirectory + "\\Files\\details.spiker";
            string currentDirectory = Environment.CurrentDirectory;
            if (!File.Exists(currentDirectory + "\\Files\\"))
            {
                Directory.CreateDirectory("Files"); // creates a folder named "Files"
            }

            OnProgramStart.Initialize("Name", "AID", "Secret", "Version");

            string version = "1.0";

            if (ApplicationSettings.Version != version)
            {
                Console.WriteLine("OUTDATED!!!!");
                Thread.Sleep(2500);
                Environment.Exit(0);
            }

            if (ApplicationSettings.Freemode == true)
            {
                Console.WriteLine("Freemode enabled, redirecting");
                Thread.Sleep(1500);
                // your code goes here
            }

            System.Console.Write(" [", Color.GhostWhite);
            System.Console.Write("1", Color.Red);
            System.Console.Write("] ", Color.GhostWhite);
            System.Console.Write("Login \n", Color.White);
            System.Console.Write(" [", Color.GhostWhite);
            System.Console.Write("2", Color.Red);
            System.Console.Write("] ", Color.GhostWhite);
            System.Console.Write("Register \n", Color.White);
            string module = System.Console.ReadLine();

            if (module == "1")
            {
                if (File.Exists(path))
                {
                    System.Console.Clear();
                    string[] strArray = File.ReadAllText(path).Split(':');
                    System.Console.Write(" [", Color.GhostWhite, new object[1]
                    {
              (object) 20
                    });
                    System.Console.Write("!", Color.Red, new object[1]
                    {
              (object) 20
                    });
                    string username2 = strArray[0];
                    System.Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Connecting To The Servers\n");
                    Thread.Sleep(500);
                    System.Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Connecting To The Servers.\n");
                    Thread.Sleep(500);
                    System.Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Connecting To The Servers..\n");
                    Thread.Sleep(500);
                    System.Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Connecting To The Servers...\n");
                    Thread.Sleep(500);
                    System.Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Connecting To The Servers\n");
                    Thread.Sleep(500);
                    System.Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Connecting To The Servers.\n");
                    Thread.Sleep(500);
                    System.Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Connecting To The Servers..\n");
                    Thread.Sleep(500);
                    System.Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Connecting To The Servers...\n");
                    Thread.Sleep(500);

                    Thread.Sleep(3000);
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("!", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.Write("Auto-logging!", Color.GhostWhite, new object[1]
        {
              (object) 20
        });
                    System.Console.WriteLine();
                    string password2 = strArray[1].Replace("\r\n", "");
                    if (API.Login(username2, password2))
                    {
                        System.Console.WriteLine();
                        System.Console.Write(" [", Color.GhostWhite, new object[1]
                        {
                (object) 20
                        });
                        System.Console.Write("!", Color.Red, new object[1]
                        {
                (object) 20
                        });
                        System.Console.Write("] Welcome Back " + username2 + "!", Color.GhostWhite, new object[1]
                        {
                (object) 20
                        });
                        Thread.Sleep(1000);
                        // here goes your code
                    }
                }

                else
                {
                    Console.Clear();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("+", Color.Purple);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.WriteLine("Username: ", Color.White);
                    System.Console.Write(" > ", Color.Red);
                    string username = System.Console.ReadLine();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("+", Color.Purple);
                    System.Console.Write("] Password", Color.GhostWhite);
                    System.Console.Write("\n > ", Color.Red);
                    string password = System.Console.ReadLine();
                    System.Console.WriteLine();

                    if (!ApplicationSettings.Login)
                    {
                        System.Windows.MessageBox.Show("Login is disabled!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        Environment.Exit(0);
                    }

                    if (API.Login(username, password))
                    {
                        using (StreamWriter text = File.CreateText(path))
                            text.WriteLine(username + ":" + password);
                        System.Console.Write(" [", Color.GhostWhite);
                        System.Console.Write("+", Color.Purple);
                        System.Console.Write("] ", Color.GhostWhite);
                        System.Console.WriteLine("Succesfully Logged In! ", Color.White);
                        Thread.Sleep(2500);
                        System.Console.Clear();
                        // here goes your code
                        Environment.Exit(0);
                    }
                }
            }

            if (module == "2")
            {
                if(!ApplicationSettings.Register)
                {
                    System.Console.WriteLine("[", Color.White);
                    System.Console.WriteLine("-", Color.Red);
                    System.Console.WriteLine("]", Color.White);
                    System.Console.WriteLine(" Register is disabled!");
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                }
                else
                {
                    System.Console.Clear();
                    System.Console.WriteLine();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("+", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.WriteLine("Username:");
                    string username1 = System.Console.ReadLine();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("+", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.WriteLine("Password:");
                    string password1 = System.Console.ReadLine();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("+", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.WriteLine("Email:");
                    string email = System.Console.ReadLine();
                    System.Console.Write(" [", Color.GhostWhite);
                    System.Console.Write("+", Color.Red);
                    System.Console.Write("] ", Color.GhostWhite);
                    System.Console.WriteLine("License:");
                    string license = System.Console.ReadLine();
                    if (API.Register(username1, password1, email, license))
                    {
                        System.Console.Write(" [", Color.GhostWhite);
                        System.Console.Write("+", Color.Red);
                        System.Console.Write("] ", Color.GhostWhite);
                        System.Console.WriteLine("Successfully Registered! ", Color.White);
                        Thread.Sleep(5000);
                        // here goes your code 
                        Environment.Exit(0);
                    }


                }
            }
        }
    }
}
