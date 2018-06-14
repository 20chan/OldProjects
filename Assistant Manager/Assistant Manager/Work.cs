#define DEBUGING

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Assistant_Manager
{
    public enum WorkType
    {
        [StringValue("비어있음")]
        NONE,
        [StringValue("프로그램 실행")]
        OPEN,
        [StringValue("최상위 창 종료")]
        CLOSE,
        [StringValue("키보드 입력")]
        SENDKEY,
        [StringValue("비서 작동 시작")]
        START,
        [StringValue("비서 작동 중지")]
        STOP,
        [StringValue("말하기")]
        SAY,
        [StringValue("화면 캡춰")]
        CAPTURE
    }
    public abstract class Work
    {
        public WorkType workType;
        public abstract void DoWork();
        public abstract void Clear();
        public abstract string info { get; }
    }

    public class WORK_OPEN : Work
    {
        public string program = string.Empty;
        public string args = string.Empty;
        public override string info { get { return program; } }

        public WORK_OPEN(string _program) : this(_program, string.Empty)
        {
        }

        public WORK_OPEN(string _program, string argument)
        {
            this.workType = WorkType.OPEN;
            this.program = _program;
            this.args = argument;
        }

        private void open()
        {
            try
            {
                System.Diagnostics.Process.Start(program, args);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        public override void DoWork()
        {
            open();
        }

        public override void Clear()
        {
            this.program = string.Empty;
            this.args = string.Empty;
        }
    }

    public class WORK_CLOSE : Work
    {
        public WORK_CLOSE()
        {
            this.workType = WorkType.CLOSE;
        }
        public override string info
        {
            get
            {
                return "최상위 창을 종료합니다.";
            }
        }
        public override void Clear()
        {
            return;
        }
        public override void DoWork()
        {
            System.Windows.Forms.SendKeys.Send("(%{F4})");
        }
    }
    
    public class WORK_SENDKEY : Work
    {
        public string keys = string.Empty;

        public override string info
        {
            get
            {
                return keys;
            }
        }

        public WORK_SENDKEY(string keys)
        {
            this.keys = keys;
            this.workType = WorkType.SENDKEY;
        }

        public override void Clear()
        {
            this.keys = string.Empty;
        }

        public override void DoWork()
        {
            System.Windows.Forms.SendKeys.Send(keys);
        }
    }

    public class WORK_START : Work
    {
        public WORK_START()
        {
            this.workType = WorkType.START;
        }

        public override void Clear()
        {
        }

        public override void DoWork()
        {
            Main_Form.mainForm.command.Command_Voice.state = State.RECORDING;
            Main_Form.mainForm.command.Command_Voice.Say("비서 작동을 시작합니다.");
        }

        public override string info
        {
            get
            {
                return "비서 작동을 시작합니다.";
            }
        }
    }

    public class WORK_STOP : Work
    {
        public WORK_STOP()
        {
            this.workType = WorkType.STOP;
        }
        public override void Clear()
        {
        }

        public override void DoWork()
        {
            Main_Form.mainForm.command.Command_Voice.state = State.STOP;
            Main_Form.mainForm.command.Command_Voice.Say("비서 작동을 중지합니다.");
        }

        public override string info
        {
            get
            {
                return "비서 작동을 중지합니다.";
            }
        }
    }

    public class WORK_SAY : Work
    {
        public string Text = string.Empty;
        public WORK_SAY(string text)
        {
            this.workType = WorkType.SAY;
            this.Text = text;
        }

        public override void Clear()
        {
            this.Text = string.Empty;
        }

        public override void DoWork()
        {
            Main_Form.mainForm.command.Command_Voice.Say(Text);
        }

        public override string info
        {
            get
            {
                return Text;
            }
        }
    }
}
