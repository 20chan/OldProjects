using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048AI
{
    public class AI
    {
        int _count;
        float[] weight;

        public AI(int width, int height)
        {
            _count = width * height;
            weight = new float[_count];
        }

        public void InitWeight()
        {
            Random r = new Random();
            for (int i = 0; i < _count; i++)
                weight[i] = (float)r.NextDouble();
        }

        /// <summary>
        /// 입력을 받고 방향을 리턴.
        /// </summary>
        /// <param name="input">보드의 각 숫자의 log(2) + 1 값.</param>
        /// <returns>0 : 왼쪽, 1 : 아래, 2 : 오른쪽, 3 : 위</returns>
        public int GetDirection(int[,] input)
        {
            float[] inp = new float[_count];
            int i = 0;
            for(int x = 0; x < input.GetLength(0); x++)
            {
                for(int y = 0; y < input.GetLength(1); y++)
                {
                    inp[i] = input[x, y];
                    i++;
                }
            }

            float[] result = new float[_count];
            for(i = 0; i < _count; i++)
            {
                result[i] = inp[i] * weight[i];
            }

            return (int)(4 * result.Sum()) % 4;
        }
    }
}
