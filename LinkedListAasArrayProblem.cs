namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var ar = new int[] { -1, 4, -1, 3, 2 };
            var answer  = solution(ar);
        }

        public static int solution(int[] A)
        {
            int count=0;
            var currentIndex = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if(A[currentIndex] == -1) { return ++count; }

                currentIndex = A[currentIndex];                
                count++;
            }

            return count;
        }
    }
}
