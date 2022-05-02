using System;


namespace MaskedDateEntryControl
{
    public class InvalidDateTextEventArgs : EventArgs
    {

        private string _Message = "" 
            + "Informe com uma data válida ";

        private string _InvalidDateString = "";


        public InvalidDateTextEventArgs(string InvalidDateString) : base()
        {
            _InvalidDateString = InvalidDateString;
        }


        public InvalidDateTextEventArgs(string InvalidDateString, string Message) 
            : this(InvalidDateString)
            {
                _Message = Message;
            }


        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }


        public String InvalidDateString
        {
            get { return _InvalidDateString; }
        }


    }
}
