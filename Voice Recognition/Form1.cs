using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Media;
using System.Threading;
using System.IO;

using MySql.Data.MySqlClient;





namespace Voice_Recognition
{
    public partial class Form1 : Form
    {
 
        

        bool playmusic;
        private bool isCollapsed;
        int mov;
        int movX;
        int movY;

        Data data = new Data();
        email em = new email();
        Setting st = new Setting();
        //String name = label1.Text;

       // String Appname = "Sojeb Assistant";
        String Appname = "Sais";

        SoundPlayer _sp;
         music Player = new music();
        [DllImport("user32")]
       

        public static extern void LockWorkStation();
        bool search = false;
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        
        SpeechSynthesizer voice;
        public Form1()
        {

            recEngine.SpeechRecognized +=  new EventHandler<SpeechRecognizedEventArgs>(recEngine_SpeechRecognized);
            

           // Thread t = new Thread(new ThreadStart(SplashScreen));
          //  t.Start();
           // Thread.Sleep(1000);
           // t.Abort();


            SpeechRecognitionEngine reconizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            reconizer.SetInputToDefaultAudioDevice();
           // RecognitionResult Result = reconizer.Recognize();

            //string ResultString = "hey";
            // add all recognized words to the result string
            /*
            foreach (RecognizedWordUnit w in Result.Words)
            {
                ResultString += w.Text;
            }
            */

            reconizer.LoadGrammar(new DictationGrammar());
            
            reconizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(reconizer_reconized);
            reconizer.RecognizeAsync(RecognizeMode.Multiple);

            

            InitializeComponent();
            
        }

       // public void SplashScreen()
      //  {

          //  Application.Run(new startup());
      //  }
        bool toggle =true;
        private void btn_enable_Click(object sender, EventArgs e)
        {
            
            if (toggle == false)
            {
                btn_enable.BackColor = Color.Green;
                //btn_enable.Text = "Enabled";
                recEngine.RecognizeAsync(RecognizeMode.Multiple);
            

                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("Enable");
                richTextBox1.Text += "\n Voice Recognition Enable";
                toggle = true;
            }
            else if(toggle==true)
            {
                btn_enable.BackColor = Color.Red;
                //btn_enable.Text = "Disabled";
                recEngine.RecognizeAsyncStop();
              

                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("Disable");
                richTextBox1.Text += "\n Voice Recognition Disable";
                toggle = false;
            }
            
        }

        noti bbl_old = new noti();

        // User Message Bubble Creation
        public void addInMessage(string message)
        {
            // Create new chat bubble
            noti bbl = new noti(message, msgtype.In);
           // bbl.Location = noti1.Location; // Set the new bubble location from the bubble sample.
            bbl.Location = noti1.Location;
           // bbl.Left += 50; // Indent the bubble to the right side.
            bbl.Size = noti1.Size; // Set the new bubble size from the bubble sample.
          //  bbl.Top = bbl_old.Bottom + 10; // Position the bubble below the previous one with some extra space.
            bbl.BackColor = noti1.BackColor;
            // Add the new bubble to the panel.
            panel1.Controls.Add(bbl);

            // Force Scroll to the latest bubble
            bbl.Focus();

            // save the last added object to the dummy bubble
            bbl_old = bbl;
        }

