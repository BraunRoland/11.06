namespace Algoritmus
{
    internal class Program
    {
        static Random rnd = new Random();
        static int[] hossz = new int[] {10,100,500,1000,10000,50000};
        static string[] fajlNevek = new string[] {"Egyszeru","Bubble","Quick","Insertion","Radix"};

        static void SortEgyszeru()
        {
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                for (int j = i + 1; j < tomb.Length; j++)
                {
                    if (tomb[i] > tomb[j])
                    {
                        int seged = tomb[i];
                        tomb[i] = tomb[j];
                        tomb[j] = seged;
                    }
                }
            }
        }

        static void SortBubble()
        {
            for (int i = tomb.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tomb[j] > tomb[j + 1])
                    {
                        int tmp = tomb[j + 1];
                        tomb[j + 1] = tomb[j];
                        tomb[j] = tmp;
                    }
                }
            }
        }

        static void SortQuick_Array(int also, int felso)
        {
            int i = also, j = felso;
            int kozep = tomb[(felso + also) / 2];
            while (also <= felso)
            {
                while (also < j && tomb[also] < kozep)
                    also++;
                while (felso > i && tomb[felso] > kozep)
                    felso--;
                if (also <= felso)
                {
                    int tmp = tomb[also];
                    tomb[also] = tomb[felso];
                    tomb[felso] = tmp;
                    ++also;
                    --felso;
                }
            }
            if (also < j) SortQuick_Array(also, j);
            if (i < felso) SortQuick_Array(i, felso);
        }

        static void SortQuick_List(int also, int felso)
        {
            int i = also, j = felso;
            int kozep = lista[(felso + also) / 2];
            while (also <= felso)
            {
                while (also < j && lista[also] < kozep)
                    also++;
                while (felso > i && lista[felso] > kozep)
                    felso--;
                if (also <= felso)
                {
                    int tmp = lista[also];
                    lista[also] = lista[felso];
                    lista[felso] = tmp;
                    ++also;
                    --felso;
                }
            }
            if (also < j) SortQuick_List(also, j);
            if (i < felso) SortQuick_List(i, felso);
        }

        static void SortQuick()
        {
            
        }

        static void SortInsertion()
        {
            for (int i = 1; i < tomb.Length; i++)
            {
                int tmp = tomb[i];
                int j = i - 1;

                while (j >= 0 && tomb[j] > tmp)
                {
                    tomb[j + 1] = tomb[j];
                    j--;
                }
                tomb[j + 1] = tmp;
            }
        }

        static void SortRadix_Array()
        {
            int n = tomb.Length;

            int[] zeros = new int[n];
            int[] ones = new int[n];
            for (int bit = 0; bit < 32; bit++)
            {
                int zeroCount = 0;
                int oneCount = 0;
                for (int i = 0; i < n; i++)
                {
                    int bitValue = (tomb[i] >> bit) & 1;

                    if (bitValue == 0)
                    {
                        zeros[zeroCount] = tomb[i];
                        zeroCount++;
                    }
                    else
                    {
                        ones[oneCount] = tomb[i];
                        oneCount++;
                    }
                }
                int index = 0;
                for (int i = 0; i < zeroCount; i++)
                    tomb[index++] = zeros[i];

                for (int i = 0; i < oneCount; i++)
                    tomb[index++] = ones[i];
            }
        }

        static void SortRadix_List()
        {
            for (int bit = 0; bit < 32; bit++)
            {
                List<int> zeros = new List<int>();
                List<int> ones = new List<int>();

                foreach (int num in lista)
                {
                    int bitValue = (num >> bit) & 1;

                    if (bitValue == 0)
                        zeros.Add(num);
                    else
                        ones.Add(num);
                }
                int index = 0;

                foreach (int num in zeros)
                    lista[index++] = num;

                foreach (int num in ones)
                    lista[index++] = num;
            }
        }

        static void SortRadix()
        {

        }

        static int[] TombFeltoltes(int n)
        {
            int[] tomb = new int[n];
            for (int i = 0; i < n; i++)
            {
                tomb[i] = rnd.Next(0, 100001);
            }
            return tomb;
        }

        static List<int> Listafeltoltes(int n)
        {
            List<int> lista = new List<int>();
            for (int i = 0; i < n; i++)
            {
                lista.Add(rnd.Next(0, 100001));
            }
            return lista;
        }

        static void Listak()
        {
            lista = [];
            tomb = [];
        }

        static void FileTorles(string fajlNev)
        {
            string path = fajlNev+".txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        static void FileIras(bool boolean, string fajlNev)
        {
            StreamWriter sw = new StreamWriter(fajlNev + ".txt", true);
            if (boolean == true)
            {
                sw.WriteLine("Lista elemek száma;Lista mérésének ideje(ms);Tömb elemek száma;Tömb mérésének ideje(ms)");
            }
            else 
            {
                sw.WriteLine();
            }
            sw.Close();
        }



        static void Main(string[] args)
        {
            FileTorles();
        }
    }
}
