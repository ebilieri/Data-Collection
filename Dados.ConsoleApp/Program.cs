using Dados.Collections;
using System;

namespace Dados.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDadosCollection collection = new DadosCollection();

            //------exemplo1------
            collection.Add("ano.nascimento", 1982, "pedro");
            collection.Add("ano.nascimento", 1983, "maria");
            collection.Add("ano.nascimento", 1982, "joao");
            collection.Add("ano.nascimento", 1983, "maria");// não deve inserir
            collection.Add("ano.nascimento", 1982, "pedro"); // não deve inserir
            collection.Add("ano.nascimento", 1983, "joão");
            collection.Add("ano.nascimento", 1983, "bruno");
            collection.Add("ano.nascimento", 1982, "arnaldo");

            var nascimentos = collection.Get("ano.nascimento", 0, -1);
            Console.WriteLine("Deveria ter 6 elementos: " + nascimentos.Count);
            Console.WriteLine("Deveria ser o elemento 'arnaldo': " + nascimentos[0]);
            Console.WriteLine("Deveria ser o elemento 'joao': " + nascimentos[1]);
            Console.WriteLine("Deveria ser o elemento 'pedro': " + nascimentos[2]);
            Console.WriteLine("Deveria ser o elemento 'bruno': " + nascimentos[3]);
            Console.WriteLine("Deveria ser o elemento 'joao': " + nascimentos[4]);
            Console.WriteLine("Deveria ser o elemento 'maria': " + nascimentos[5]);

            Console.WriteLine();
            //------exemplo2------
            collection.Add("chave", 1, "c");
            collection.Add("chave", 1, "b");
            collection.Add("chave", 1, "a");
            collection.Add("chave", 1, "a"); // não deve inserir elemento


            var list = collection.Get("chave", 0, 0);
            Console.WriteLine("Deveria ter 1 elementos: " + list.Count);
            Console.WriteLine("Deveria ser o elemento 'a': " + list[0]);

            Console.WriteLine();
            list = collection.Get("chave", 0, -2);
            Console.WriteLine("Deveria ter 2 elementos: " + list.Count);
            Console.WriteLine("Deveria ser o elemento 'a': " + list[0]);
            Console.WriteLine("Deveria ser o elemento 'b': " + list[1]);



            Console.WriteLine();
            collection.Add("chave", 0, "x");
            list = collection.Get("chave", 0, 0);
            Console.WriteLine("Deveria ter 1 elementos: " + list.Count);
            Console.WriteLine("Deveria ser o elemento 'x': " + list[0]);

            Console.WriteLine();
            //------Get IndexOf------
            Console.WriteLine("A chamada IndexOf(ano.nascimento, bruno) vai retornar: 3 : " + collection.IndexOf("ano.nascimento", "bruno"));
            Console.WriteLine("A chamada IndexOf(ano.nascimento, arnaldo) vai retornar: 0 : " + collection.IndexOf("ano.nascimento", "arnaldo"));


            Console.WriteLine();
            //------Remove------
            Console.WriteLine("Remover coleção key = chave : retorna true : " + collection.Remove("chave"));
            Console.WriteLine("Remover coleção key = chave : retorna false : " + collection.Remove("chave"));

            Console.WriteLine();
            //------Remove------
            Console.WriteLine("Remover coleção key = ano.nascimento subindex = 1982 : retorna true : " + collection.RemoveValuesFromSubIndex("ano.nascimento", 1982));
            Console.WriteLine("Remover coleção key = ano.nascimento subindex = 1982 : retorna false : " + collection.RemoveValuesFromSubIndex("ano.nascimento", 1982));
            Console.ReadKey();
        }
    }
}
