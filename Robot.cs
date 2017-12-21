using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Robot
    {
        #region Define Enum of differnt chips
        public enum Chip
        {
            /// <summary>
            /// Value has not been set
            /// </summary>
            NotInitialized = 0,

            /// <summary>
            /// Represents chip with logic to sort an array
            /// </summary>
            Sort = 1,

            /// <summary>
            /// Represents chip with logic to sum all the element of an array
            /// </summary>
            Sum = 2,
        }
        #endregion

        #region private members and constructo
        private Chip _chipType = Chip.NotInitialized;
        private static int _chipInstalledInLifeTime = 0;
        private Dictionary<int, bool> _chipAlreadyInstalled = new Dictionary<int, bool>();

        /// <summary>
        /// Constructor
        /// </summary>
        public Robot()
        {
        }
        #endregion

        #region public property
        /// <summary>
        /// Returns value of number of chip installed in its lifetime
        /// </summary>
        public int TotalChipInstalledInLifeTime
        {
            get { return _chipInstalledInLifeTime; }
        }
        #endregion

        #region public method
        /// <summary>
        /// Allow pluging of chip
        /// </summary>
        /// <param name="chipType"></param>
        public void PlugChip(Chip chipType)
        {
            _chipType = chipType;
            if (!_chipAlreadyInstalled.ContainsKey((int)chipType))
            {
                _chipAlreadyInstalled.Add((int)chipType, true);
                _chipInstalledInLifeTime++;
            }
        }

        /// <summary>
        /// Execute current chip logic
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public T ExecuteLogic<T>(int[] a, out string errorMessage)
        {
            errorMessage = string.Empty;

            switch (_chipType)
            {
                case Chip.NotInitialized:
                    {
                        errorMessage = "Cannot execute logic. No chip plugged";
                        return (T)(object)-1;
                    }

                case Chip.Sort:
                    {
                        Sort(a, 0, a.Length-1);
                        return (T)(object)a;
                    }

                case Chip.Sum:
                    {
                        return (T)(object)Sum(a);
                    }

                default:
                    {
                        errorMessage = "Cannot execute logic. No chip plugged";
                        return (T)(object)-1;
                    }
            }
        }
        #endregion

        #region private methods
        private int Sum(int[] a)
        {
            int total = 0;
            foreach (int i in a)
            {
                total += i;
            }
            return total;
        }

        private void Sort(int[] a, int begin, int end)
        {

            if (end > begin)
            {
                int middle = (end + begin) / 2;
                Sort(a, begin, middle);
                Sort(a, middle + 1, end);

                Merge(a, begin, middle + 1, end);
            }
        }

        private void Merge(int[] a, int left, int middle, int end)
        {
            int left_end = middle - 1;
            int tmp_pos = left;
            int num_elements = end - left + 1;
            int[] tempArr = new int[a.Length];

            while ((left <= left_end) && (middle <= end))
            {
                if (a[left] <= a[middle])
                    tempArr[tmp_pos++] = a[left++];
                else
                    tempArr[tmp_pos++] = a[middle++];
            }

            while (left <= left_end)
                tempArr[tmp_pos++] = a[left++];

            while (middle <= end)
                tempArr[tmp_pos++] = a[middle++];

            for (int i = 0; i < num_elements; i++)
            {
                a[end] = tempArr[end];
                end--;
            }
        }
        #endregion
    }
}

//Comment
// Used Merged sort considering performance as its takes O(n log n) in best and worst case.
// Usen Enum to define different chips. 
// Used generic return type to provide different result type based on the chip that is plugged in.
 

///For TEST
//Robot r = new Robot();
//r.PlugChip(Robot.Chip.Sum);
//int[] a = {1,4,2,3,6,7};
//string err = string.Empty;
//int total = r.ExecuteLogic<int>(a, out err);
//Console.WriteLine(total.ToString());

//r.PlugChip(Robot.Chip.Sort);
//int[] sortedArray = r.ExecuteLogic<int[]>(a, out err);
//for (int i = 0; i < sortedArray.Length; i++)
//{
//    Console.WriteLine(sortedArray[i].ToString());
//}


//r.PlugChip(Robot.Chip.Sum);
//total = r.ExecuteLogic<int>(a, out err);
//Console.WriteLine(total.ToString());

//Console.WriteLine(r.TotalChipInstalledInLifeTime.ToString());

