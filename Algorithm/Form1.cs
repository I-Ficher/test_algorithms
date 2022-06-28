using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Algorithm
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int allnumber, step;
        int left, right;
        
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
        ///
        static int[] ShellSort(int[] array)
        {
            
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }
        ///
        static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }


        static int partition(int[] A, int start, int end)
        {
            int pivot = A[(start + end) / 2];
            int i = start;
            int j = end;

            while (i <= j)
            {
                while (A[i] < pivot)
                    i++;
                while (A[j] > pivot)
                    j--;
                if (i <= j)
                {
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;

                    i++;
                    j--;
                }
            }

            return i;
        }

        static void qSort(int[] A, int start, int end)
        {
            if (start < end)
            {
                int temp = partition(A, start, end);

                qSort(A, start, temp - 1);
                qSort(A, temp, end);
            }
        }

        static int[] BubbleSort(int[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }

        static Int32 add2pyramid(Int32[] arr, Int32 i, Int32 N)
        {
            Int32 imax;
            Int32 buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        static void Pyramid_Sort(Int32[] arr, Int32 len)
        {
            
            for (Int32 i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            
            Int32 buf;
            for (Int32 k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                Int32 i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
        }

        public static int getMax(int[] arr, int n)

        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }


        public static void countSort(int[] arr, int n, int exp)

        {

            int[] output = new int[n]; 

            int i;

            int[] count = new int[10];

            for (i = 0; i < 10; i++)

                count[i] = 0;

            for (i = 0; i < n; i++)

                count[(arr[i] / exp) % 10]++;

            for (i = 1; i < 10; i++)

                count[i] += count[i - 1];

            for (i = n - 1; i >= 0; i--)

            {

                output[count[(arr[i] / exp) % 10] - 1] = arr[i];

                count[(arr[i] / exp) % 10]--;

            }

            for (i = 0; i < n; i++)

                arr[i] = output[i];

        }


        public static void radixsort(int[] arr, int n)

        {

            int m = getMax(arr, n);

            for (int exp = 1; m / exp > 0; exp *= 10)

                countSort(arr, n, exp);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Сколько нужно итераций";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Рандом от";
            textBox2.ForeColor = Color.Gray;
            textBox3.Text = "Рандом до";
            textBox3.ForeColor = Color.Gray;
            textBox4.Text = "Шаг";
            textBox4.ForeColor = Color.Gray;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            allnumber = Convert.ToInt32(textBox1.Text);
            left = Convert.ToInt32(textBox2.Text);
            right = Convert.ToInt32(textBox3.Text);
            step = Convert.ToInt32(textBox4.Text);

            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[2].Points.Clear();
            this.chart1.Series[3].Points.Clear();
            this.chart1.Series[4].Points.Clear();
            this.chart1.Series[5].Points.Clear();


            Stopwatch stopWatch = new Stopwatch();

            if (comboBox1.SelectedIndex == 0)
            {
                for (int x = 1; x < allnumber; x = x + step)
                {
                    var len = x;
                    ///quick_sort
                    var a = new int[len];
                    for (var i = 0; i < a.Length; ++i)
                    {
                        a[i] = random.Next(left, right);
                    }
                    
                    if (checkBox1.Checked == true)
                    {
                        stopWatch.Start();
                        qSort(a, 0, a.Length - 1);

                        stopWatch.Stop();

                        this.chart1.Series[0].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///bubble_sort
                    var v = new int[len];
                    for (var i = 0; i < v.Length; ++i)
                    {
                        v[i] = random.Next(left, right);
                    }

                    if (checkBox2.Checked == true)
                    {
                        stopWatch.Start();
                        BubbleSort(v);
                        stopWatch.Stop();
                        this.chart1.Series[1].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///Merge_sort
                    var b = new int[len];
                    for (var i = 0; i < b.Length; ++i)
                    {
                        b[i] = random.Next(left, right);
                    }

                    if (checkBox3.Checked == true)
                    {
                        stopWatch.Start();
                        MergeSort(b);
                        stopWatch.Stop();
                        this.chart1.Series[2].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///Shell_sort
                    var m = new int[len];
                    for (var i = 0; i < m.Length; ++i)
                    {
                        m[i] = random.Next(left, right);
                    }

                    if (checkBox4.Checked == true)
                    {
                        stopWatch.Start();
                        ShellSort(m);
                        stopWatch.Stop();
                        this.chart1.Series[3].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ////Heap sort
                    var z = new int[len];
                    for (var i = 0; i < z.Length; ++i)
                    {
                        z[i] = random.Next(left, right);
                    }

                    if (checkBox5.Checked == true)
                    {
                        stopWatch.Start();
                        Pyramid_Sort(z, z.Length);
                        stopWatch.Stop();
                        this.chart1.Series[4].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }

                    var p = new int[len];
                    for (var i = 0; i < p.Length; ++i)
                    {
                        p[i] = random.Next(left, right);
                    }

                    if (checkBox6.Checked == true)
                    {
                        stopWatch.Start();
                        radixsort(p, p.Length);
                        stopWatch.Stop();
                        this.chart1.Series[5].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                }
            }

            if(comboBox1.SelectedIndex == 1)
            {
                for (int x = 1; x < allnumber; x = x + step)
                {
                    var len = x;
                    ///quick_sort
                    var a = new int[len];
                    for (var i = 0; i < a.Length; ++i)
                    {
                        a[i] = i;
                    }
                    Array.Reverse(a);

                    if (checkBox1.Checked == true)
                    {
                        stopWatch.Start();
                        qSort(a,0,a.Length-1);
                        stopWatch.Stop();

                        this.chart1.Series[0].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///bubble_sort
                    var v = new int[len];
                    for (var i = 0; i < v.Length; ++i)
                    {
                        v[i] = i;
                    }
                    Array.Reverse(v);
                    if (checkBox2.Checked == true)
                    {
                        stopWatch.Start();
                        BubbleSort(v);
                        stopWatch.Stop();
                        this.chart1.Series[1].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///Merge_sort
                    var b = new int[len];
                    for (var i = 0; i < b.Length; ++i)
                    {
                        b[i] = i;
                    }
                    Array.Reverse(b);
                    if (checkBox3.Checked == true)
                    {
                        stopWatch.Start();
                        MergeSort(b);
                        stopWatch.Stop();
                        this.chart1.Series[2].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///Shell_sort
                    var m = new int[len];
                    for (var i = 0; i < m.Length; ++i)
                    {
                        m[i] = i;
                    }
                    Array.Reverse(m);
                    if (checkBox4.Checked == true)
                    {
                        stopWatch.Start();
                        ShellSort(m);
                        stopWatch.Stop();
                        this.chart1.Series[3].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ////Heap sort
                    var z = new int[len];
                    for (var i = 0; i < z.Length; ++i)
                    {
                        z[i] = i;
                    }
                    Array.Reverse(z);
                    if (checkBox5.Checked == true)
                    {
                        stopWatch.Start();
                        Pyramid_Sort(z, z.Length);
                        stopWatch.Stop();
                        this.chart1.Series[4].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }

                    var p = new int[len];
                    for (var i = 0; i < p.Length; ++i)
                    {
                        p[i] = i;
                    }
                    Array.Reverse(p);
                    if (checkBox6.Checked == true)
                    {
                        stopWatch.Start();
                        radixsort(p, p.Length);
                        stopWatch.Stop();
                        this.chart1.Series[5].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                
                for (int x = 1; x < allnumber; x = x + step)
                {
                    var len = x;
                    ///quick_sort
                    ///
                    
                    var a = new int[len];
                    for (var i = 0; i < a.Length; ++i)
                    {
                        a[i] = random.Next(left, right);
                    }
                    var fa = a.Take(a.Length / 2).OrderBy(xi => xi).Concat(a.Skip(a.Length / 2));
                    a = fa.ToArray();
                    if (checkBox1.Checked == true)
                    {
                        stopWatch.Start();
                        qSort(a, 0, a.Length - 1);
                        stopWatch.Stop();

                        this.chart1.Series[0].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///bubble_sort
                    var v = new int[len];
                    for (var i = 0; i < v.Length; ++i)
                    {
                        v[i] = random.Next(left, right);
                    }
                    var fv = v.Take(v.Length / 2).OrderBy(xi => xi).Concat(v.Skip(v.Length / 2));
                    v = fv.ToArray();
                    if (checkBox2.Checked == true)
                    {
                        stopWatch.Start();
                        BubbleSort(v);
                        stopWatch.Stop();
                        this.chart1.Series[1].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///Merge_sort
                    var b = new int[len];
                    for (var i = 0; i < b.Length; ++i)
                    {
                        b[i] = random.Next(left, right);
                    }
                    var fb = b.Take(b.Length / 2).OrderBy(xi => xi).Concat(b.Skip(b.Length / 2));
                    b = fb.ToArray();
                    if (checkBox3.Checked == true)
                    {
                        stopWatch.Start();
                        MergeSort(b);
                        stopWatch.Stop();
                        this.chart1.Series[2].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///Shell_sort
                    var m = new int[len];
                    for (var i = 0; i < m.Length; ++i)
                    {
                        m[i] = random.Next(left, right);
                    }
                    var fm = m.Take(m.Length / 2).OrderBy(xi => xi).Concat(m.Skip(m.Length / 2));
                    m = fm.ToArray();
                    if (checkBox4.Checked == true)
                    {
                        stopWatch.Start();
                        ShellSort(m);
                        stopWatch.Stop();
                        this.chart1.Series[3].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ////Heap sort
                    var z = new int[len];
                    for (var i = 0; i < z.Length; ++i)
                    {
                        z[i] = random.Next(left, right);
                    }
                    var fz = z.Take(z.Length / 2).OrderBy(xi => xi).Concat(z.Skip(z.Length / 2));
                    z = fz.ToArray();
                    if (checkBox5.Checked == true)
                    {
                        stopWatch.Start();
                        Pyramid_Sort(z, z.Length);
                        stopWatch.Stop();
                        this.chart1.Series[4].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                    ///Radix
                    var p = new int[len];
                    for (var i = 0; i < p.Length; ++i)
                    {
                        p[i] = random.Next(left, right);
                    }
                    var fp = p.Take(p.Length / 2).OrderBy(xi => xi).Concat(p.Skip(p.Length / 2));
                    p = fp.ToArray();
                    if (checkBox6.Checked == true)
                    {
                        stopWatch.Start();
                        radixsort(p, p.Length);
                        stopWatch.Stop();
                        this.chart1.Series[5].Points.AddXY(x, stopWatch.ElapsedMilliseconds);
                        stopWatch.Reset();
                    }
                }
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                this.chart1.Series[0].Enabled = true;
            }
            else
            {
                this.chart1.Series[0].Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                this.chart1.Series[1].Enabled = true;
            }
            else
            {
                this.chart1.Series[1].Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                this.chart1.Series[2].Enabled = true;
            }
            else
            {
                this.chart1.Series[2].Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                this.chart1.Series[3].Enabled = true;
            }
            else
            {
                this.chart1.Series[3].Enabled = false;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox4.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = null;
            textBox3.ForeColor = Color.Black;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                this.chart1.Series[4].Enabled = true;
            }
            else
            {
                this.chart1.Series[4].Enabled = false;
            }
        }

        

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // приводим отправителя к элементу типа CheckBox
            if (checkBox.Checked == true)
            {
                this.chart1.Series[5].Enabled = true;
            }
            else
            {
                this.chart1.Series[5].Enabled = false;
            }
        }

       
    }
}
