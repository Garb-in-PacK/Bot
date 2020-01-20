using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using System.ComponentModel;
using System.Threading;


namespace DicBot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ITelegramBotClient botClient;
        static string FilePath = "F.txt";
        static ReplyKeyboardMarkup rkm;
        short count = 0;
        StringRes Res;
        List<string> ids = new List<string>();
       
        public MainWindow()
        {
            InitializeComponent();
        Res = (StringRes)this.Resources["Res"];
        Closing += OnWindowClosing;
        }


        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            try
            {
                using (StreamWriter fileW = new StreamWriter(FilePath, false))
                {
                    foreach ( string line in ids)
                    fileW.WriteLine(line);
                }
            }
            catch (Exception )
            {
                
            }
        }
        private void StartBot(object sender, RoutedEventArgs e)
        {
            string token = "";
            var dialog = new InputBotToken();
            if (dialog.ShowDialog() == true)
            {
                token = dialog.ResponseText;
            }

            botClient = new TelegramBotClient(token);








            Button d = sender as Button;
            d.IsEnabled = false;
            var me = botClient.GetMeAsync().Result;
            Res.Log = "Hello, World! I am user " + me.Id + " and my name is " + me.FirstName + "\r\n";
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            rkm = new ReplyKeyboardMarkup();
            rkm.Keyboard =
         new KeyboardButton[][]  
       {  
        new KeyboardButton[]  
        {  
            new KeyboardButton("Сайт колледжа"),  
            new KeyboardButton("Штампы")  
        },  
          new KeyboardButton[]  
        {  
            new KeyboardButton("Курсы")  ,
             new KeyboardButton("/start")  
        }  ,
         new KeyboardButton[]  
        {  
         
             new KeyboardButton("Показать колледж на карте")  
        }  
       };
            string line;
            try { 
            using (StreamReader sr = new StreamReader(FilePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    ids.Add(line);
                    count++;
                }

            }}
        catch(Exception)
    {
        Res.Log += "File not found!  \r\n";
    }
            Res.CountFollower = Convert.ToString(count);
          
           

        }

        void wart(bool detected, MessageEventArgs eee)
        {
            

        
            if (detected)
            {
                count++;
                try
                {
                   ids.Add(Convert.ToString( eee.Message.Chat.Id));
                   Res.Log += "User " + eee.Message.Chat.Id + " " + eee.Message.Chat.FirstName + " " + eee.Message.Chat.LastName + " " + eee.Message.Chat.Username + " " + eee.Message.Chat.Description + " " + " registred " + eee.Message.Date + "\r\n";
                    Res.CountFollower = Convert.ToString(count);
                }
                catch (Exception ee)
                {
                    Res.Log += ee.Message + " Exception" + "\r\n";
                }
            }


        }
        private  void Init(object sender, MessageEventArgs e)
        {



            bool detected = true;
           
            try
            {
                   foreach (string line in ids)
                    {
                     
                        if (line == Convert.ToString(e.Message.Chat.Id))
                        {
                            Res.Log += "User " + e.Message.Chat.Id + " " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + " " + e.Message.Chat.Username + " " + e.Message.Chat.Description + " " + " already registred "+ e.Message.Date+ " " + e.Message.Text +  "\r\n";
                            detected = false; 
                        }
                    }

            }
            catch (Exception ee)
            {
               Res.Log += ee.Message + " Exception" + "\r\n";
            }
            
            wart(detected, e);
        }
        async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Init(sender, e);
            if (e.Message.Text != null)
            {
                Message t = new Message();

                switch (e.Message.Text)
                {
                    case "/start": { await botClient.SendTextMessageAsync(e.Message.Chat.Id, "Вас приветствует бот Индустриального колледжа!", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, rkm); } break;
                    case "Сайт колледжа": { t.Text = @"https://www.inc.dp.ua"; } break;
                    case "Штампы":
                        {
                            t.Text = @"http://chertezh.by/wp-content/uploads/2017/01/Ramki-A4-Word.zip ";
                        } break;
                    case "Курсы": { t.Text = "Інформацію про курси можете отримати за телефоном (056)767-71-47"; } break;
                    case "Показать колледж на карте": { t.Text = @" https://www.google.com.ua/maps/place/Днепровский+Индустриальный+Колледж/@48.4767891,34.9868486,18.17z/data=!4m8!1m2!2m1!1z0LjQvdC00YPRgdGC0YDQuNCw0LvRjNC90YvQuSDQutC-0LvQu9C10LTQtg!3m4!1s0x0:0x7c24d1d11807b4c1!8m2!3d48.476563!4d34.9873352"; } break;

                }




                try
                {
                    // long t = Convert.ToInt64(line);
                    await botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat.Id,
                      text: t.Text
                    );
                }
                catch (Exception )
                {
                  

                }
            }
        }

        private async void SendMessage(object sender, RoutedEventArgs e)
        {
          
               
               foreach (string line in ids)
                {
                    try
                    {
                        long t = Convert.ToInt64(line);
                        await botClient.SendTextMessageAsync(
                          chatId: t,
                          text: Textbox.Text
                        );
                    }
                    catch (Exception)
                    {

                        Res.Log += "User " + line + ": message not delivered" + "\r\n";
                    }
                }
            }
        

        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}