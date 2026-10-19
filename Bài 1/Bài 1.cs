using System;
internal class Bai1
{
    // Tạo hàm với chức năng đảo vị trí các phần tử trong mảng.
    static long [] Reverse_Array(long [] arr, int n) // Tạo hàm trả về mảng sau khi đã đảo.
    {
        // Khai báo biến left để chạy giá trị từ đầu chuỗi và right chạy từ cuối chuỗi đi lên.
        int left = 0; 
        int right = n - 1; 

        // Cho vòng lặp cho đến khi nào mà left >= right thì ngưng
        while(left < right) 
        {
            // Khởi tạo một biến ảo để chứa giá trị của index left và sau đó tiếp tục cho 
            // left bằng right và cuối cùng dừng lại ở biến ảo khởi tạo ban đầu.
            long bien = arr[left]; 
            arr[left] = arr[right]; 
            arr[right] = bien; 

            // sau mỗi lần chuyển đổi thì tăng left lên 1 đơn vị / còn right giảm 1 đơn vị cho đến
            // khi left lớn hơn right thì vòng lặp ngưng
            left ++; 
            right --; 
        }
        return arr; // trả về mảng sau khi đã đảo.
    }
    private static void Main1(string[] args)
    {
        // giao diện cho người dùng biết cần nhập thông tin gì
        // lưu và chuyển đổi giá trị từ string về kiểu int trong biến n
        System.Console.WriteLine("Nhập số nguyên n: "); 
        int n = int.Parse(Console.ReadLine() ?? "5"); 

        // khai báo tạo mảng mới với n phần tử
        long [] mang = new long[n]; 

        // Cho người dùng nhập n phần tử vào mảng bằng vòng lặp
        for (int i = 0; i < n ; i ++) 
        {
            // Để người dùng nhập vào từng phần tử của mảng. Sau đó lưu các giá trị đó
            // và chuyển đổi kiểu dữ liệu về cho phù hợp với kiểu của mảng
            System.Console.WriteLine($"Nhập vào số nguyên ở vị trí thứ {i+1} của mảng: "); 
            mang [i] = long.Parse(Console.ReadLine() ?? "10");
        }

        // Khai báo các biến cần thiết
        long sum = 0; 
        long min = mang[0]; 
        long max = mang[0]; 
        int count_negative = 0; 
        int count_positive = 0; 
        int count_0 = 0; 

        for (int i = 0 ; i < n ; i++)
        {
            // Tìm min và max bằng cách so sách nó với biến max được khởi tạo ban đầu là 
            // phần tử đầu tiên của mảng.
            if (max < mang[i]) max = mang[i]; 
            if (min > mang[i]) min = mang [i]; 

            // Tính tổng cộng dồn vào biến sum
            sum += mang[i]; 

            //Tính số lượng xuất hiện của các số dương - âm - 0 bằng các biến đếm
            // Mỗi khi xuất hiện thì các biến được tăng 1 đơn vị
            if (mang [i] < 0) count_negative ++; 
            if (mang [i] > 0) count_positive ++; 
            if (mang [i] == 0) count_0 ++;  
        }
        
        // In ra màn hình kết quả
        System.Console.WriteLine($"Tổng: {sum}");
        System.Console.WriteLine($"Giá trị nhỏ nhất: {min}");
        System.Console.WriteLine($"Giá trị lớn nhất: {max}");
        System.Console.WriteLine($"Trung bình cộng: {(double)sum/n :F2}");
        System.Console.WriteLine($"Số lượng phần tử âm: {count_negative}");
        System.Console.WriteLine($"Số lượng phần tử dương: {count_positive}");
        System.Console.WriteLine($"Số lượng phần tử = 0: {count_0}");

        // Tham chiếu hàm để đảo vị trí và lưu vào mảng khác
        long[] mang_da_dao = Reverse_Array(mang,n); 

        // In ra mảng sau khi đảo
        System.Console.Write("Mảng sau khi đảo là: [ ");
        for (int i = 0; i < n ; i++)
        {
            System.Console.Write(mang[i] + " ");
        }
        System.Console.Write("]");

    }
}