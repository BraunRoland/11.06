namespace Algoritmus
{
    internal class Program
    {
        static List<int> lista = new List<int>();
        static int[] tomb = new int[] { };
        static Random rnd = new Random();

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



        static void Listak()
        {
            lista = [];
            tomb = [];
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
