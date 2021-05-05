using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
 


{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int minutes;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;

            SetUpGame();
            



        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            minutes--;
            timeTextBlock.Text = minutes.ToString("01s");
            if (matchesFound == 8 || minutes == 0)
            {
                timer.Stop();
                timeTextBlock.Text = "Time: " + timeTextBlock.Text + "\nPlay again? 💮";
                


            }
            
            
        }
        

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {


                "🦊", "🦊",
                "🐱", "🐱",
                "🐕","🐕",
                "🦍", "🦍",
                "🐮", "🐮",
                "🦄", "🦄",
                "🐷", "🐷",
                "🐭", "🐭",









        };

            

















            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
             
                }
                timer.Start();
                matchesFound = 0;
                minutes = 150;
               

               

            }

        }
        TextBlock lastClickedTextBlock;
        bool isMatch = false;

        private void TextBlock_mouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            
            if (isMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastClickedTextBlock = textBlock;
                isMatch = true;
            } 
            else if (textBlock.Text == lastClickedTextBlock.Text )
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                isMatch = false;
                
            }
           
            else
            {
                lastClickedTextBlock.Visibility = Visibility.Visible;
                isMatch = false;
            }

        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8 )
            {


                SetUpGame();


            }
             
        }
    }
}
