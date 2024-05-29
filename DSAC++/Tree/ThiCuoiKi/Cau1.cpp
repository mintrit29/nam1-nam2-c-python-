#include <iostream>
#include <stdio.h>
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
        return; // Dừng đệ quy sau khi thêm thành công
    }
    else
    {
        // Chỉ đệ quy nếu chưa tìm thấy cha mẹ
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

// Hàm nhập thông tin một người
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

// Hàm in thông tin một người
void InThongTinNguoi(const PERSON &person)
{
    cout << "\n- Ho va ten: " << person.Name << endl;
    cout << "- Gioi tinh: " << person.Gender << endl;
    cout << "- Noi sinh: " << person.BirthPlace << endl;
    cout << "- Ngay sinh: " << person.DateOfBirth << endl;
    if (!person.DateOfDeath.empty())
    {
        cout << "- Ngay mat: " << person.DateOfDeath << endl;
    }
    cout << "- Nghe nghiep: " << person.Job << endl;
}

// Hàm duyệt cây theo thứ tự NLR để in gia phả
void DuyetCayNLR(Node *root)
{
    if (root != NULL)
    {
        InThongTinNguoi(root->data);
        DuyetCayNLR(root->leftChild);
        DuyetCayNLR(root->rightChild);
    }
}

// Hàm tìm kiếm thông tin một người trong cây
Node *TimKiemNguoi(Node *root, const string &name)
{
    if (root == NULL)
    {
        return NULL;
    }
    if (root->data.Name == name)
    {
        return root;
    }
    Node *found = TimKiemNguoi(root->leftChild, name);
    if (found != NULL)
    {
        return found;
    }
    return TimKiemNguoi(root->rightChild, name);
}

// Hàm main để quản lý cây gia phả
int main()
{
    Node *familyTree = NULL; // Khởi tạo cây gia phả rỗng

    int choice;
    do
    {
        cout << "\nMENU QUAN LY GIA PHA:\n";
        cout << "1. Them thanh vien\n";
        cout << "2. Tim kiem thanh vien\n";
        cout << "3. In gia pha\n";
        cout << "0. Thoat\n";
        cout << "Nhap lua chon cua ban: ";
        cin >> choice;

        switch (choice)
        {
        case 1:
        {
            PERSON newPerson = NhapThongTinNguoi();
            string parentName = "";

            // Xử lý nhập tên cha mẹ
            cout << "Nhap ten cha/me (nhap 'q' de bo qua neu la goc): ";
            getline(cin >> ws, parentName); // Đọc toàn bộ dòng

            // Kiểm tra nếu parentName là "q"
            if (parentName != "q")
            {
                // Kiểm tra xem cha mẹ có tồn tại không
                while (TimKiemNguoi(familyTree, parentName) == NULL)
                {
                    cout << "Khong tim thay cha/me. Vui long nhap lai (hoac 'q' de bo qua): ";
                    getline(cin >> ws, parentName);
                    if (parentName == "q")
                    {
                        break; // Bỏ qua nếu người dùng nhập "q"
                    }
                }
            }
            else
            {
                parentName = ""; // Đặt parentName thành rỗng nếu là gốc
            }

            // Xử lý tên trùng lặp
            while (TimKiemNguoi(familyTree, newPerson.Name) != NULL)
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
            Node *found = TimKiemNguoi(familyTree, searchName);
            if (found != NULL)
            {
                InThongTinNguoi(found->data);
            }
            else
            {
                cout << "Khong tim thay nguoi nay trong gia pha." << endl;
            }
            break;
        }
        case 3:
            DuyetCayNLR(familyTree);
            break;
        case 0:
            cout << "Tam biet!" << endl;
            break;
        default:
            cout << "Lua chon khong hop le. Vui long nhap lai." << endl;
        }
    } while (choice != 0);

    return 0;
}
