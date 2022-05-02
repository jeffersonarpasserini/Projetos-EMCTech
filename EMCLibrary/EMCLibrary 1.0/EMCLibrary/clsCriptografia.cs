using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCLibrary
{
    public class clsCriptografia
    {
        public string Encode(string Data)
        {
            return Encode(Data, 0);
        }

        //Encripta uma string
        public string Encode(string Data, int Depth)

        {
	        char TempChar ;
	        int TempAsc = 0;
	        byte[] NewData = null;
	        int vChar = 0;
            var encoder = System.Text.Encoding.GetEncoding(1252);

            NewData = new byte[Data.Length];

	        for (vChar = 0; vChar <= (Data.Length - 1); vChar++) 
            {
		        TempChar = Convert.ToChar(Data.Substring(vChar, 1));
		        TempAsc = Asc(TempChar);
		        if (Depth == 0)
			        Depth = 40;
		        //DEFAULT DEPTH
		        if (Depth > 254)
			        Depth = 254;

		        TempAsc = TempAsc + Depth;
		        if (TempAsc > 255)
			        TempAsc = TempAsc - 255;
                NewData[vChar] = Convert.ToByte(TempAsc);
	        }
            return encoder.GetString(NewData);
        }
        
        public string Decode(string Data)
        {
            return Decode(Data, 0);
        }

        //decriptação dos dados codificados
        public string Decode(string Data, int Depth)
        {
            char TempChar;
            int TempAsc = 0;
            byte[] NewData = null;
            int vChar = 0;
            System.Text.ASCIIEncoding decoder = new System.Text.ASCIIEncoding();

            NewData = new byte[Data.Length];

	        for (vChar = 0; vChar <= (Data.Length - 1); vChar++) 
            {
		        TempChar = Convert.ToChar(Data.Substring(vChar, 1));
                TempAsc = Convert.ToChar(TempChar);
		        if (Depth == 0)
			        Depth = 40;
		        //DEFAULT DEPTH
		        if (Depth > 254)
			        Depth = 254;
		        TempAsc = TempAsc - Depth;
		        if (TempAsc < 0)
			        TempAsc = TempAsc + 255;
                NewData[vChar] = Convert.ToByte(TempAsc);
	        }

            return decoder.GetString(NewData);
        }
    
        public char Chr(int codigo)
        {
        return (char)codigo;
        }

        public int Asc(char letra)
        {
        return (int)(Convert.ToChar(letra));
        }    

    }
}
