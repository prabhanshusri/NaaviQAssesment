using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NaaviQ.Models;
namespace NaaviQ.Controllers
{
    public class StudentController : Controller
    {
        [BindProperty]
        public string ListOfMarks { get; set; }

        public IActionResult MarksOfNStudents()
        {
            return View();
        }

        public IActionResult ProcessData(string ListOfMarks)
        {
            var obj = new MarksClass();

            if (ListOfMarks!=null)
            {

            var arr = ListOfMarks.Split(",").Select(x => Convert.ToInt32(x)).ToList();

            Sorter.QuickSort(arr, 0, arr.Count - 1);
            obj.markslist = arr;
         
                return View("MarksOfNStudents", obj);
            }
            else { return View("MarksOfNStudents"); }
            
        }

        static class Sorter
        {
            public static void QuickSort(List<int> mar, int s, int e)
            {
                if (s < e)
                {
                    int keyindex = Partition(mar, s, e);
                    QuickSort(mar, s, keyindex - 1);
                    QuickSort(mar, keyindex + 1, e);
                }
            }

            static int Partition(List<int> mar, int s, int e)
            {
                int keyindex = s, key = mar[e];
                for (int i = s; i < e; i++)
                {
                    if (mar[i] < key)
                    {
                        Swaper(i, keyindex, mar);
                        keyindex++;
                    }
                }
                Swaper(e, keyindex, mar);
                return keyindex;
            }

            static void Swaper(int x, int y, List<int> mar)
            {
                int t = mar[x];
                mar[x] = mar[y];
                mar[y] = t;
            }
        }
    }
}