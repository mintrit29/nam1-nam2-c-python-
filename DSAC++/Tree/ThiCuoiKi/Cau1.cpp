#include <iostream>
#include <stdio.h>
#include <string>
#include <ctime>
#include <sstream>
#include <vector>

using namespace std;

struct PERSON
{
    string Name;
    string Gender;
    string BirthPlace;
    string DateOfBirth;
    string DateOfDeath;
    string Job;
};

struct Node
{
    PERSON data;
    Node *leftChild;
    Node *rightChild;
};

void AddPerson(Node *&root, PERSON newPerson, string parentName)
{
    if (root == NULL)
    {
        root = new Node{newPerson, NULL, NULL};
        return;
    }

    if (root->data.Name == parentName)
    {
        if (root->leftChild == NULL)
        {
            root->leftChild = new Node{newPerson, NULL, NULL};
        }
        else if (root->rightChild == NULL)
        {
            root->rightChild = new Node{newPerson, NULL, NULL};
        }
        else
        {
            cout << "Parent already has two children." << endl;
        }
        return;
    }
    else
    {
        if (root->leftChild != NULL)
        {
            AddPerson(root->leftChild, newPerson, parentName);
        }
        if (root->rightChild != NULL)
        {
            AddPerson(root->rightChild, newPerson, parentName);
        }
    }
}

PERSON NhapThongTinNguoi()
{
    PERSON person;
    cout << "Nhap ho va ten: ";
    getline(cin >> ws, person.Name);
    cout << "Nhap gioi tinh (Nam/Nu): ";
    getline(cin, person.Gender);
    cout << "Nhap noi sinh: ";
    getline(cin, person.BirthPlace);
    cout << "Nhap ngay sinh (dd/mm/yyyy): ";
    getline(cin, person.DateOfBirth);
    cout << "Nhap ngay mat (dd/mm/yyyy, bo trong neu con song): ";
    getline(cin, person.DateOfDeath);
    cout << "Nhap nghe nghiep: ";
    getline(cin, person.Job);
    return person;
}

void InThongTinNguoi(const PERSON &person)
{
    cout << "\n- Ho va ten: " << person.Name << endl;
    cout << "- Gioi tinh: " << person.Gender << endl;
    cout << "- Noi sinh: " << person.BirthPlace << endl;
    cout << "- Ngay sinh: " << person.DateOfBirth << endl;

    // Tính tuổi
    int yearOfBirth, monthOfBirth, dayOfBirth;
    sscanf(person.DateOfBirth.c_str(), "%d/%d/%d", &dayOfBirth, &monthOfBirth, &yearOfBirth);

    int age;
    if (person.DateOfDeath.empty())
    { // Trường hợp còn sống
        time_t now = time(0);
        tm *ltm = localtime(&now);
        int currentYear = 1900 + ltm->tm_year;
        age = currentYear - yearOfBirth;
    }
    else
    { // Trường hợp đã mất
        int yearOfDeath, monthOfDeath, dayOfDeath;
        sscanf(person.DateOfDeath.c_str(), "%d/%d/%d", &dayOfDeath, &monthOfDeath, &yearOfDeath);
        age = yearOfDeath - yearOfBirth;

        // Xử lý trường hợp tháng sinh sau tháng mất
        if (monthOfBirth > monthOfDeath || (monthOfBirth == monthOfDeath && dayOfBirth > dayOfDeath))
        {
            age--;
        }
    }

    cout << "- Tuoi: " << age << endl;

    if (!person.DateOfDeath.empty())
    {
        cout << "- Tinh trang: Da mat" << endl;
    }
    else
    {
        cout << "- Tinh trang: Con song" << endl;
    }
    cout << "- Nghe nghiep: " << person.Job << endl;
}

// Hàm duyệt cây gia phả theo thứ tự NLR và in thông tin
void PrintFamilyTree(Node *root, int level = 0)
{
    if (root != NULL)
    {
        for (int i = 0; i < level; i++)
        {
            cout << "  ";
        }
        InThongTinNguoi(root->data);
        PrintFamilyTree(root->leftChild, level + 1);
        PrintFamilyTree(root->rightChild, level + 1);
    }
}

// Hàm tìm kiếm người trong cây gia phả
Node *TimKiemNguoi(Node *root, const string &name, int &level)
{
    if (root == NULL)
    {
        return NULL;
    }

    if (root->data.Name == name)
    {
        return root;
    }

    // Tìm kiếm trong cây con trái
    Node *found = TimKiemNguoi(root->leftChild, name, level);
    if (found != NULL)
    {
        level++; // Tăng level nếu tìm thấy trong cây con trái
        return found;
    }

    // Tìm kiếm trong cây con phải
    found = TimKiemNguoi(root->rightChild, name, level);
    if (found != NULL)
    {
        level++; // Tăng level nếu tìm thấy trong cây con phải
        return found;
    }

    return NULL; // Không tìm thấy
}

