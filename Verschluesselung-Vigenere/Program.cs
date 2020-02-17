using System;

namespace Verschluesselung_Vigenere {
    class Program {
        static void Main(string[] args) {
            int offset = 65;
            string klartext = "DAS IST DAS HAUS VON HAUS DAS IST DAS".Replace(" ","");            
            string keyString = "BITLC";
            int[] intArrayKlartextNormalisiert = IntArrayKlartextNormalisiert(klartext, offset);
            int[] expandedKey = ExpandKey(keyString, klartext.Length, offset);

            string verschluesselt = Encrypt(intArrayKlartextNormalisiert, expandedKey, offset);
            Console.WriteLine(verschluesselt);
            Console.ReadLine();
        }

        // verschlüsselt mit dem Vigenere-Algorithmus
        static string Encrypt(int[] klartextNormalisiert, int[] expandedKeyNormalisiert, int offset) {
            int[] intErgebnisArray = new int[klartextNormalisiert.Length];
            char[] charErgebnisArray = new char[intErgebnisArray.Length] ;

            for (int i = 0; i < klartextNormalisiert.Length; i++) {
                intErgebnisArray[i] = ((klartextNormalisiert[i] + expandedKeyNormalisiert[i]) % 26) + offset;
                //Console.WriteLine(intErgebnisArray[i]);
            }

            for (int i = 0; i < charErgebnisArray.Length; i++) {
                charErgebnisArray[i] = (char) (intErgebnisArray[i]);
            }          
            return new string(charErgebnisArray);
        }



        // liefert ein int-Array des Klartextes - um offset normalisiert
        static int[] IntArrayKlartextNormalisiert(string klartext, int offset) {
            char[] charArrayKlartext = klartext.ToCharArray();
            int[] intArrayKlartext = new int[klartext.Length];

            for (int i = 0; i < charArrayKlartext.Length; i++) {
                intArrayKlartext[i] = (int) charArrayKlartext[i] - offset;
            }
            return intArrayKlartext;
        }


        // liefert ein int-Array um offset normalisiert 
        static int[] ExpandKey(string key, int length, int offset) {
            int[] intArrayExpandedKey = new int[length];
            char[] charArrayKey = key.ToCharArray();
            int[] intArrayKey = new int[key.Length];
            int j = 0, i = 0 ;

            while (i < length) {
                while( j < key.Length && i < length) {
                    intArrayExpandedKey[i] = charArrayKey[j]-offset;
                    i++;
                    j++;
                }
                j = 0;
            } 
            return intArrayExpandedKey;
        }
    }
}
