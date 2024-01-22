using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Sorting
    {
        //선택정렬
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                        min = j;
                }
                Swap(list, i, min);
            }
        }

        //삽입정렬
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (list[j - 1] < list[j])
                        break;
                    Swap(list, j - 1, j);
                }
            }
        }

        //버블정렬
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j - 1] > list[j])
                        Swap(list, j - 1, j);
                }
            }
        }

        //병합정렬
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) return;

            int mid = (left + right) / 2;
            MergeSort(list, left, mid);
            MergeSort(list, mid + 1, right);
            Merge(list, left, mid, right);
        }

        public static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;
            int rightIndex = mid + 1;

            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex] < list[rightIndex])
                    sortedList.Add(list[leftIndex++]);
                else
                    sortedList.Add(list[rightIndex++]);
            }

            if (leftIndex > mid)
            {
                for (int i = rightIndex; i <= right; i++)
                    sortedList.Add(list[i]);
            }
            else
            {
                for (int i = leftIndex; i <= mid; i++)
                    sortedList.Add(list[i]);
            }

            for(int i = 0; i < sortedList.Count; i++)
            {
                list[left + i] = sortedList[i];
            }
        }

        // 퀵 정렬
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right)
            {
                while (list[left] <= list[pivot] && left < end)
                    left++;
                while (list[right] >= list[pivot] && right > start)
                    right--;

                if (left < right)
                    Swap(list, left, right);
                else
                    Swap(list, pivot, right);
            }

            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }

        // 힙 정렬
        public static void HeapSort(IList<int> list)
        {
            MakeHeap(list);
            for(int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        private static void MakeHeap(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }
        }

        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && list[left] > list[max])
                max = left;
            if (right < size && list[right] > list[max])
                max = right;

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }

        static void Main(string[] args)
        {
        }

        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
    }
}
