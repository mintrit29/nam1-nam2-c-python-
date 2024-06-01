#include <iostream>
#include <stdio.h>
#include <string>
#include <ctime>
#include <sstream>

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

// Hàm thêm người vào cây gia phả
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

    // Tính tuổi
    int yearOfBirth, monthOfBirth, dayOfBirth;
    sscanf(person.DateOfBirth.c_str(), "%d/%d/%d", &dayOfBirth, &monthOfBirth, &yearOfBirth);
    time_t now = time(0);
    tm *ltm = localtime(&now);
    int currentYear = 1900 + ltm->tm_year;
    int age = currentYear - yearOfBirth;

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
Node *TimKiemNguoi(Node *root, const string &name, const int &level)
{
    if (root == NULL)
    {
        return NULL;
    }
    if (root->data.Name == name)
    {
        return root;
    }
    Node *found = TimKiemNguoi(root->leftChild, name, level + 1);
    if (found != NULL)
    {
        return found;
    }
    return TimKiemNguoi(root->rightChild, name, level + 1);
}

// Hàm main
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

            cout << "Nhap ten cha/me (nhap 'q' de bo qua neu la goc): ";
            getline(cin >> ws, parentName);

            if (parentName != "q")
            {
                while (TimKiemNguoi(familyTree, parentName, 0) == NULL)
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

            while (TimKiemNguoi(familyTree, newPerson.Name, 0) != NULL)
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
            int level = 0;
            Node *found = TimKiemNguoi(familyTree, searchName, level);
            if (found != NULL)
            {
                InThongTinNguoi(found->data);
                cout << "- Thuoc doi thu: " << level + 1 << endl;
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
        case 0:
            cout << "Tam biet!" << endl;
            break;
        default:
            cout << "Lua chon khong hop le. Vui long nhap lai." << endl;
        }
    } while (choice != 0);

    return 0;
}