        // Bot Message Bubble Creation
        /*
        public void addOutMessage(string message)
        {
            // Create new chat bubble
            noti bbl = new noti(message, msgtype.Out);
            bbl.Location = noti1.Location; // Set the new bubble location from the bubble sample.
            bbl.Size = noti1.Size; // Set the new bubble size from the bubble sample.
            bbl.Top = bbl_old.Bottom + 10; // Position the bubble below the previous one with some extra space.

            // Add the new bubble to the panel.
            panel1.Controls.Add(bbl);

            // Force Scroll to the latest bubble
            bbl.Focus();

            // save the last added object to the dummy bubble
            bbl_old = bbl;
        }
        */
        private void Form1_Load(object sender, EventArgs e)
        {



            string source = "server=remotemysql.com;user id=mzBXch0LSO;password =Qz0NXr8Dt8 ;database=mzBXch0LSO;allowuservariables=True";

                MySqlConnection con = new MySqlConnection(source);
                con.Open();
                // MessageBox.Show("Connected");
               // string query = "select * from voice where id=" + int.Parse(txtID.Text);
                string query = "select * from voice";

                MySqlCommand cmd = new MySqlCommand(query, con);

                MySqlDataReader dr = cmd.ExecuteReader();
               /* if (dr.Read())
                {
                    String com = (dr["text"].ToString());
                    String res = (dr["response"].ToString());
                    // }
                    //con.Close();
                * */

           //     dr.Read();

              //  String com = (dr["text"].ToString());
               //     String res = (dr["response"].ToString());
                    // }
                    //con.Close();





                    //this.WindowState = FormWindowState.Minimized;
                    // this.ShowInTaskbar = false;

                    noti1.Hide();
                    //notification

                    /*
                    notifyIcon1.Icon = SystemIcons.Application;
                    notifyIcon1.BalloonTipText = "Your Form has been minimized";
                    notifyIcon1.ShowBalloonTip(1000);
                    */



                    TextBoxCom.Focus();

                    this.Location = Screen.AllScreens[0].WorkingArea.Location;
                    webBrowser1.Hide();
                    snamestore.Hide();


                    //recEngine.LoadGrammar(new Grammar(DictationGrammar()));
                    voice = new SpeechSynthesizer();
                   
                    while (dr.Read())
                    {
                        var coms = dr["text"].ToString();
                        Grammar comd = new Grammar(new GrammarBuilder(new Choices(coms)));
                        recEngine.LoadGrammarAsync(comd);

                    }
                    dr.Close();
                    con.Close();

                    Choices commands = new Choices();
                    //..........assistive command......
                    commands.Add(new string[] {"com",Appname+" add command","add command","add mny order","hey " + Appname,"hello " + Appname, "show " + Appname, "hide " + Appname });
                    //.........windows commad
                    commands.Add(new string[] { "open remote", "lock the computer", "open photoshop", "close the application", "open calculator", "open microsoft word", "open microsoft excel", "open microsoft powerpoint", "open chrome", "open paint", "notepad", "shutdown the computer", "restart the computer" });
                    commands.Add(new string[] { "show setting", "show note", "show my note", "add note", "note", "roll a dice", "toss", "flip a coin", "stop song", "what is my ip address", "close the browser", "change the music", "stop the music", "google", "haule haule", "im fine", "google", "stop this", "search for", "sojebsoft", "developer facebook", "what time is it", "open", "show trick", "download", "mail" });
                    //.........conversation...............
                    commands.Add(new string[] { "database", "can you speak bangla", "tumar naam ki", "hey jarvis", "what about you", "bingo", "im good", "change my name", "can i change my name", "what is my name", "hello", "play a music", "when you are created", "sing me a song", "can you change your voice", "im also good", "how are you", "how do you feel", "why you dont have any feel", "who are you", "what can you do", "what language are used to create you", "show command", "who created you", "what is your name", "say hello", "print my name", "computer", "dictation", });
                    //...............
                    GrammarBuilder gBuilder = new GrammarBuilder();
                    gBuilder.Append(commands);
                    Grammar grammer = new Grammar(gBuilder);
                    DictationGrammar dg = new DictationGrammar();

                    //  recEngine.LoadGrammar(dg);
                    // recEngine.RecognizeAsync();

                    
                    recEngine.LoadGrammarAsync(grammer);
                    recEngine.SetInputToDefaultAudioDevice();
                   // recEngine.SpeechRecognized += recEngine_SpeechRecognized;

                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("Welcome to " + Appname);
                    richTextBox1.Text += "\n Welcome to " + Appname;

                    recEngine.RecognizeAsync(RecognizeMode.Multiple);
               // } con.Close();
        }
         void reconizer_reconized(object sender, SpeechRecognizedEventArgs f)
        {
           
             //richTextBox1.Text +="\n"+f.Result.Text ;
             while (search == true )
             {
                 recEngine.RecognizeAsync(RecognizeMode.Multiple);
                 if (f.Result.Text == f.Result.Text)
                 {
                     Process.Start("https://www.google.com/search?q=" + f.Result.Text);
                     search = false;
                 }
             }


        }
         
        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string source = "server=remotemysql.com;user id=mzBXch0LSO;password =Qz0NXr8Dt8 ;database=mzBXch0LSO;allowuservariables=True";

            MySqlConnection con = new MySqlConnection(source);
            con.Open();
            // MessageBox.Show("Connected");
            // string query = "select * from voice where id=" + int.Parse(txtID.Text);
            string query = "select * from voice";

            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader dr = cmd.ExecuteReader();
            /* if (dr.Read())
             {
                 String com = (dr["text"].ToString());
                 String res = (dr["response"].ToString());
                 // }
                 //con.Close();
             * */

          



