using System;
using System.Collections;
using System.Media;
using System.Threading;
using Memo;
using System.Diagnostics;

namespace ASCII
{
    class Program
    {
        private static string name;
        static string control, input3;
        static string intrest = "";
        static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Console.Clear();

            intro();
            Margins("=");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" Welcome to Our Cyber Security Awareness ".PadLeft(50));
            Console.WriteLine($"\n Am your AI Bot Please Enter your name\n".PadLeft(45));
            Console.ResetColor();

            name = Console.ReadLine();

            Margins("-");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" Pleased to meet you {name}, I'll be your AI Assistant".PadLeft(55));
            Console.WriteLine($" Let's dive into our journey".PadLeft(45));
            Console.ResetColor();

            phase1();

            System.Console.WriteLine("");
        }
        static void passwordSafety()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            TitlesUI("Password Safety");
            Console.ResetColor();

            Console.WriteLine(" Password safety refers to best practices that help protect passwords from being stolen or cracked.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($" {name}, Choose a topic:".PadLeft(30));
                Console.ResetColor();

                Console.WriteLine(" ┌─────────────────────────────┐");
                Console.WriteLine(" │ (1) Importance              │");
                Console.WriteLine(" │ (2) Key Principles          │");
                Console.WriteLine(" │ (3) Strong Password         │");
                Console.WriteLine(" │ (4) Common Mistakes         │");
                Console.WriteLine(" │ (5) Security Measures       │");
                Console.WriteLine(" └─────────────────────────────┘");
                input3 = Console.ReadLine();

                try
                {
                    switch (input3)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n (1) Prevents unauthorized access.");
                            Console.WriteLine(" (2) Protects personal information.");
                            Console.WriteLine(" (3) Reduces identity theft risk.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ResetColor();

                            Console.ReadLine();
                            phase2();
                            return;
                        case "2":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n Use strong passwords, enable 2FA, don’t reuse passwords, use a password manager.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ResetColor();
                            Console.ReadLine();

                            phase2();
                            return;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n A strong password should include 12+ characters, uppercase & lowercase letters, numbers, and symbols.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ResetColor();

                            Console.ReadLine();
                            phase2();
                            return;
                        case "4":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n Common mistakes: Using short passwords, reusing passwords, writing them down.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ResetColor();
                            Console.ReadLine();
                            phase2();
                            return;
                        case "5":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n Additional security: Use passphrases, monitor account activity, enable account recovery options.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ResetColor();
                            Console.ReadLine();
                            phase2();
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Invalid option selected. Please choose a number between 1 and 5.");
                            Console.ResetColor();
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n Error: {ex.Message}");
                    Console.ResetColor();
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(" Do you want to try again? (yes or no)");
                        Console.ResetColor();

                        control = Console.ReadLine()?.ToLower();
                    }
                    while (control != "yes" && control != "no");

                    if (control == "yes") continue;
                    else
                    {
                        phase2();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Unexpected error: {ex.Message}");
                    Console.ResetColor();
                    phase2();
                    return;
                }
            }
        }
        static void phishing()
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            TitlesUI("Phishing Awareness");

            Console.WriteLine(" Phishing is a cyber attack tricking people into revealing sensitive data.\n");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($" {name}, Choose a topic:".PadLeft(30));
                Console.ResetColor();

                Console.WriteLine(" ┌─────────────────────────────┐");
                Console.WriteLine(" │ (1) Types                   │");
                Console.WriteLine(" │ (2) Dangers                 │");
                Console.WriteLine(" │ (3) Protection Tips         │");
                Console.WriteLine(" └─────────────────────────────┘");
                string input4 = Console.ReadLine();

                try
                {
                    switch (input4)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n Types: Email Phishing, Spear Phishing, Vishing, Smishing, Clone Phishing.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ResetColor();

                            Console.ReadLine();
                            phase2();
                            return;
                        case "2":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n Dangers: Data theft, malware spread, financial loss.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ResetColor();

                            Console.ReadLine();
                            phase2();
                            return;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("\n Protection: Check sender email, avoid suspicious links, enable 2FA.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ResetColor();

                            Console.ReadLine();
                            phase2();
                            return;
                        default:
                            throw new ArgumentException("Invalid option selected. Please choose a number between 1 and 3.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n Error: {ex.Message}");
                    Console.ResetColor();
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(" Do you want to try again? (yes or no)");
                        Console.ResetColor();

                        control = Console.ReadLine()?.ToLower();
                    }
                    while (control != "yes" && control != "no");

                    if (control == "yes") continue;
                    else
                    {
                        phase2();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Unexpected error: {ex.Message}");
                    Console.ResetColor();
                    phase2();
                    return;
                }
            }
        }
        static void safe()
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            TitlesUI("Safe Browsing");
            Console.WriteLine(" Safe Browsing protects users from harmful websites and downloads.\n");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($" {name}, Choose a topic:".PadLeft(30));
                Console.ResetColor();

                Console.WriteLine(" ┌─────────────────────────────┐");
                Console.WriteLine(" │ (1) Features                │");
                Console.WriteLine(" │ (2) How to Enable           │");
                Console.WriteLine(" │ (3) Tips                    │");
                Console.WriteLine(" └─────────────────────────────┘");
                string input5 = Console.ReadLine();

                try
                {
                    switch (input5)
                    {
                        case "1":
                            Console.WriteLine("\n Features: Phishing protection, malware detection, HTTPS encryption.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ReadLine();
                            phase2();
                            return;
                        case "2":
                            Console.WriteLine("\n How to Enable: Adjust browser security settings in Chrome, Firefox, Edge, Safari.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ReadLine();
                            phase2();
                            return;
                        case "3":
                            Console.WriteLine("\n Tips: Check URLs, avoid suspicious links, keep browser updated.");
                            System.Console.WriteLine("Press any key to return to main menu");
                            Console.ReadLine();
                            phase2();
                            return;
                        default:
                            throw new ArgumentException("Invalid option selected. Please choose a number between 1 and 3.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n Error: {ex.Message}");
                    Console.ResetColor();
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(" Do you want to try again? (yes or no)");
                        Console.ResetColor();
                        control = Console.ReadLine()?.ToLower();
                    }
                    while (control != "yes" && control != "no");

                    if (control == "yes") continue;
                    else
                    {
                        phase2();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Unexpected error: {ex.Message}");
                    Console.ResetColor();
                    phase2();
                    return;
                }
            }
        }
        static void intro()
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n Welcome\n".PadLeft(40));
            Console.ResetColor();

            //the audio name Greetiings,,we removed a single i for test purposes
            string audioFilePath = @"C:\\Users\\tshia\\source\\repos\\ProgA1_ST10070515_PartOne\\Greetiings.wav";

            try
            {
                SoundPlayer player = new SoundPlayer(audioFilePath);
                player.PlaySync();
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error playing audio: " + ex.Message);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string logo = @"
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000008899999999880000000000000000000000000000000000000000000000000000000000
000000000000000000000000000000000000000000000089645317              713246980000000000000000000000000000000000000000000000000
0000000000000000000000000000000000000000089651    7712546998888896642317    7269800000000000000000000000000000000000000000000
00000000000000000000000000000000000000892    72680000009240043900000866800951    16880000000000000000000000000000000000000000
00000000000000000000000000000000000047   1600853008668061508276000091231682480092    2800000000000000000000000000000000000000
00000000000000000000000000000000847  758800598370973318888933515844862368812869808861   2800000000000000000000000000000000000
00000000000000000000000000000093  759806111608370843260888861 29933908800812891771800861  14000000000000000000000000000000000
000000000000000000000000000063  3680009790879837000000061400516085598316081286 31 9064009446258000000000000000000000000000000
0000000000000000000000000063  398008942 24218837009320847400516089980000081280937986069091395 1480000000000000000000000000000
00000000000000000000000092  390095694688969008370091282711404398271758000812800278860690800085  16000000000000000000000000000
0000000000000000000000847 1689489358009280008617909328577140000857774800867398027892056938846893  280000000000000000000000000
00000000000000000000092  58089980009980000001 23 493208439009980062608882722 288800002982086560847 19000000000000000000000000
0000000000000000000061 1600088988004 19000007389729320000092  7480008359339813896000098088999880093 7400000000000000000000000
000000000000000000047 380061 737 76084 3800085776086800093      748008808577580578948085741625328085  58000000000000000000000
00000000000000000847 2800472994682 60085 380083300000861   7592    2900008158002785790279719214338084  2800000000000000000000
0000000000000085265 2800057443415956800082 50080000827   14800092    168000800475800004984486499680084  580000000000000000000
000000000000008456528096895635857459095800880000951    3680000000951   726800088008500139 7637551900085 740000000000000000000
000000000000000093396358000843335800089000008627    1590000000000008627    34900008900913659445160008882 76000000000000000000
00000000000000857160063148000000000000089621     1590000000000000000008637    734680000092262248009214093 3900000000000000000
0000000000000067 2889986116892685333688      73480000000008899980000000000951      20000000000008572900047 400000000000000000
000000000000082 19477719915800000000008   29000000000000857     16800000000000841  200658846862373947 2883 390000000000000000
000000000000067 2061  39869800006259008   90000000000084   26963  760000000000002  200080088008000913515047 40000000000000000
00000000000004 760086128000000057427900   9000000000086  280000091 76000000000003  500000000000000861398093 28000000000000000
00000000000082 1800091288644449827758007  6000000000082 7600000005  4800000000003  400477728477777773900082 19000000000000000
00000000000093 3063691280000000000000001  500000000008946800000009649000000000007  600000000000088800096805 76000000000000000
0000000000008656089885111111111111116802  30000000085111111111111111114800000009   800888377288631129088809449000000000000000
0000000000000888094900000000000000000006   8000000083       77        5800000005  1000233 257689642 3544908880000000000000000
00000000000091 30949980000000000000000087  5000000082      58082      4000000087  5000000922600843269422604776000000000000000
00000000000093 30088698964444444444498005   800000006     740085     1900000004   8000444444444446800089805 76000000000000000
00000000000082 199680937244444444444980007  2000000082     16047     5800000087  58000444444444451758042905 19000000000000000
00000000000084 760092758000000004174800006   6000000093    30093    2800000003  180000617400000008937580093 38000000000000000
000000000000067 5857280085777744754 7728005   9000000093  758885   2800000002   900477 56 59177728086314061 50000000000000000
000000000000093 3888008572699988431580000002  790000000847       16800000085   680000041158899962728088885 160000000000000000
000000000000084 74008513980944444444444490002  7400000000841   368000000083   6800644444444444490927580061 280000000000000000
0000000000000092 19923600931255555555555900084   2800000000089800000000061  19000845555555555549000923682 7600000000000000000
00000000000000067 580009215808899800000085600097  7480000000000000000092   280064800000000000000635800047 5800000000000000000
00000000000000085 7408275808577777290084738000085   768000000000000892   1680008374800913333333409316085 39000000000000000000
000000000000000082 16898006412444515680480851800082    5880000000893   7680091480812009 9522263500088884260000000000000000000
0000000000000000093 1695689526999935980004 3000000085    14800092    1600000083 4800009 93771435092682 7600000000000000000000
00000000000000000093 16008852699993598000730008510000863    77     2980008360005 800009 7777777500093 76000000000000000000000
000000000000000000082 7480966666666698868730082  2888008843    72980089808160004 8860021111111139091 160000000000000000000000
0000000000000000000085  290864444449857587300877379618000008669800000516853329000089086666666666947 3900000000000000000000000
000000000000000000000861 168088000847390073000844908689524900000088809982149118928000758000880093  58000000000000000000000000
0000000000000000000000082  296488473988007300009680008275730948004360888413375800009725320865857 1600000000000000000000000000
000000000000000000000000061  5882368063803169082 9000093 1905160955904760811900094841886 80847 748000000000000000000000000000
00000000000000000000000000041  5900089808773 582 9089806120051605  5847608138968960057719847  5800000000000000000000000000000
0000000000000000000000000000067  39894808772 582 9857606120051609329047608138888890000085   500000000000000000000000000000000
000000000000000000000000000000093   580008888082 90080094600516093290476081380059000067  768000000000000000000000000000000000
000000000000000000000000000000000847  7290004682 98438000000516093290476081380000857   59000000000000000000000000000000000000
000000000000000000000000000000000000941   159009688579063500516093290476086989537  159800000000000000000000000000000000000000
0000000000000000000000000000000000000008651   735498880846009480866808896521   7248000000000000000000000000000000000000000000
0000000000000000000000000000000000000000000894217    71332222222233177    135680000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000008965233111777711133254680000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
            ";
            Console.WriteLine(logo);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Title = "Cyber Security Awareness";
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            string title = @"
                                     /$$$$$$  /$$     /$$ /$$$$$$$  /$$$$$$$$ /$$$$$$$       
                                    /$$__  $$|  $$   /$$/| $$__  $$| $$_____/| $$__  $$      
                                   | $$  \__/ \  $$ /$$/ | $$  \ $$| $$      | $$  \ $$      
                                   | $$        \  $$$$/  | $$$$$$$ | $$$$$   | $$$$$$$/      
                                   | $$         \  $$/   | $$__  $$| $$__/   | $$__  $$      
                                   | $$    $$    | $$    | $$  \ $$| $$      | $$  \ $$      
                                   |  $$$$$$/    | $$    | $$$$$$$/| $$$$$$$$| $$  | $$      
                                    \______/     |__/    |_______/ |________/|__/  |__/      

                          /$$$$$$  /$$$$$$$$  /$$$$$$  /$$   /$$ /$$$$$$$  /$$$$$$ /$$$$$$$$ /$$     /$$        
                         /$$__  $$| $$_____/ /$$__  $$| $$  | $$| $$__  $$|_  $$_/|__  $$__/|  $$   /$$/        
                        | $$  \__/| $$      | $$  \__/| $$  | $$| $$  \ $$  | $$     | $$    \  $$ /$$/         
                        |  $$$$$$ | $$$$$   | $$      | $$  | $$| $$$$$$$/  | $$     | $$     \  $$$$/          
                         \____  $$| $$__/   | $$      | $$  | $$| $$__  $$  | $$     | $$      \  $$/           
                         /$$  \ $$| $$      | $$    $$| $$  | $$| $$  \ $$  | $$     | $$       | $$            
                        |  $$$$$$/| $$$$$$$$|  $$$$$$/|  $$$$$$/| $$  | $$ /$$$$$$   | $$       | $$            
                         \______/ |________/ \______/  \______/ |__/  |__/|______/   |__/       |__/            

                    /$$$$$$  /$$      /$$  /$$$$$$  /$$$$$$$  /$$$$$$$$ /$$   /$$ /$$$$$$$$  /$$$$$$   /$$$$$$              
                   /$$__  $$| $$  /$ | $$ /$$__  $$| $$__  $$| $$_____/| $$$ | $$| $$_____/ /$$__  $$ /$$__  $$             
                  | $$  \ $$| $$ /$$$| $$| $$  \ $$| $$  \ $$| $$      | $$$$| $$| $$      | $$  \__/| $$  \__/             
                  | $$$$$$$$| $$/$$ $$ $$| $$$$$$$$| $$$$$$$/| $$$$$   | $$ $$ $$| $$$$$   |  $$$$$$ |  $$$$$$              
                  | $$__  $$| $$$$_  $$$$| $$__  $$| $$__  $$| $$__/   | $$  $$$$| $$__/    \____  $$ \____  $$             
                  | $$  | $$| $$$/ \  $$$| $$  | $$| $$  \ $$| $$      | $$\  $$$| $$       /$$  \ $$ /$$  \ $$             
                  | $$  | $$| $$/   \  $$| $$  | $$| $$  | $$| $$$$$$$$| $$ \  $$| $$$$$$$$|  $$$$$$/|  $$$$$$/             
                  |__/  |__/|__/     \__/|__/  |__/|__/  |__/|________/|__/  \__/|________/ \______/  \______/              

                                               /$$$$$$$   /$$$$$$  /$$$$$$$$  
                                              | $$__  $$ /$$__  $$|__  $$__/  
                                              | $$  \ $$| $$  \ $$   | $$     
                                              | $$$$$$$ | $$  | $$   | $$     
                                              | $$__  $$| $$  | $$   | $$     
                                              | $$  \ $$| $$  | $$   | $$     
                                              | $$$$$$$/|  $$$$$$/   | $$     
                                              |_______/  \______/    |__/   







            
            ";
            Console.WriteLine(title);
            Console.ResetColor();
            Margins("=");
        }
        static void phase1()
        {
            //Console.Clear();
            Margins("-");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" Im here to assist you, feel free to ask anything\n".PadLeft(50));
            Console.ResetColor();
            string anyQ = Console.ReadLine()?.ToLower();

            try
            {
                if (string.IsNullOrWhiteSpace(anyQ))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentException("Input cannot be empty or null.");
                    Console.ResetColor();
                }

                switch (anyQ)
                {
                    case "hi":
                    case "hello":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"\n Hi There {name}".PadLeft(40));
                        Console.WriteLine($" That was a great start {name}, in the question below only select the number next to the topic you choose".PadLeft(60));
                        System.Console.WriteLine("Press any key to return to main menu");
                        Console.ResetColor();
                        Console.ReadLine();

                        phase2();
                        break;
                    case "how are you":
                    case "how are you?":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"\n Am well and yourself {name}?".PadLeft(45));
                        Console.WriteLine($" That was a great start {name}, in the question below only select the number next to the topic you choose".PadLeft(60));
                        System.Console.WriteLine("Press any key to return to main menu");
                        Console.ResetColor();
                        Console.ReadLine();

                        phase2();
                        break;
                    case "what is your purpose":
                    case "what is your purpose?":
                    case "what's your purpose":
                    case "what's your purpose?":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"\n Well {name}, My mission is to inform you in Cybersecurity and some related topics".PadLeft(55));
                        Console.WriteLine($" That was a great start {name}, in the question below only select the number next to the topic you choose".PadLeft(60));
                        System.Console.WriteLine("Press any key to return to main menu");
                        Console.ResetColor();

                        Console.ReadLine();
                        phase2();
                        break;
                    case "what can i ask you about":
                    case "what can i ask you about?":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"\n Well {name}, Password Security, phishing and safe browsing".PadLeft(50));
                        Console.WriteLine($" That was a great start {name}, in the question below only select the number next to the topic you choose".PadLeft(60));

                        System.Console.WriteLine("Please wait as I load the next step...........");

                        System.Console.WriteLine("Press any key to return to main menu");
                        Console.ResetColor();

                        Console.ReadLine();
                        phase2();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new ArgumentException("I didn’t understand your input.");
                        Console.ResetColor();
                }
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n Error: {ex.Message}");
                Console.ResetColor();
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($" Am really sorry {name}, I seem unable to understand you".PadLeft(50));
                    Console.WriteLine(" Would you like to try again? (yes or no)".PadLeft(45));
                    Console.ResetColor();
                    control = Console.ReadLine()?.ToLower();
                }
                while (control != "yes" && control != "no");

                if (control == "yes") phase1();
                else phase2();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Unexpected error: {ex.Message}");
                Console.ResetColor();
                phase2();
            }
        }
        public static void phase2()
        {
            //Console.Clear();
            Margins("=");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" Would you like to look into related topics such as:".PadLeft(50));
            Console.ResetColor();
            Console.WriteLine(" ┌─────────────────────────────────────┐");
            Console.WriteLine(" │ (1) Password Security               │");
            Console.WriteLine(" │ (2) Phishing                        │");
            Console.WriteLine(" │ (3) Safe Browsing                   │");
            Console.WriteLine(" | (4) Ask your own questions(Part 2)  |");
            Console.WriteLine(" | (5) Start Quiz (POE_GUI)            |");
            Console.WriteLine(" │ (6) Exit Terminate                  │");
            Console.WriteLine(" └─────────────────────────────────────┘");

            while (true)
            {
                string menuInput = Console.ReadLine();

                try
                {
                    switch (menuInput)
                    {
                        case "1":
                            passwordSafety();
                            return;
                        case "2":
                            phishing();
                            return;
                        case "3":
                            safe();
                            return;
                        case "4":
                            CyberChatbot bot = new CyberChatbot(name);
                            bot.StartConversation();
                            return;
                        case "5":
                            Process.Start("C:\\Users\\tshia\\source\\repos\\ProgPart2POE\\POE_POE\\POE_POE\\bin\\Debug\\net8.0-windows\\POE_POE.exe");
                            return;
                        case "6":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($"\n It's sad to see you leave, I hope you learned something interesting, until next time {name}".PadLeft(60));
                            Console.ResetColor();
                            Thread.Sleep(500);
                            Environment.Exit(0);
                            return;
                        default:
                            throw new ArgumentException("Invalid option selected. Please choose a number between 1 and 4.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n Error: {ex.Message}");
                    Console.ResetColor();
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(" Do you want to try again? (yes or no)".PadLeft(40));
                        Console.ResetColor();

                        control = Console.ReadLine()?.ToLower();
                    }
                    while (control != "yes" && control != "no");

                    if (control == "yes") continue;
                    else
                    {
                        terminator();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Unexpected error: {ex.Message}");
                    Console.ResetColor();
                    terminator();
                    return;
                }
            }
        }
        static void terminator()
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\n It's sad to see you leave, {name}. I hope you learned something new.".PadLeft(55));
            Console.ResetColor();
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        static void Margins(string character)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string(character[0], 80));
            Console.ResetColor();
        }
        static void TitlesUI(string title)
        {
            int width = title.Length + 4;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($" ┌{new string('─', width)}┐");
            Console.WriteLine($" │  {title}  │");
            Console.WriteLine($" └{new string('─', width)}┘");
            Console.ResetColor();
        }
    }

}
