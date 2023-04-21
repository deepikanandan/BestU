
using System.Windows;
using System.Windows.Input;

// We need the following for JSON parsing + HTTP requests
using System;
using System.Text;
using System.Text.Json;
using System.Net.Http;




namespace BestU_v0._0._1

//namespace Calender
{
    public partial class CalendarWindow : Window
    {
        public CalendarWindow()
        {
            InitializeComponent();  
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNote.Focus();
        }

        private void lblTime_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtTime.Focus();
        }

        private void txtNote_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text) && txtNote.Text.Length > 0)
                lblNote.Visibility = Visibility.Collapsed;
            else
                lblNote.Visibility = Visibility.Visible;
        }

        private void txtTime_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTime.Text) && txtTime.Text.Length > 0)
                lblTime.Visibility = Visibility.Collapsed;
            else
                lblTime.Visibility = Visibility.Visible;
        }

        private void addHabitButton_Click(object sender, RoutedEventArgs e)
        {
            var todoName = txtNote.Text;
            ToDo h1;
            if (habitRadioButton.IsChecked == true)
            {
                h1 = new Habit(todoName);
                MessageBox.Show("New HABIT: " + h1.Name);
            }
            else if (singleToDoRadioButton.IsChecked == true)
            {
                h1 = new SingleToDo(todoName);
                MessageBox.Show("New TODO for today: " + h1.Name);
            }
            else
            {
                MessageBox.Show("Please specific the type of task [ongoing HABIT or SINGLE todo]");
                return;
            }



            // Serialize habit as JSON
            var h1_json = JsonSerializer.Serialize(h1);
            var h1_content = new StringContent(h1_json, Encoding.UTF8, "application/json");

            // Create HTTP Client assigned to our API
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            // Make POST request using JSON object + receive response
            var response = client.PostAsync("posts", h1_content).Result;

            // Parse response and print (if it's successful response of course! Otherwise, print the error status code)
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var postResponse = JsonSerializer.Deserialize<PostResponse>(responseContent, options);
                Console.WriteLine("SUCCESS!\nID: " + postResponse.Id);
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
            
        


        }
    }
}
