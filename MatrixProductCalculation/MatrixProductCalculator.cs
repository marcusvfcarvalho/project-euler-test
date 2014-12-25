using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixProductCalculation
{
    public class MatrixProductCalculator
    {
        /// <summary>
        /// Dada uma matriz, retorna o maior produto dos elementos adjacentes.
        /// </summary>
        /// <param name="matrix">A matriz que será usada</param>
        /// <param name="adjacentElementsQuantity">Quantos elementos adjacentes serão usados no calculo do produto</param>
        /// <param name="allowOverflow">Flag que informa se o calculo proseguirá além dos limites da matriz, completando-a com os elementos do lado oposto</param>
        /// <returns>O maior produto encontrado</returns>
        public static long Calculate(int[,] matrix, int adjacentElementsQuantity, bool allowOverflow)
        {
            long higherProduct = 0L;
            for (int line = 0; line < matrix.GetLength(0); line++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    /*
                     * Não é necessário testar para left e up, nem  para as diagonais para cima, pois elas são redundantes
                     * tanto quando for requerida a transposição quando não for.
                     */
                    higherProduct = Math.Max(higherProduct,
                                    Math.Max(CalculateRight(matrix, line, col, adjacentElementsQuantity, allowOverflow),
                                    Math.Max(CalculateDown(matrix, line, col, adjacentElementsQuantity, allowOverflow),
                                    Math.Max(CalculateDiagonalLeft(matrix, line, col, adjacentElementsQuantity, allowOverflow),
                                             CalculateDiagonalRight(matrix, line, col, adjacentElementsQuantity, allowOverflow)))));

                                  
                }
            }
            return higherProduct;
        }

        /*
         * Para cada direção usaremos uma função. As funções simplesmente encapsulam o metodo ScanValues com 
         * os parãmetros de direção corretos para cada uma.
         * */
      
        public static long CalculateRight(int[,] matrix, int line, int col, int adjacentElementsQuantity, bool allowOverflow)
        {
            long product = ScanValues(matrix,line, col, adjacentElementsQuantity,allowOverflow, 1, 0).Aggregate(1, (x,y) => x * y);
            return product;
        }

        public static long CalculateDiagonalLeft(int[,] matrix, int line, int col, int adjacentElementsQuantity, bool allowOverflow)
        {
            long product =  ScanValues(matrix, line, col, adjacentElementsQuantity, allowOverflow, -1, 1).Aggregate(1, (x, y) => x * y);
            return product;
        }

        public static long CalculateDown(int[,] matrix, int line, int col, int adjacentElementsQuantity, bool allowOverflow)
        {
            long product = ScanValues(matrix, line, col, adjacentElementsQuantity, allowOverflow, 0, 1).Aggregate(1, (x, y) => x * y);
            return product;
        }

        public static long CalculateDiagonalRight(int[,] matrix, int line, int col, int adjacentElementsQuantity, bool allowOverflow)
        {
            long product = ScanValues(matrix, line, col, adjacentElementsQuantity, allowOverflow, 1, 1).Aggregate(1, (x, y) => x * y);
            return product;
        }

        /// <summary>
        /// ScanValues busca os elementos adjacentes de uma matriz a partir de um elemento dado. Os valores de offset
        /// positivos, zero ou negativos informam em qual direção a busca de ser feita.
        /// </summary>
        /// <param name="matrix">A matriz onde os elementos devem ser buscados</param>
        /// <param name="line">A linha do elemento inicial</param>
        /// <param name="col">A coluna do elemento inicial</param>
        /// <param name="adjacentElementsQuantity">A quantidade de elementos que devem ser buscados</param>
        /// <param name="allowOverflow">Flag que indica se a busca deve continuar além dos limites da matriz, completando os elementos do lado oposto</param>
        /// <param name="horizontalOffSet">A direção que a busca deve seguir na horizontal</param>
        /// <param name="verticalOffSet">A direção que a busca deve seguir na vertical</param>
        /// <returns>Uma lista contendo os valores encontrados</returns>
        public static List<int> ScanValues(int[,] matrix, int line, int col, int adjacentElementsQuantity, bool allowOverflow,  int horizontalOffSet=0, int verticalOffSet=0)
        {
            List<int> values = new List<int>();
            //checar parametros
            if (verticalOffSet < -1 || verticalOffSet > 1 ||
                horizontalOffSet < -1 || horizontalOffSet > 1)
            {
                throw new ArgumentException("horizontalOffset e verticalOffSet apenas podem conter os valores -1,0,1");
            }


            
            int l=line, c=col;

            do
            {
                if ((verticalOffSet > 0) ? l > matrix.GetLength(0) - 1 : l < 0)
                {
                    if (allowOverflow)
                    {
                        l = (verticalOffSet > 0) ? 0 : matrix.GetLength(0)-1;
                    }
                    else
                    {
                        values = new List<int>();
                        break;
                    }
                }

                if ((horizontalOffSet > 0) ? c > matrix.GetLength(1) - 1 : c < 0)
                {
                    if (allowOverflow)
                    {
                        c = (horizontalOffSet > 0) ? 0 : matrix.GetLength(1)-1;
                    }
                    else
                    {
                        values = new List<int>();
                        break;
                    }
                }

                int value = matrix[l, c];

                l += verticalOffSet;
                c += horizontalOffSet;

                values.Add(value);

            } while (values.Count < adjacentElementsQuantity);
           

            return values;
        }
    }
}
