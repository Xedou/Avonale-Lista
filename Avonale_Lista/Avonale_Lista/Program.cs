using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avonale_Lista
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = CriandoLista();
            int media = Media(lista);

            Console.WriteLine("A média é: " + media + " e possui " + MaioresMedia(lista, 0, media, 0) + " números maiores que a média");

            ImprimirLista(lista);
            ImprimirLista(InverterLista(lista, lista.Count, new List<int>()));

            Console.ReadKey();

        }

        /// <summary>
        /// Cria uma lista com números aleatórios de 1 a 100
        /// </summary>
        /// <returns> 
        /// Uma lista preenchida com números 
        /// </returns>
        public static List<int> CriandoLista()
        {
            List<int> listaCriacao = new List<int>();
            Random rng = new Random();

            for (int i = 0; i < 20; i++)
            {
                listaCriacao.Add(rng.Next(1, 100));
            }

            return listaCriacao;
        }

        /// <summary>
        /// Método recursivo que soma os valores de uma lista
        /// </summary>
        /// <param name="listaSomada"> Lista preenchida </param>
        /// <param name="posicao"> Posição iniciando em 0 para controle de recursão </param>
        /// <param name="soma"> Valor a ser retornado </param>
        /// <returns>
        /// A soma total dos valores da lista
        /// </returns>
        public static int SomarLista(List<int> listaSomada, int posicao, int soma)
        {
            if (posicao == listaSomada.Count)
                return soma;

            soma += listaSomada[posicao];
            return SomarLista(listaSomada, posicao + 1, soma);
        }

        /// <summary>
        /// Calcula média dos valores da lista
        /// </summary>
        /// <param name="listaMedia"> Lista com valores </param>
        /// <returns>
        /// Média dos valores da lista
        /// </returns>
        public static int Media(List<int> listaMedia)
        {
            return SomarLista(listaMedia, 0, 0) / listaMedia.Count;
        }

        /// <summary>
        /// Método recursivo para encontrar a quantidade de valores acima de média em uma lista
        /// </summary>
        /// <param name="listaMedia"> Lista preenchida </param>
        /// <param name="posicao"> Posição iniciando em 0 para controle de recursão </param>
        /// <param name="media"> Média para os valores serem comparados </param>
        /// <param name="qtd"> Quantidade de valores acima da média </param>
        /// <returns>
        /// A quantidade de valores acima de média da lista
        /// </returns>
        public static int MaioresMedia(List<int> listaMedia, int posicao, int media, int qtd)
        {
            if (posicao == listaMedia.Count)
                return qtd;

            if (listaMedia[posicao] > media)
                qtd++;

            return MaioresMedia(listaMedia, posicao + 1, media, qtd);
        }

        /// <summary>
        /// Método recursivo que retorna a lista invertida
        /// </summary>
        /// <param name="listaOriginal"> Lista Preenchida</param>
        /// <param name="posicao"> Posição iniciando em 0 para controle de recursão </param>
        /// <param name="listaInvertida"> Lista vazia que será preenchida para o retorno </param>
        /// <returns>
        /// Uma lista invertida da original passada
        /// </returns>
        public static List<int> InverterLista(List<int> listaOriginal, int posicao, List<int> listaInvertida)
        {
            if (posicao == 0)
                return listaInvertida;

            listaInvertida.Add(listaOriginal[posicao - 1]);
            return InverterLista(listaOriginal, posicao - 1, listaInvertida);
        }

        /// <summary>
        ///  Imprimir na tela os valores da lista
        /// </summary>
        /// <param name="listaImpressa"> Lista preenchida </param>
        public static void ImprimirLista(List<int> listaImpressa)
        {
            foreach (var item in listaImpressa)
            {
                Console.Write(item.ToString() + " ");
            }

            Console.WriteLine();
        }

    }
}
