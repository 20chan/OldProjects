//#define DEBUGING

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Microsoft.Speech.Synthesis;
using Microsoft.Speech.Recognition;

namespace Assistant_Manager
{
    public enum CommandType
    {
        [StringValue("비어 있음")]
        NONE,
        [StringValue("음성 인식")]
        VOICE,
        [StringValue("핫키")]
        HOTKEY
    }
    public struct cmd
    {
        public string text;
        public CommandType type;
    }

    public class Command
    {
        public Dictionary<string, List<Work>> workList = new Dictionary<string, List<Work>>();
        public List<cmd> Commands = new List<cmd>();
        public CMD_VOICE Command_Voice = new CMD_VOICE();

        public string fileName = "cmd_Lists.txt";

        public Command()
        {
            //LoadCommands();
        }

        public void AddWork(CommandType type, string cmd, Work work)
        {

        }
        
        public void EditWork(CommandType type, string command, int index, Work work)
        {

        }

        public void SaveCommands()
        {

        }

        public void DeleteCommand(CommandType type, string text)
        {

        }

        public void LoadCommands()
        {
            Command_Voice.LoadCommands();
        }

        public void DoWork(string workName)
        {

        }
    }

    public abstract class Cmd
    {
        public CommandType commandType;
        public abstract event EventHandler GetSignal;
    }


    public enum State
    {
        STOP, RECORDING
    }

    public class CMD_VOICE : Cmd
    {
        public List<string> Commands = new List<string>();

        SpeechSynthesizer sSynth;
        PromptBuilder pBuilder;
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();

        public State state = State.STOP;

