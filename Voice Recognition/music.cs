﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Voice_Recognition
{
    class music
    {

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwdCallBack);

        public void open(string File)
        {
            string Format = @"open ""{0}"" type MPEGVideo Alias MediaFile";
            string command = string.Format(Format, File);
            mciSendString(command, null, 0, 0);
        }
        public void play()
        {
            string command = "play MediaFile";
            mciSendString(command, null, 0, 0);
        }
        public void stop()
        {
            string command = "stop MediaFile";
            mciSendString(command, null, 0, 0);
        }
    }
}
