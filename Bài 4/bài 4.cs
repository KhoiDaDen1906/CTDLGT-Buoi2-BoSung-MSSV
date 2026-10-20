using System;
using System.Collections.Generic;

public class DynamicArray<T>
{
    // Mảng tĩnh nội bộ, dùng private để không bị thay đổi bởi các tác động bên ngoài
    private T[] items;

    // Số lượng thực tế. 
    // Lệnh private set nghĩa là: Bên ngoài được quyền xem có bao nhiêu phần tử, 
    // nhưng chỉ có code bên trong class này mới được quyền thay đổi con số này.
    public int Count { get; private set; }

    // Sức chứa tối đa luôn bằng đúng chiều dài của mảng items.
    public int Capacity => items.Length;

    // capacity = 4 nghĩa là nếu người dùng không nhập gì, tự động lấy số 4.
    public DynamicArray(int capacity = 4) 
    {
        //Tránh lỗi Capacity âm.
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity không được âm!");
        }
                
        // Cấp phát vùng nhớ cho mảng items dựa trên capacity
        items = new T[capacity];
            
        // Mới khởi tạo nên chưa có dữ liệu nào, Count = 0
        Count = 0; 
    }
    // Hàm mở rộng mảng (Tự động nhân đôi sức chứa khi đầy)
    // Dùng private vì đây là logic xử lý ngầm, không cho bên ngoài gọi trực tiếp.
    private void EnsureCapacity()
    {
        // 1. Nếu số phần tử (Count) vẫn nhỏ hơn sức chứa (Capacity) -> Mảng chưa đầy -> Bỏ qua
        if (Count < Capacity) return;

        // 2. Nếu đã đầy: Tính sức chứa mới. 
        // Gấp đôi sức chứa cũ (nếu mảng đang có sức chứa là 0 thì mặc định cấp là 4).
        int newCapacity = Capacity == 0 ? 4 : Capacity * 2;
        
        // 3. Cấp phát vùng nhớ cho một mảng mới to hơn
        T[] newItems = new T[newCapacity];

        // 4. Dùng vòng lặp chép dữ liệu từ mảng cũ sang mảng mới.
        for (int i = 0; i < Count; i++)
        {
            newItems[i] = items[i];
        }

        // 5. Trỏ biến quản lý items sang mảng mới. 
        // Vùng nhớ mảng cũ sẽ tự động được thu hồi.
        items = newItems;
        
        // In ra màn hình để chứng minh mảng có giãn nở khi chạy test.
        Console.WriteLine($"[Hệ thống] Mảng đầy! Đã sao chép {Count} phần tử và mở rộng Capacity lên {Capacity}");
    }
    // Hàm thêm phần tử vào mảng động
    public void Add(T item)
    {
        // Kiểm tra sức chứa. Nếu đầy thì tự động nới rộng.
        EnsureCapacity();

        // Gán phần tử mới vào vị trí trống tiếp theo 
        items[Count] = item;
        
        // Tăng sĩ số thực tế lên 1
        Count++;
    }
    // Bộ lập mục lục (Indexer): Cho phép truy cập mảng bằng ngoặc vuông arr[i]
    public T this[int index]
    {
        get
        {
            // Ngăn chặn truy cập vùng nhớ ngoài giới hạn Count
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số truy cập không hợp lệ!");
            
            // Trả về dữ liệu. Chi phí O(1).
            return items[index];
        }
        set
        {
            // Ngăn chặn sửa dữ liệu ngoài giới hạn Count
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số truy cập không hợp lệ!");
            
            // Ghi đè dữ liệu mới. Chi phí O(1).
            items[index] = value;
        }
    }
}

internal class Bai4
{
    private static void Main(string[] args)
    {
        // Khởi tạo mảng động lưu trữ kiểu số nguyên với sức chứa mặc định là 4
        DynamicArray<int> arr = new DynamicArray<int>();
        Console.WriteLine($"Lúc đầu: Count = {arr.Count}, Capacity = {arr.Capacity}\n");
            
        // Thực hiện 10 lần Add liên tục để kích hoạt cơ chế mở rộng Capacity
        for (int i = 1; i <= 10; i++)
        {
            arr.Add(i);
            // Dùng {i,2} để canh lề cho đẹp khi in ra số 10
            Console.WriteLine($"Thêm số {i,2} -> Count: {arr.Count}, Capacity: {arr.Capacity}");
        }

        //Kiểm thử indexer
        Console.WriteLine($"Dữ liệu cũ ở vị trí số 2 (index = 2) là: {arr[2]}");
            
        arr[2] = 999;
        Console.WriteLine($"Đã ghi đè arr[2] thành 999. Kiểm tra lại: {arr[2]}");

        // Kiểm tra thử bất lợi bên ngoài vùng giới hạn
        try
        {
            // Mảng đang có 10 phần tử (chỉ số cao nhất là 9), thử truy cập index 10 (bằng Count)
            Console.WriteLine("Thử truy cập index = 10 (bằng Count)");
            int errorTest1 = arr[10];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã bắt được lỗi: {ex.Message}");
        }

        try
        {
            // Thử truy cập index âm
            Console.WriteLine("Thử truy cập index = -1 (Index âm)");
            int errorTest2 = arr[-1];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã bắt được lỗi: {ex.Message}");
        }
            
        Console.WriteLine("\nHoàn thành bài test!");
    }
}