        public CMD_VOICE()
        {
            this.commandType = CommandType.VOICE;
            //StartRecord();
        }
        public void SaveCommands()
        {
            try
            {
                using (FileStream f = new FileStream(Main_Form.mainForm.command.fileName, FileMode.Create))
                using (StreamWriter sr = new StreamWriter(f, System.Text.Encoding.Default))
                {
                    foreach (string cmd in Commands)
                    {
                        sr.WriteLine("?" + cmd);
                        List<Work> ws = Main_Form.mainForm.command.workList[cmd];
                        foreach (Work w in ws)
                        {
                            sr.WriteLine(w.workType.ToString());
                            switch (w.workType)
                            {
                                case WorkType.OPEN:
                                    {
                                        string line = ((WORK_OPEN)w).program + "?" + ((WORK_OPEN)w).args;
                                        sr.WriteLine(line);
                                        break;
                                    }

                                case WorkType.SENDKEY:
                                    {
                                        sr.WriteLine(((WORK_SENDKEY)w).keys);
                                        break;
                                    }
                                case WorkType.SAY:
                                    {
                                        sr.WriteLine(((WORK_SAY)w).Text);
                                        break;
                                    }
                                case WorkType.CLOSE:
                                case WorkType.START:
                                case WorkType.STOP:
                                    {
                                        break;
                                    }
                                default:
                                    {
#if DEBUGING
                                    System.Windows.Forms.MessageBox.Show("Commands.cs 에서 파일 저장중 인식치 못한 WorkType : " + w.workType.ToString(), "디버그!!");
#endif
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "오류", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public void LoadCommands()
        {
            Commands.Clear(); Main_Form.mainForm.command.workList = new Dictionary<string, List<Work>>();
            try
            {
                using (FileStream f = new FileStream(Main_Form.mainForm.command.fileName, FileMode.Open))
                using (StreamReader sr = new StreamReader(f, System.Text.Encoding.Default))
                {
                    string currentCmd = string.Empty;
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        if (line.StartsWith("?"))
                        {
                            currentCmd = line.Split('?')[1];
                        }
                        else
                        {
                            WorkType type = (WorkType)System.Enum.Parse(typeof(WorkType), line);
                            Work work;
                            switch (type)
                            {
                                case WorkType.OPEN:
                                    {
                                        string[] l = sr.ReadLine().Split('?');
                                        work = new WORK_OPEN(l[0], l[1]);
                                        AddWork(currentCmd, work);
                                        break;
                                    }
                                case WorkType.CLOSE:
                                    {
                                        work = new WORK_CLOSE();
                                        AddWork(currentCmd, work);
                                        break;
                                    }
                                case WorkType.SENDKEY:
                                    {
                                        work = new WORK_SENDKEY(sr.ReadLine());
                                        AddWork(currentCmd, work);
                                        break;
                                    }
                                case WorkType.START:
                                    {
                                        work = new WORK_START();
                                        AddWork(currentCmd, work);
                                        break;
                                    }
                                case WorkType.STOP:
                                    {
                                        work = new WORK_STOP();
                                        AddWork(currentCmd, work);
                                        break;
                                    }
                                case WorkType.SAY:
                                    {
                                        work = new WORK_SAY(sr.ReadLine());
                                        AddWork(currentCmd, work);
                                        break;
                                    }
                                default:
                                    {
#if DEBUGING
                                        System.Windows.Forms.MessageBox.Show("Commands.cs 에서 파일 로드중 인식치 못한 WorkType : " + type.ToString(), "디버그!!");
#endif
                                        break;
                                    }
                            }
                        }

                    }
                }
            }
            catch (FileNotFoundException)
            {
                SaveCommands();
                LoadCommands();
            }
        }

        public void AddCommand(string command)
        {
            if (Commands.Contains(command)) return;
            Commands.Add(command);
            List<Work> ws = new List<Work>();
            Main_Form.mainForm.command.workList.Add(command, ws);
        }

        public void AddWork(string command, Work work)
        {
            foreach (string c in Commands)
            {
                if (command == c)
                {
                    Main_Form.mainForm.command.workList[command].Add(work);
                    return;
                }
            }
            Commands.Add(command);
            List<Work> ws = new List<Work>();
            ws.Add(work);
            Main_Form.mainForm.command.workList.Add(command, ws);
            Main_Form.mainForm.command.Commands.Add(new cmd() { text = command, type = CommandType.VOICE });
        }

        public void EditWork(string command, int indexOfWork, Work work)
        {
            Main_Form.mainForm.command.workList[command][indexOfWork] = work;

            /*
            for (int i = 0; i <= Commands.Count - 1; i++)
            {
                if(Commands[i] == oldCmd)
                {
                    Main_Form.mainForm.command.workList[Commands[i]] = work;
                    Commands[i] = command;
                    Main_Form.mainForm.command.workList.Remove(oldCmd);
                    Main_Form.mainForm.command.workList[command] = work;
                    return;
                }
            }*/
#if DEBUGING
            System.Windows.Forms.MessageBox.Show("수정할 명령어가 없습니다!", "오류", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
#endif
            return;
        }

        public void DeleteCommand(string command)
        {
            Main_Form.mainForm.command.workList.Remove(command);
            Commands.Remove(command);
        }
        public void StartRecord()
        {
                //if (state == State.RECORDING) { MessageBox.Show("이미 녹음중입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                state = State.RECORDING;
                if (this.sRecognize != null)
                    this.sRecognize.Dispose();

                this.sRecognize = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ko-KR"));
                this.sSynth = new SpeechSynthesizer();
                this.sSynth.SelectVoice("Microsoft Server Speech Text to Speech Voice (ko-KR, Heami)");
                this.sSynth.SetOutputToDefaultAudioDevice();
                this.pBuilder = new PromptBuilder();
                Choices sList = new Choices();
                sList.Add(Commands.ToArray());
                Grammar gr = new Grammar(new GrammarBuilder(sList));
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += SRecognize_SpeechRecognized;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
           
        }
        private void SRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (state == State.RECORDING)
            {
                foreach (Work w in Main_Form.mainForm.command.workList[e.Result.Text])
                    w.DoWork();
            }
            else if (Main_Form.mainForm.command.workList[e.Result.Text][0].workType == WorkType.START)
            {
                foreach (Work w in Main_Form.mainForm.command.workList[e.Result.Text])
                    w.DoWork();
            }
            
        }


        public override event EventHandler GetSignal;


       

        private void StopRecord()
        {
            state = State.STOP;
            sRecognize.RecognizeAsyncStop();
        }

        public void Reload()
        {
            Choices sList = new Choices();
            sList.Add(Commands.ToArray());
            Grammar gr = new Grammar(new GrammarBuilder(sList));
            sRecognize.LoadGrammar(gr);
        }

        public void Say(string text)
        {
            this.sSynth.SpeakAsync(text);
            Main_Form.mainForm.Show(text);
        }
    }
}