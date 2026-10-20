using System;
using System.Collections.Generic;
public class Student
{
    // Lưu mã duy nhất dùng để nhận diện sinh viên.
    public string Id { get; set; } = "";

    // Lưu họ tên dùng cho hiển thị và tìm kiếm.
    public string FullName { get; set; } = "";

    // Lưu điểm tổng kết trong đoạn từ 0 đến 10.
    public double Score { get; set; }

}
internal class Bai3
{
    private static void Main3(string[] args)
    {
        // Tạo một list rỗng để chứa.
        List<Student> students = new List<Student> ();
        //Tạo một biến để chứa các lựa chọn của người dùng nhập vào giao diện menu.
        int lua_chon;

        // Dùng vòng lập do-while để người dùng thao tác với thông tin sinh viên.
        do
        {
            // In ra giao diện cho người dùng lựa chọn tác vụ muốn thực hiện
            System.Console.WriteLine("Xin chào! Bạn muốn sử dụng tác vụ nào dưới đây?");
            System.Console.WriteLine("1. Thêm sinh viên");
            System.Console.WriteLine("2. Cập nhật thông tin");
            System.Console.WriteLine("3. Xoá thông tin sinh viên");
            System.Console.WriteLine("4. Tìm kiếm theo tên");
            System.Console.WriteLine("5. Thực hiện thống kê");
            System.Console.WriteLine("Nhấn 0 nếu bạn muốn thoát chương trình!");
            System.Console.WriteLine("Vui lòng nhập 1 -> 5 để chọn chức năng!");

            //Đọc và xử lý số người dùng nhập. Nếu không nhập gì thì mặc định giá trị 0 (thoát chương trình) để tránh null
            lua_chon = int.Parse(Console.ReadLine() ?? "0");

            if (lua_chon == 1)
            {
                Console.WriteLine("Bạn đã chọn chức năng Thêm sinh viên, vui lòng đợi trong giây lát!");
                AddStudent(students);
            }
            else if (lua_chon == 2)
            {
                Console.WriteLine("Bạn đã chọn chức năng Cập nhật thông tin sinh viên, vui lòng đợi trong giây lát!");
                UpdateStudent(students);
            }
            else if (lua_chon == 3)
            {
                Console.WriteLine("Bạn đã chọn chức năng Xoá thông tin sinh viên, vui lòng đợi trong giây lát!");
                RemoveStudent(students);
            }
            else if (lua_chon == 4)
            {
                Console.WriteLine("Bạn đã chọn chức năng Tìm kiếm thông tin sinh viên, vui lòng đợi trong giây lát!");
                SearchStudent(students);
            }
            else if (lua_chon == 5)
            {
                Console.WriteLine("Bạn đã chọn chức năng Thống kê, vui lòng đợi trong giây lát!");
                DisplayAndStatistics(students);
            }
            else if (lua_chon != 0)
            {
                Console.WriteLine("Bạn nhập sai định dạng được phép! Vui lòng nhập số từ 1 -> 5!");
            }
        } while(lua_chon != 0);
        System.Console.WriteLine("Bạn đã thoát chương trình! Hẹn gặp lại!");
    }
    // Hàm Thêm sinh viên. Nhận đầu vào là nơi chứa students truyền từ Main xuống.
    static void AddStudent(List<Student> students)
    {
        //Nhập MSSV và xử lý lưu dưới dạng chuỗi vào biến mssv.
        System.Console.WriteLine("Nhập MSSV: ");
        // Biến mssv lưu dưới kiểu string là do khai báo ban đầu của Student - ID là string.
        string mssv = Console.ReadLine() ?? "31251021997";

        // Phải duyệt qua toàn bộ các phần tử hiện có trong list bằng vòng lặp.
        // Thời gian chạy là O(n) vì phải kiểm tra từng phần tử một trong list.
        for(int i = 0; i < students.Count ; i++)
        {
            // Lấy mã của sinh viên thứ i đi so sánh với mã mới nhập vào.
            if (students[i].Id == mssv)
            {
                //Nếu giống nhau lập tức báo lỗi và return để thoát chương trình ngay tại đó.
                System.Console.WriteLine("Error! Đã có MSSV này tồn tại trong hệ thống!");
                return;
            }
        }
        // Tiếp tục nhập họ tên của sinh viên
        System.Console.WriteLine("Nhập vào Họ tên sinh viên: ");
        string hoten = Console.ReadLine() ?? "Trần Đăng Khôi";

        //Nhập số điểm của sinh viên
        System.Console.WriteLine("Nhập số điểm của sinh viên (0-10): ");
        // Dùng double để nhập điểm là số thực. Nếu không nhập gì thì mặc định là 5.
        double diem = double.Parse(Console.ReadLine() ?? "5");

        //Dùng điều kiện để loại bỏ các giá trị lỗi, đảm bảo tính logic của điểm.
        if (diem < 0 || diem > 10)
        {
            // Nếu vi phạm thì return để thoát chương trình ngay tại đó.
            System.Console.WriteLine("Error! Điểm không thể âm hoặc lớn hơn 10!");
            return;
        }

        // Sau khi vượt qua các điều kiện trên về dữ liệu đầu vào
        //Khởi tạo một list Student mới với các dữ liệu đầu vào vừa được nhập.
        Student newStudent = new Student {Id = mssv , FullName = hoten , Score = diem};

        // Cho các sinh viên vừa được nhập thông tin vào cuối danh sách.
        // Dùng lệnh Add có thời gian chạy O(1).
        students.Add(newStudent);

        System.Console.WriteLine("Quá trình thêm sinh viên thành công!");
    }
    static void UpdateStudent(List<Student> students)
    {
        // Nhập MSSV của sinh viên cần cập nhật thông tin
        System.Console.WriteLine("Nhập MSSV của sinh viên cần cập nhật thông tin: ");
        string mssv = Console.ReadLine() ?? "31251021997";

        // Dùng vòng lặp để tìm vị trí của sinh viên có mssv vừa nhập
        for (int i = 0; i < students.Count; i++)
        {
            //Nếu tìm thấy sinh viên khớp với mssv thị tiến hành thực hiện cập nhật.
            if(students[i].Id == mssv)
            {
                // Tiến hành cập nhật tên và số điểm.
                System.Console.WriteLine("Nhập họ và tên mới: ");
                string hoten_moi = Console.ReadLine();

                System.Console.WriteLine("Nhập số điểm mới: ");
                double diem_moi = double.Parse(Console.ReadLine());

                //Kiểm tra tính logic của biến đầu vào điểm.
                if (diem_moi < 0 || diem_moi > 10)
                {
                    System.Console.WriteLine("Error! Không tồn tại số điểm âm hay lớn hơn 10!");
                }
                else
                {
                    // Nếu đúng hết thì lưu các biến mới vào từng thuộc tính của danh sách.
                    students[i].FullName = hoten_moi;
                    students[i].Score = diem_moi;
                    System.Console.WriteLine("Cập nhật thông tin thành công!");
                }
                // Sau khi hoàn thành việc cập nhật rồi thì cho chương trình ngưng luôn để
                // tránh việc tốn thời gian và tài nguyên để chạy hết i = o --> n.
                return;
            }
        }
        // Trong trường hợp chạy đến hết danh sách nhưng vẫn không thấy thông tin khớp
        // Chứng tỏ rằng mssv này không tồn tại.
        System.Console.WriteLine("Không tìm thấy MSSV khớp với sinh viên!");
    }
    static void RemoveStudent(List<Student> students)
    {
        // Nhập MSSV của sinh viên cần xoá thông tin
        System.Console.WriteLine("Nhập MSSV của sinh viên cần xoá thông tin: ");
        string mssv = Console.ReadLine() ?? "31251021997";

        // Dùng vòng lặp để tìm vị trí của sinh viên có mssv vừa nhập
        for (int i = 0; i < students.Count; i++)
        {
            //Nếu tìm thấy sinh viên khớp với mssv thị tiến hành thực hiện xoá.
            if(students[i].Id == mssv)
            {
                // Thực hiện xoá các phần tử ở vị trí thứ i của list
                // Khác với Array thì list linh hoạt hơn có thể tự động dồn dữ liệu lên sau khi xoá nên ta không
                // cần phải tự đi xoá phần tử cuối đi như xoá ở bên Array.
                students.RemoveAt(i);
                System.Console.WriteLine("Bạn thực hiện xoá thành công!");
                // Sau khi hoàn thành việc cập nhật rồi thì cho chương trình ngưng luôn để
                // tránh việc tốn thời gian và tài nguyên để chạy hết i = o --> n.
                return;
            }
        }
        // Trong trường hợp chạy đến hết danh sách nhưng vẫn không thấy thông tin khớp
        // Chứng tỏ rằng mssv này không tồn tại.
        System.Console.WriteLine("Không tìm thấy MSSV khớp với sinh viên!");
    }
    static void SearchStudent(List<Student> students)
    {
        // Nhập tên sinh viên để tìm kiếm
        System.Console.WriteLine("Nhập vào tên sinh viên cần tìm: ");
        //Chuyển dữ liệu đầu vào về lower case.
        string name = Console.ReadLine().ToLower();

        // Tạo biến bool để xem có tìm thấy hay không.
        bool found = false;

        // Sử dụng vòng lập duyệt mảng để tìm tên sinh viên.
        for (int i = 0; i < students.Count ; i++)
        {
            //Lấy fullname lowercase xuống và check xem liệu có chứa tên vừa nhập vào hay không
            if (students[i].FullName.ToLower().Contains(name))
            {
                System.Console.WriteLine($"MSSV: {students[i].Id} | Tên: {students[i].FullName} | Điểm: {students[i].Score}");
                // Thay đổi biến found thành true nếu đã tìm được
                found = true;
            }
        }
        // Nếu chạy hết vòng lặp mà vẫn không thấy, tức là found vẫn false thì báo không tìm thấy
        if (!found)
        {
            System.Console.WriteLine("Không có sinh viên nào khớp với từ khóa!");
        }

    }
    static void DisplayAndStatistics(List<Student> students)
    {
        // Đề phòng trường hợp danh sách bị rỗng, ngưng chương trình luôn.
        if (students.Count == 0)
        {
            System.Console.WriteLine("Danh sách rỗng!!!");
            return;
        }
        // Tạo 1 biến đếm số lượng sinh viên đậu và 1 biến để cộng dồn tổng điểm của cả lớp.
        int count_pass = 0;
        double sum = 0;
        // In ra toàn bộ danh sách bằng cách sử dụng vòng lặp
        for (int i = 0 ; i < students.Count ; i++)
        {
            System.Console.WriteLine($"MSSV: {students[i].Id} | Tên: {students[i].FullName} | Điểm: {students[i].Score}");
            if (students[i].Score >= 5)
            {
                count_pass++;
            }
            sum += students[i].Score;
        }
        // In ra số lượng sinh viên đậu và điểm trung bình của cả lớp.
        System.Console.WriteLine($"Có {count_pass} em đậu!");
        System.Console.WriteLine($"Điểm trung bình của cả lớp là: {sum/students.Count :F2}");
    }
}