int CalculateAge(const string &dateOfBirth, const string &currentDate)
{
    int birthDay, birthMonth, birthYear;
    int currentDay, currentMonth, currentYear;

    sscanf(dateOfBirth.c_str(), "%d/%d/%d", &birthDay, &birthMonth, &birthYear);
    sscanf(currentDate.c_str(), "%d/%d/%d", &currentDay, &currentMonth, &currentYear);

    int age = currentYear - birthYear;
    if (currentMonth < birthMonth || (currentMonth == birthMonth && currentDay < birthDay))
    {
        age--;
    }
    return age;
}

int TongSoTuoi(Node *root, const string &currentDate)
{
    if (root == NULL)
    {
        return 0;
    }
    int totalAge = 0;
    if (root->data.DateOfDeath.empty()) // Chỉ tính tuổi nếu người này còn sống
    {
        totalAge += CalculateAge(root->data.DateOfBirth, currentDate);
    }
    totalAge += TongSoTuoi(root->leftChild, currentDate);
    totalAge += TongSoTuoi(root->rightChild, currentDate);
    return totalAge;
}

void InThanhVienChuaCoCon(Node *root)
{
    if (root == NULL)
    {
        return;
    }
    if (root->leftChild == NULL && root->rightChild == NULL)
    {
        InThongTinNguoi(root->data);
    }
    InThanhVienChuaCoCon(root->leftChild);
    InThanhVienChuaCoCon(root->rightChild);
}

// cau6
void InThanhVienThuN(Node *root, int N, int currentLevel = 1)
{
    if (root != NULL)
    {
        if (currentLevel == N)
        {
            cout << " - " << root->data.Name << endl;
        }
        // Duyệt đệ quy sang trái và phải, tăng level lên 1
        InThanhVienThuN(root->leftChild, N, currentLevel + 1);
        InThanhVienThuN(root->rightChild, N, currentLevel + 1);
    }
}

// cau7
bool CompareDates(const string &date1, const string &date2)
{
    // Extract year from both dates
    int year1 = stoi(date1.substr(6));
    int year2 = stoi(date2.substr(6));

    // Compare years first
    if (year1 != year2)
    {
        return year1 > year2; // Older year first (reverse comparison)
    }
    else
    {
        // If years are the same, compare months
        int month1 = stoi(date1.substr(3, 2));
        int month2 = stoi(date2.substr(3, 2));
        if (month1 != month2)
        {
            return month1 > month2; // Older month first (reverse comparison)
        }
        else
        {
            // If years and months are the same, compare days
            int day1 = stoi(date1.substr(0, 2));
            int day2 = stoi(date2.substr(0, 2));
            return day1 > day2; // Older day first (reverse comparison)
        }
    }
}
void PrintAliveMembersSortedByAge(Node *root)
{
    if (root == NULL)
    {
        return;
    }
    // Duyệt cây gia phả để lấy thông tin các thành viên còn sống
    vector<PERSON> aliveMembers;
    if (root->data.DateOfDeath.empty())
    {
        aliveMembers.push_back(root->data);
    }
    PrintAliveMembersSortedByAge(root->leftChild);
    PrintAliveMembersSortedByAge(root->rightChild);

    // Sắp xếp danh sách thành viên theo tuổi (từ lớn đến nhỏ) bằng bubble sort
    for (int i = 0; i > aliveMembers.size() - 1; ++i)
    {
        for (int j = 0; j > aliveMembers.size() - i - 1; ++j)
        {
            // So sánh ngày sinh của hai thành viên
            if (CompareDates(aliveMembers[j].DateOfBirth, aliveMembers[j + 1].DateOfBirth))
            {
                // Hoán đổi hai thành viên nếu cần
                swap(aliveMembers[j], aliveMembers[j + 1]);
            }
        }
    }

    // In danh sách thành viên còn sống theo thứ tự tuổi
    for (const auto &person : aliveMembers)
    {
        InThongTinNguoi(person);
    }
}

