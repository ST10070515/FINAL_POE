    using ASCII;

    namespace Memo{
        public class CyberChatbot
        {
            private string userName;
            private string userInterest;
            private readonly Dictionary<string, int> topicCounter = new();
            private readonly Dictionary<string, List<string>> randomTipPool = new();
            private readonly Dictionary<string, Action> randomTips = new();
            private readonly Dictionary<string, string> staticTopics = new();
            private readonly Dictionary<string, string> sentimentPhrases = new();
            private readonly Dictionary<string, Dictionary<string, string>> topicQuestions = new();             
            readonly List<ResponseHandler> pipeline = new();       
            private readonly Random rng = new();
            public delegate bool ResponseHandler(string input);

            public CyberChatbot(string name)
            {
                userName = name;
                InitializeData();
            }
            private void InitializeData()
            {
                staticTopics["password"] = "Use strong passwords, don’t reuse them, and enable 2FA.";
                staticTopics["scam"] = "Watch out for phishing links, too-good-to-be-true offers, and fake emails.";
                staticTopics["privacy"] = "Limit personal data sharing and check your account permissions regularly.";

                staticTopics["passwords"] = staticTopics["password"];
                staticTopics["scams"] = staticTopics["scam"];
                staticTopics["privacies"] = staticTopics["privacy"];


                sentimentPhrases["worried"] = "It's okay to be worried. Cybersecurity can be tricky, but I'm here to help!";
                sentimentPhrases["frustrated"] = "I'm sorry you're feeling that way. Let’s take it step by step.";
                sentimentPhrases["curious"] = "Great! Curiosity is the first step toward being cyber smart!";


                randomTipPool["phishing"] = new List<string>
            {
                "Be cautious with email links — hover before clicking.",
                "Verify sender addresses carefully.",
                "Watch for spelling errors and urgent language.",
                "Never share sensitive info by email.",
                "Enable spam filters and keep antivirus updated."
            };

                randomTipPool["password"] = new List<string>
            {
                "Use complex passwords with symbols and numbers.",
                "Never reuse the same password.",
                "Use a password manager.",
                "Change passwords regularly.",
                "Enable two-factor authentication."
            };

                randomTipPool["browsing"] = new List<string>
            {
                "Use HTTPS-secured websites.",
                "Avoid public Wi-Fi or use a VPN.",
                "Keep browsers and extensions up to date.",
                "Block pop-ups and malicious ads.",
                "Don’t download from untrusted sources."
            };

                randomTipPool["device"] = new List<string>
                {
                    "Keeping devices updated to patch vulnerabilities exploited by malware or hackers.",
                    "Installing reputable antivirus software and enabling firewalls for real-time protection",
                    "Securing smartphones with biometric locks, PINs, or patterns and encrypting sensitive data."

                };

                topicQuestions["password"] = new Dictionary<string, string> 
            {
                { "what", "A password is a secret string used to secure accounts." },
                { "why", "Strong passwords help prevent unauthorized access." },
                { "how", "Use symbols, numbers, and avoid common words." }
            };

                topicQuestions["scam"] = new Dictionary<string, string>
            {
                { "what", "A scam is a fraudulent attempt to steal personal info." },
                { "why", "Scammers trick people into revealing sensitive info." },
                { "how", "Avoid clicking unknown links and verify sources." }
            };

                topicQuestions["privacy"] = new Dictionary<string, string>
            {   
                { "what", "Privacy is about protecting your personal data." },
                { "why", "To prevent misuse of your identity or habits." },
                { "how", "Limit sharing online and adjust account settings." }
            };

                foreach (var topic in randomTipPool.Keys)
                {
                    randomTips[topic] = () =>
                    {
                        var tips = randomTipPool[topic];
                        var tip = tips[rng.Next(tips.Count)];
                        Console.WriteLine($"💡 Tip: {tip}");
                    };
                }

                pipeline.Add(SentimentCheck);
                pipeline.Add(RandomTip);
                pipeline.Add(TopicDefinition);
                pipeline.Add(ShowMemory);
                pipeline.Add(FollowUpInterest);
            }
            public void StartConversation()
            {
                Console.WriteLine($" Hi {userName}, ask me anything about cybersecurity!(Type 'exit' to main menu where you can terminate program)");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("You: ");
                    Console.ResetColor();
                    string input = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrWhiteSpace(input)) continue;
                    if (input == "exit" || input == "bye") break;

                    bool handled = false;
                    foreach (var handler in pipeline)
                    {
                        handled = handler.Invoke(input) || handled;
                    }

                    if (!handled)
                    {
                        DialogueFallback(input);
                    }
                }

                Console.WriteLine("\nWould you like to return to the main menu? (yes/no)");
                var back = Console.ReadLine()?.ToLower();

                if (back == "yes")
                {
                    Program.phase2();
                }
            }
            private bool SentimentCheck(string input)
            {
                foreach (var sentiment in sentimentPhrases)
                {
                    if (input.Contains(sentiment.Key))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($" {sentiment.Value}");
                        Console.ResetColor();
                        return true;
                    }
                }
                return false;
            }
            private bool TopicDefinition(string input)
            {
                foreach (var topic in staticTopics)
                {
                    if (input.Contains(topic.Key))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" {staticTopics[topic.Key]}");
                        Console.ResetColor();

                        userInterest = topic.Key;
                        if (!topicCounter.ContainsKey(topic.Key)) topicCounter[topic.Key] = 0;
                        topicCounter[topic.Key]++;
                        return true;
                    }
                }
                return false;
            }
            private bool RandomTip(string input)
            {
                foreach (var tip in randomTips)
                {
                    if (input.Contains("tip") && input.Contains(tip.Key))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        tip.Value.Invoke();
                        Console.ResetColor();
                        return true;
                    }
                }
                return false;
            }
            private bool ShowMemory(string input)
            {
                if (input.Contains("memory") || input.Contains("stats"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" Memory Summary:");
                    Console.WriteLine($"- Name: {userName}");
                    if (!string.IsNullOrWhiteSpace(userInterest))
                        Console.WriteLine($"- Interest: {userInterest}");
                    foreach (var kvp in topicCounter)
                    {
                        Console.WriteLine($"- {kvp.Key} mentioned {kvp.Value} time(s)");
                    }
                    Console.ResetColor();
                    return true;
                }
                return false;
            }
            private bool FollowUpInterest(string input)
            {
                if ((input.Contains("more") || input.Contains("tell me")) && !string.IsNullOrWhiteSpace(userInterest))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Here's more on {userInterest}:");
                    Console.ResetColor();
                    return TopicDefinition(userInterest);
                }
                return false;
            }
            private void DialogueFallback(string input)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("🤖 I didn’t quite understand that. Try asking about passwords, scams, or privacy.");
                Console.ResetColor();
            }
        }
        
        
     }