            if (File.Exists("data.xml"))
            {
                data = XmlManager.XmlDataReader("data.xml");

                string names = data.Name;

            }


            email em = new email();
            Setting st = new Setting();
            //String name = snamestore.Text;
            String name = data.Name;
            string spe = e.Result.Text;
            //String vc = voicelab.Text;

            if (snamestore.Text == "")
            {
                richTextBox1.Text += "\n Would you like to set your nick name";
                richTextBox1.Text += "\n if yes.then sey 'change my name'";
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("\n please change your name, If you change you name then say change my name");
            }
            /*
            if (spe == "search for")
            {
                search = true;
                richTextBox1.Text += "\n "+e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("what you want to search");

            }
            if (search)
            {
                Process.Start("https://www.google.com/search?q=" + spe);
                search = false;
            }
            */

           // if (search == false)
            var soundsRoot = @"e:\music\wav";
            var rand = new Random();
            var soundFiles = Directory.GetFiles(soundsRoot, "*.wav");
            var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
            System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(playSound);
           string ai = e.Result.Text;
            note nt = new note();
            
            
            //player1.Play()
            //String.IsNullOrEmpty(TextBoxCom.Text="hello")

            /*
                   case "":
                   richTextBox1.Text += "\n"+e.Result.Text;
                  voice.SelectVoiceByHints(VoiceGender.Female);
                  voice.SpeakAsync("");
                  break;
             * 
             * 
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("hello sir");
                      
                   */
            /*
             * if (ai == "")
            {
                
            }
             * */
            while (dr.Read())
            {

                String com = (dr["text"].ToString());
                String res = (dr["response"].ToString());

                if (ai == com)
                {
                    richTextBox1.Text += "\n" + e.Result.Text;
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync(res);
                }
                //voice.Volume = 100;
            }
            if (ai == "add command " || ai == Appname+" add command" || ai == "add my order")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("Okk sir. here it is");

                cmd.add add = new cmd.add();
                add.Show();
                
            }

            if (ai == "show "+Appname)
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("hey sir");
            }

            if (ai == "can you speak bangla")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("naa, ami baangla bolthee paari naa");
            }
            if(ai=="tumar naam ki")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("amaar naam "+Appname);
            }

            if (ai == "hey " + Appname || ai == "hello " + Appname)
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("hey sir");
            }

            if (ai == "show " + Appname)
            {
                this.WindowState = FormWindowState.Normal;
            }

            if (ai == "hide " + Appname)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            
            if(ai=="hey jarvis")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("hello sir. But my name is "+Appname);
            }
            if (ai=="show setting")
            {
                Setting sg = new Setting();
                sg.Show();
            }
         
            if (ai == "add note" || ai == "show my note" || ai == "note" )
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("here is note");
                nt.Show();
            }
            if (ai == "roll a dice")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("");


                Random randomdice = new Random();
                int randnumberdice = randomdice.Next(0, 7);
                voice.SpeakAsync(randnumberdice.ToString());
                richTextBox1.Text += "\n" + randnumberdice.ToString();
            }
            if(ai == "toss" || ai=="flip a coin")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("");

                string[] coin = { "Head", "Tale" };
                Random random = new Random();
                int randnumber = random.Next(0, coin.Length);
                //Convert.ToString(randnumber);

                if (randnumber == 0)
                {
                    voice.SpeakAsync("Head");
                    richTextBox1.Text += "\n" + "Head";
                }


                else if (randnumber == 1)
                {
                    voice.SpeakAsync("Tale");
                    richTextBox1.Text += "\n" + "Tale";
                }
            }

            if (ai == "close the browser")
            {
                richTextBox1.Text += "\n" + TextBoxCom.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);

                webBrowser1.Hide();
                voice.SpeakAsync("browser was closed");
            }
