using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace POE_POE
{
    public partial class MainWindow : Window
    {
        private List<string> activityLog = new List<string>();
        private List<TaskItem> tasks = new List<TaskItem>();
        private List<CyberQuizQuestion> quizQuestions;
        private int currentQuizIndex = 0;
        private int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadQuizQuestions();
        }

     
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = ChatInput.Text.ToLower();
            string response = "";

            if (input.Contains("add task") || input.Contains("remind"))
            {
                response = "Would you like to add a task in the Task Assistant section?";
            }
            else if (input.Contains("quiz") || input.Contains("game"))
            {
                response = "Click 'Start Quiz' below to begin the mini-game!";
            }
            else if (input.Contains("password"))
            {
                response = "Strong passwords use a mix of upper/lowercase letters, numbers, and symbols.";
            }
            else if (input.Contains("phishing"))
            {
                response = "Be cautious with emails asking for personal info. Don’t click unknown links.";
            }
            else if (input.Contains("privacy"))
            {
                response = "Review your social media privacy settings regularly.";
            }
            else if (input.Contains("show activity") || input.Contains("what have you done"))
            {
                ShowActivityLog();
                return;
            }
            else
            {
                response = "I'm not sure I understood that. Try asking about passwords, phishing, or tasks.";
            }

            ChatOutput.AppendText($"You: {ChatInput.Text}\nBot: {response}\n\n");
            ChatInput.Clear();
        }

        
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitle.Text;
            string desc = TaskDescription.Text;
            string reminder = TaskReminder.Text;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Task title is required.");
                return;
            }

            string taskInfo = $"{title} - {desc} {(string.IsNullOrWhiteSpace(reminder) ? "" : $"[Reminder: {reminder}]")}";
            TaskList.Items.Add(taskInfo);

            tasks.Add(new TaskItem
            {
                Title = title,
                Description = desc,
                Reminder = reminder
            });

            activityLog.Add($"Task added: {title} {(string.IsNullOrWhiteSpace(reminder) ? "" : $"(Reminder: {reminder})")}");
            ClearTaskInputs();
        }

        private void ClearTaskInputs()
        {
            TaskTitle.Text = "";
            TaskDescription.Text = "";
            TaskReminder.Text = "";
        }

        
        private void ShowActivityLog()
        {
            ActivityLog.Items.Clear();
            var recent = activityLog.TakeLast(10);
            foreach (var entry in recent)
                ActivityLog.Items.Add(entry);
        }

        private void ShowLogButton_Click(object sender, RoutedEventArgs e)
        {
            ShowActivityLog();
        }

        
        private void LoadQuizQuestions()
        {
            quizQuestions = new List<CyberQuizQuestion>
            {
                new CyberQuizQuestion("What should you do with a suspicious email?", new[] { "Open it", "Ignore it", "Report it as phishing", "Reply to it" }, 2),
                new CyberQuizQuestion("True or False: Password123 is a secure password.", new[] { "True", "False" }, 1),
                new CyberQuizQuestion("What is 2FA?", new[] { "Two-Factor Authentication", "Two-Faced Algorithm", "Too Fast Access", "Two-Factor Access" }, 0),
                new CyberQuizQuestion("Where should you store your passwords?", new[] { "In a notebook", "Password manager", "Browser notes", "Sticky notes" }, 1),
                new CyberQuizQuestion("What does phishing often mimic?", new[] { "Friends", "Banks or Companies", "Family", "Games" }, 1),
                new CyberQuizQuestion("True or False: Updating software is a waste of time.", new[] { "True", "False" }, 1),
                new CyberQuizQuestion("A good password includes:", new[] { "Only numbers", "Only letters", "Your birth date", "A mix of characters" }, 3),
                new CyberQuizQuestion("What should you do before clicking on a link?", new[] { "Click quickly", "Hover to preview", "Forward it", "Ignore all links" }, 1),
                new CyberQuizQuestion("Which is safest?", new[] { "123456", "password1", "P@ssw0rd!", "mydog" }, 2),
                new CyberQuizQuestion("True or False: It's safe to use the same password everywhere.", new[] { "True", "False" }, 1),
            };
        }

        private void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            currentQuizIndex = 0;
            score = 0;
            ShowQuestion();
            activityLog.Add("Quiz started.");
        }

        private void ShowQuestion()
        {
            if (currentQuizIndex >= quizQuestions.Count)
            {
                QuizQuestion.Text = $"Quiz complete! You scored {score}/{quizQuestions.Count}";
                QuizOption1.Content = QuizOption2.Content = QuizOption3.Content = QuizOption4.Content = "";
                activityLog.Add($"Quiz finished. Score: {score}/{quizQuestions.Count}");
                return;
            }

            var q = quizQuestions[currentQuizIndex];
            QuizQuestion.Text = q.Question;

            QuizOption1.Content = q.Options.Length > 0 ? q.Options[0] : "";
            QuizOption2.Content = q.Options.Length > 1 ? q.Options[1] : "";
            QuizOption3.Content = q.Options.Length > 2 ? q.Options[2] : "";
            QuizOption4.Content = q.Options.Length > 3 ? q.Options[3] : "";

            QuizProgress.Value = (currentQuizIndex / (double)quizQuestions.Count) * 100;
        }

        private void QuizOption_Click(object sender, RoutedEventArgs e)
        {
            var selectedBtn = sender as Button;
            int selectedIndex = int.Parse(selectedBtn.Name.Last().ToString()) - 1;
            var q = quizQuestions[currentQuizIndex];

            string feedback = selectedIndex == q.CorrectIndex ? "Correct!" : $"Incorrect. Answer: {q.Options[q.CorrectIndex]}";
            QuizResult.Text = feedback;

            if (selectedIndex == q.CorrectIndex)
                score++;

            currentQuizIndex++;
            ShowQuestion();
        }

        
        public class TaskItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Reminder { get; set; }
        }

        public class CyberQuizQuestion
        {
            public string Question { get; }
            public string[] Options { get; }
            public int CorrectIndex { get; }

            public CyberQuizQuestion(string question, string[] options, int correctIndex)
            {
                Question = question;
                Options = options;
                CorrectIndex = correctIndex;
            }
        }
    }
}
