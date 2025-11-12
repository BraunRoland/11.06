using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Algoritmus
{
    internal class Program
    {
        static string[] fajlNevek = { "egyszeru.csv", "buborekos.csv", "gyors.csv", "beilleszteses.csv", "szamolasos.csv" };
        static Stopwatch stw = new Stopwatch();
        static StreamReader sr;
        static StreamWriter sw;
        static Random rnd = new Random();

        static int[] randomTomb(int meret, int maxSzam)
        {
            int[] tomb = new int[meret];
            for (int i = 0; i < meret; i++)
            {
                tomb[i] = rnd.Next(1, maxSzam + 1);
            }
            return tomb;
        }

        static List<int> randomLista(int meret, int maxSzam)
        {
            List<int> lista = new List<int>();
            for (int i = 0; i < meret; i++)
            {
                lista.Add(rnd.Next(1, maxSzam));
            }
            return lista;
        }

        static long[] Egyszeru(int[] tomb, List<int> lista)
        {
            int seged;
            long[] meresek = new long[2];

            stw.Start();
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                for (int j = i + 1; j < tomb.Length; j++)
                {
                    if (tomb[i] > tomb[j])
                    {
                        seged = tomb[i];
                        tomb[i] = tomb[j];
                        tomb[j] = seged;
                    }
                }
            }
            stw.Stop();
            meresek[0] = stw.ElapsedMilliseconds;

            stw.Reset();
            stw.Start();
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (lista[i] > lista[j])
                    {
                        seged = lista[i];
                        lista[i] = lista[j];
                        lista[j] = seged;
                    }
                }
            }
            stw.Stop();
            meresek[1] = stw.ElapsedMilliseconds;
            stw.Reset();
            return meresek;
        }

        static long[] Buborekos(int[] tomb, List<int> lista)
        {
            long[] meresek = new long[2];
            int seged;

            stw.Start();
            for (int i = tomb.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tomb[j] > tomb[j + 1])
                    {
                        seged = tomb[j+1];
                        tomb[j+1] = tomb[j];
                        tomb[j] = seged;
                    }
                }
            }
            stw.Stop();
            meresek[0] = stw.ElapsedMilliseconds;

            stw.Reset();
            stw.Start();
            for (int i = tomb.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tomb[j] > tomb[j + 1])
                    {
                        seged = tomb[j + 1];
                        tomb[j + 1] = tomb[j];
                        tomb[j] = seged;
                    }
                }
            }
            stw.Stop();
            meresek[1] = stw.ElapsedMilliseconds;

            return meresek;
        }

        static void Gyors()
        {

        }

        static void Beilleszteses()
        {

        }

        static void Szamolasos()
        {

        }

        static void FajlIras(string fajlNev, int meret, long[] meresek)
        {
            sw = new StreamWriter(fajlNev, true);
            sw.WriteLine($"{meret};{meresek[0]};{meret};{meresek[1]}");
            sw.Close();
        }

        static void FajlÜrites(string fajlNev)
        {
            sw = new StreamWriter(fajlNev, false);
            sw.Write(String.Empty);
            sw.Close();

        }

        static void Feladat()
        {
            int[] maxSzam = { 10, 100, 1000, 10000, 100000 };
            int[] meret = { 10, 100, 1000, 10000, 100000 };
            long[] meresek = new long[2];
            for (int i = 0; i< maxSzam.Length;i++)
            {
                meresek = Egyszeru(randomTomb(meret[i], maxSzam[i]), randomLista(meret[i], maxSzam[i]));
                sw = new StreamWriter(fajlNevek[0], true);
                sw.WriteLine("Tömb Mérete;Tömb mérésének ideje (ms);Lista Mérete;Lista mérésének ideje (ms)");
                sw.Close();
                FajlIras(fajlNevek[0], meret[i], meresek);

            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < fajlNevek.Length; i++)
            {
                FajlÜrites(fajlNevek[i]);
            }
            Feladat();

        }
    }
}