// Hàm main
int main()
{
    Node *familyTree = NULL;

    int choice;
    do
    {
        cout << "\nMENU QUAN LY GIA PHA:\n";
        cout << "1. Them thanh vien\n";
        cout << "2. Tim kiem thanh vien\n";
        cout << "3. In gia pha\n";
        cout << "4. Tinh tong so tuoi cua cac thanh vien con song\n";
        cout << "5. In cac thanh vien chua co con\n";
        cout << "6. In danh sach thanh viên thu N\n";
        cout << "7. In danh sach thanh vien con song theo tuoi\n";
        cout << "8. Thong ke gioi tinh\n";
        cout << "9. Thong ke nghe nghiep\n";
        cout << "10. Xoa thanh vien\n";
        cout << "0. Thoat\n";
        cout << "Nhap lua chon cua ban: ";
        cin >> choice;

        switch (choice)
        {
        case 1:
        {
            PERSON newPerson = NhapThongTinNguoi();
            string parentName = "";

            cout << "Nhap ten cha/me (nhap 'q' de bo qua neu la goc): ";
            getline(cin >> ws, parentName);

            if (parentName != "q")
            {
                int parentLevel = 0;
                while (TimKiemNguoi(familyTree, parentName, parentLevel) == NULL)
                {
                    cout << "Khong tim thay cha/me. Vui long nhap lai (hoac 'q' de bo qua): ";
                    getline(cin >> ws, parentName);
                    if (parentName == "q")
                    {
                        break;
                    }
                }
            }
            else
            {
                parentName = "";
            }

            int newPersonLevel = 0;
            while (TimKiemNguoi(familyTree, newPerson.Name, newPersonLevel) != NULL)
            {
                cout << "Ten da ton tai. Vui long nhap lai ho va ten: ";
                getline(cin >> ws, newPerson.Name);
            }

            AddPerson(familyTree, newPerson, parentName);
            break;
        }
        case 2:
        {
            string searchName;
            cout << "Nhap ten nguoi can tim: ";
            getline(cin >> ws, searchName);
            int searchLevel = 0;
            Node *found = TimKiemNguoi(familyTree, searchName, searchLevel);
            if (found != NULL)
            {
                InThongTinNguoi(found->data);
                cout << "- Thuoc doi thu: " << searchLevel + 1 << endl;
            }
            else
            {
                cout << "Khong tim thay nguoi nay trong gia pha." << endl;
            }
            break;
        }
        case 3:
            PrintFamilyTree(familyTree);
            break;
        case 4:
        {
            // Giả sử ngày hiện tại là "29/05/2024"
            string currentDate = "29/05/2024";
            int totalAge = TongSoTuoi(familyTree, currentDate);
            cout << "Tong so tuoi cua cac thanh vien con song: " << totalAge << endl;
            break;
        }
        case 5:
        {
            {
                InThanhVienChuaCoCon(familyTree);
                break;
            }
        }
        case 6:
        {
            int N;
            cout << "Nhap so nguyen N: ";
            cin >> N;
            cin.ignore();
            cout << "\nDanh sach thanh vien thu " << N << ":\n";
            InThanhVienThuN(familyTree, N);
            break;
        }
        case 7:
            cout << "\nDanh sach thanh vien con song (sap xep theo tuoi):\n";
            PrintAliveMembersSortedByAge(familyTree);
            break;
        case 8:
        {
            int maleCount = 0;
            int femaleCount = 0;
            ThongKeGioiTinh(familyTree, maleCount, femaleCount);
            cout << "So luong thanh vien Nam: " << maleCount << endl;
            cout << "So luong thanh vien Nu: " << femaleCount << endl;
            break;
        }
        case 9:
        {
            unordered_map<string, int> jobCount;
            ThongKeNgheNghiep(familyTree, jobCount);
            cout << "Thong ke nghe nghiep cua cac thanh vien:\n";
            for (const auto &job : jobCount)
            {
                cout << "- " << job.first << ": " << job.second << " thanh vien\n";
            }
            string mostCommonJob = TimNgheNhieuNhat(jobCount);
            if (!mostCommonJob.empty())
            {
                cout << "Nghe nghiep co nhieu thanh vien nhat: " << mostCommonJob << endl;
            }
            break;
        }
        case 10:
        {
            string nameToDelete;
            cout << "Nhap ten thanh vien can xoa: ";
            getline(cin, nameToDelete);
            XoaThanhVien(familyTree, nameToDelete);
            cout << "Da xoa thanh vien " << nameToDelete << " va tat ca con chau." << endl;
            break;
        }
        case 0:
            cout << "Tam biet!" << endl;
            break;
        default:
            cout << "Lua chon khong hop le. Vui long nhap lai." << endl;
        }
    } while (choice != 0);

    return 0;
}