//..........................................music command...............................
            if (ai == "stop song")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("");
                if (playmusic == true)
                {
                    player1.Stop();
                    voice.SpeakAsync("music stopped");

                }
                else
                {
                    richTextBox1.Text += "\n" + "music are not playing";
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("music are not playing");

                }
            }

            

            if (ai == "play a music")
            {
                playmusic = true;
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("playing a music");
                player1.Play();

            }
            if (ai == "pause the music")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);

                player1.Stop();
                voice.SpeakAsync("stopped");
            }
            if (ai == "change the music")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("playing a music");
                player1.Play();

            }

            //..........................music end command...............................
            if (ai == "im fine")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("oh its great");
            }

                    if(ai == "google")
            {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("what you want to search");
                    richTextBox1.Text += "\n" + "what you want to search";
                    search = true;

            }
                    if(ai == "stop this")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("stoping");
                        richTextBox1.Text += "\n" + "stoped";
                        SendKeys.Send("%{F4}");
                    }


                    if (ai == "developer facebook")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("opening developer facebook id");
                        richTextBox1.Text += "\n" + "opening developer facebook id";
                        Process.Start("http://facebook.com/sojebsikder");
                    }

                    if(ai =="what time is it")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        richTextBox1.Text += "\n" + DateTime.Now.ToLongTimeString();
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("Current time is " + DateTime.Now.ToLongTimeString());
                        richTextBox1.Text += "\n" + "Current time is " + DateTime.Now.ToLongTimeString();

                        time time = new time(DateTime.Now.ToLongTimeString());
                
                        time.Show();
                    }

                    if(ai =="browser")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("hello im browser");
                    }

                    if(ai== "show trick")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("");
                        this.backgroundWorker1.RunWorkerAsync();

                    }

                    if (ai == "download")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("enter url");
                        download dw = new download();
                        dw.Show();

                    }

                    if(ai== "mail")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("here it is");
                        em.Show();
                    }

                    if(ai== "open photoshop")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("photoshop opening");
                        Process.Start("photoshop");
                    }

                    if(ai== "change my name")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("yeah sure");
                        st.Show();
                    }

                    if(ai== "can i change my name")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("yeah sure.");
                        //Setting st = new Setting(); 
                        st.Show();
                    }

                    if(ai== "what is my name")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("your name is " + name);
                    }

                    if(ai == "hello")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("hello" + name);
                    }
            


                //........... windows command.......................................................
            if(ai=="open remote")
            {
                richTextBox1.Text += "\n" + e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("shutting down your computer");
                Process.Start( "C:\\Program Files (x86)\\Mouse Server\\MouseServer.exe");
            }         
                    if (ai == "shutdown the computer")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("sorry my sir don't to do this");
                        //Process.Start("shutdown", "/s /t 0");

                    }

                    if(ai== "restart the computer")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("restarting your computer");
                        Process.Start("shutdown", "/r /t 0");
                    }

                    if(ai== "lock the computer")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("please wait ");
                        LockWorkStation();
                    }

                    if(ai== "what is my ip address")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("this is your ip address");
                        IPHostEntry host;
                        string localIp = "?";
                        host = Dns.GetHostEntry(Dns.GetHostName());

                        foreach (IPAddress ip in host.AddressList)
                        {
                            localIp = ip.ToString();
                            richTextBox1.Text += "\n" + localIp;

                        }

                    }

                    

                    if(ai== "show command")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("here it is");
                        MessageBox.Show("");
                    }
                        //end windows command....................................................

             // open pogram......................................................................
                    if(ai== "open calculator")
                    {
                        Process.Start("calc");
                    }

                    if(ai== "open microsoft word")
                    {
                        Process.Start("winword");
                    }

                    if(ai== "open microsoft excel")
                    {
                        Process.Start("excel");
                    }
                    if(ai== "open microsoft powerpoint")
                    {
                        Process.Start("powerpoint");
                    }
                    if(ai== "open paint")
                    {
                        Process.Start("mspaint");
                    }
                    if(ai== "notepad")
                    {
                        Process.Start("notepad");
                    }
                    if (ai== "open chrome")
                    {
                        Process.Start("chrome");
                    }

                        //end open program...........................................................

            //..........Conversation.................................................................
            



                    if(ai== "im good")
                    {
                        // MessageBox.Show("hello im computer");
                        richTextBox1.Text += "\nhello sojeb";
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("it's pleasure to me");
                    }

                    if(ai == "say hello")
                     {
                        // MessageBox.Show("hello im computer");
                        richTextBox1.Text += "\nhello sojeb";
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("hello sojib");
                     }
                    if(ai== "what is your name")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("my name is " + Appname);

                    }

                    if(ai== "when you are created")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("in 19 November 2018");
                    }

                   

                    if(ai== "can you change your voice")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("hmm. no");
                    }

                    if(ai== "im also good")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("this is pleasure to me");
                    }

                    if(ai== "how are you" || ai=="what about you")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("im great, what about you");
                      
                        
                    }

                    if(ai== "why you dont have any feel")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("because im a robot created by programming language");
                    }

                    if(ai=="how do you feel")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("i have no feel");
                    }

                    if(ai== "who are you")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("im " + Appname + ", your personal assistance");
                    }

                    if(ai== "what can you do")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("this is can i do for you");
                        richTextBox1.Text += "\n1. ";
                    }

                    if(ai== "what language are used to create you")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("c#");
                    }

                    if(ai== "who created you")
                    {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        voice.SpeakAsync("i was created by sojib sikder");
                    }
            if(ai== "close the application")
            {
                        richTextBox1.Text += "\n" + e.Result.Text;
                        richTextBox1.Text += "\n Closing the application...";
                        Application.Exit();
            }
        
           
 // richTextBox1.Text += e.Result.Text;
 //.........................End Conversation..........................................................
  
               
               // search = true;
        /*
            else

            {
                search = true;
                Process.Start("https://www.google.com/search?q=" + spe);
                search = false;
            }
            
            //}
           // else
           // {
               // Process.Start("chrome");
            //}
           // richTextBox1.Text += e.Result.Text.ToString() + Environment.NewLine;
           /* foreach (var process in Process.GetProcessesByName(e.Result.Text))
            {
                
                process.Kill();
              
            
            }
            * */
        
          //   }
               // con.Close();
        }
        
        

       

        private void button1_Click(object sender, EventArgs e)
        {
            
            voice.SelectVoiceByHints(VoiceGender.Female);
            voice.SpeakAsync(richTextBox1.Text);
            //voice.Speak(richTextBox1.Text);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            voice.Pause();
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            voice.Resume();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            Setting st = new Setting(); 
            st.Show();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void progressBar_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_about_Click(object sender, EventArgs e)
        {  
            about at = new about();
            at.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string tw = "hello "+Name;//"/nsojeb sikder";
            for (int i = 0; i < tw.Length; i++)
            {

                Invoke(new MethodInvoker(delegate { richTextBox1.AppendText(tw[i].ToString()); }));
                Thread.Sleep(60);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         

            
            
        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            voice.SpeakAsyncCancelAll();
            Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov == 1)
            {

                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TextBoxCom_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxCom_KeyDown(object sender, KeyEventArgs e)
        {
           /* 
            if (e.KeyData == Keys.Enter && TextBoxCom.TextLength > 0)
            {
                webBrowser1.Hide();
                String name = "sojeb sikder";
                string textcom = TextBoxCom.Text;

                switch (TextBoxCom.Text)
                {
                    /*
                     case "":
                     richTextBox1.Text += "\n"+e.Result.Text;
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("");
                    break;
                      
                     */
            /*
                    case "show setting":
                        //Setting st = new Setting();
                        st.Show();
                        break;

                
                    case "close the application":
                        richTextBox1.Text += "\n" + TextBoxCom.Text;
                        richTextBox1.Text += "\n Closing the application...";
                        Application.Exit();
                        break;
                    default:
                        webBrowser1.Show();
                        webBrowser1.Navigate("https://www.google.com/search?q=" + TextBoxCom.Text);
                        //webBrowser1.Url = "https://www.google.com/search?q=" + TextBoxCom.Text";
                        richTextBox1.Text += TextBoxCom.Text;

                        // Process.Start("https://www.google.com/search?q=" + TextBoxCom.Text);

                        break;


                }

                TextBoxCom.ResetText();
            }
            */
        }

       
             
        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "Your Form has been minimized";
                notifyIcon1.ShowBalloonTip(1000);
            }
                /*
            else if (this.WindowState== FormWindowState.Normal)
            {
                notifyIcon1.BalloonTipText = "Your Form has come beck to normal";
                notifyIcon1.ShowBalloonTip(1000);
            }
            */
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void openSojebAssistantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logo_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void logo_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {

                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void logo_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            Grammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            try
            {
                button1.Text = "Speak Now";
                recognizer.SetInputToDefaultAudioDevice();
                RecognitionResult result = recognizer.Recognize();
                //string ai =result.Text.ToLower();
                if (result.Text.ToLower() == "can you do")
                {
                    if (result.Text.ToLower() == "for me")
                    {
                        MessageBox.Show("yes");
                    }
                  
                }
                richTextBox1.Text += "\n"+result.Text;
                

              
           
            }
            catch (InvalidOperationException exception)
            {
                richTextBox1.Text = String.Format("Could not recognize input from default aduio device. Is a microphone or sound card available?\r\n{0} - {1}.", exception.Source, exception.Message);
            }
            finally
            {
                recognizer.UnloadAllGrammars();
            }   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            commandText cmdt = new commandText();
            cmdt.Show();
        }

       

        
    }
}

       

       
    

