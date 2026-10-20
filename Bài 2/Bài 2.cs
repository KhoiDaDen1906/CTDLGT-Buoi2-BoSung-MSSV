internal class Bai2
{
    static void RemoveAt(int [] data, ref int count, int index)
    {
        // Nếu index nhỏ hơn 0, hoặc lớn hơn hoặc bằng số lượng người đang có (tức biến count)
        // thì trả về thông báo lỗi.
        if (index < 0 || index >= count)
        throw new ArgumentOutOfRangeException(nameof(index), "Vị trí xóa không hợp lệ.");

        // Vòng lặp bắt đầu từ vị trí muốn remove (index), chạy đến vị trí cuối cùng (count - 1)
        for (int i = index; i < count - 1; i++)
        {
            // Lấy vị trí của phần tử sau (i + 1) đè lên phân tử hiện tại (i)
            data[i] = data[i + 1];
        }
        // Xoá đi vị trí cuối cùng để được mảng mới có phần tử ít hơn 1 so với mảng ban đầu
        data[count - 1] = 0; 

        // Giảm số lượng phần tử đi 1.
        count--; 
    }
    static void Insert(int[] data, ref int count, int index, int value)
    {
        // Nếu tổng số phần tử hiện tại (count) đã đầy (data.Length)
        // thì trả về lỗi là mảng đã không còn chỗ chứa.
        if (count >= data.Length)
        throw new InvalidOperationException("Mảng đã đầy, không thể chèn thêm.");

        //Nếu vị trí yêu cầu chèn là số âm, hoặc vượt quá số lượng phần tử hiện tại (tạo ra lỗ hổng)
        // Trả về lỗi.
        if (index < 0 || index > count)
        throw new ArgumentOutOfRangeException(nameof(index), "Vị trí chèn không hợp lệ.");

        // Biến i bắt đầu từ vị trí trông cuối mảng (count), lùi dần về vị trí cần thêm (index)
        for (int i = count; i > index; i--)
        {
        // Lấy phần tử ngay phía trước (i - 1) chuyển sang phần tử hiện tại (i)
        data[i] = data[i - 1]; 
        }

        // Thêm phần tử (value) vào vị trí trống (index) vừa được tạo ra
        data[index] = value;
    
        // Tăng tổng số phần tử lên 1
        count++;
    }
    static void InMang(int[] data, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine(); // Xuống dòng
        }
    private static void Main2(string[] args)
    {
        // Khởi tạo mảng có 10 ô, đang có 5 phần tử hợp lệ theo đề bài
            int[] data = new int[10];
            data[0] = 4; data[1] = 7; data[2] = 2; data[3] = 9; data[4] = 5;
            int count = 5;

            //Kiểm tra.
            // 1. Chèn 99 tại index 2
            Insert(data, ref count, 2, 99);
            Console.Write("Sau khi chèn 99 tại index 2: ");
            InMang(data, count);

            // 2. Xóa phần tử tại index 1
            RemoveAt(data, ref count, 1);
            Console.Write("Sau khi xoá tại index 1: ");
            InMang(data, count);

            // 3. Chèn tại đầu
            Insert(data, ref count, 0, 88);
            Console.Write("Chèn 88 tại vị trí đầu: ");
            InMang(data, count);

            // 4. Chèn tại cuối 
            Insert(data, ref count, count, 77);
            Console.Write("Chèn 77 tại vị trí cuối: ");
            InMang(data, count);

            // 5. Xóa tại đầu
            RemoveAt(data, ref count, 0);
            Console.Write("Xoá tại vị trí đầu: ");
            InMang(data, count);

            // 6. Xóa phần tử cuối
            RemoveAt(data, ref count, count - 1);
            Console.Write("Xoá tại vị trí cuối: ");
            InMang(data, count);

            // Dùng try-catch để chương trình không bị văng khi test lỗi
            try 
            { 
                Insert(data, ref count, -1, 10); 
            } 
            catch (Exception e) 
            { 
                Console.WriteLine("Lỗi do chèn index âm: " + e.Message); 
            }
            
            try 
            { 
                RemoveAt(data, ref count, count); 
            } 
            catch (Exception e) 
            { 
                Console.WriteLine("Lỗi xoá index = count: " + e.Message); 
            }
    }
}